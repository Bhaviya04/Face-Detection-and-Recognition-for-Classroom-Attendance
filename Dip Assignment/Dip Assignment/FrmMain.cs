using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Dip_Assignment
{
    public partial class FrmMain : Form
    {
        private VideoCapture _capture;
        private CascadeClassifier _cascadeClassifier;
        private bool _hasRecognizedFace;
        private RecognizerEngine _recognizerEngine;
        private readonly String _databasePath = Application.StartupPath + "/face_store.db";
        private readonly String _trainerDataPath = Application.StartupPath + "/traineddata";


        public FrmMain(string status)
        {
            InitializeComponent();
            if (status == "enroll")
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnAuthenticate.Visible = false;
                btnTrain.Visible = false;
                lblTrainingStatus.Visible = false;
                btnBack.Visible = true;
            }
            else if(status == "attendance")
            {
                btnSave.Visible = false;
                btnClear.Visible = true;
                btnAuthenticate.Visible = true;
                btnTrain.Visible = false;
                lblTrainingStatus.Visible = false;
                btnBack.Visible = true;
            }
            else if (status == "recognizer")
            {
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnAuthenticate.Visible = false;
                btnTrain.Visible = true;
                lblTrainingStatus.Visible = true;
                btnBack.Visible = true;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Train the recognizer here
            _recognizerEngine = new RecognizerEngine(_databasePath, _trainerDataPath);
            lblTrainingStatus.Text = "Training started";
            btnTrain.Enabled = false;
            bckGroundTrainer.RunWorkerAsync();
            _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_alt_tree.xml");
            _capture = new VideoCapture();
            Application.Idle += new EventHandler(ProcessFrame);

        }


        private void ProcessFrame(Object sender, EventArgs args)
        {
            imgCamUser.Image = _capture.QueryFrame();
            if (!_hasRecognizedFace)
            {
                using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
                {
                    if (imageFrame != null)
                    {
                        var grayframe = imageFrame.Convert<Gray, byte>();
                        var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);
                        foreach (var face in faces)
                        {
                            imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3);
                            //render the image to the picture box
                            picCapturedUser.Image = imageFrame.Copy(face);
                        }
                    }
                    imgCamUser.Image = imageFrame;
                    if (picCapturedUser.Image != null)
                        _hasRecognizedFace = true;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            picCapturedUser.Image = null;
            _hasRecognizedFace = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var faceToSave = new Image<Gray, byte>(picCapturedUser.Image.Bitmap);
            Byte[] file;
            IDataStoreAccess dataStore = new DataStoreAccess(_databasePath);
            var frmSaveDialog = new FrmSaveDialog();
            if (frmSaveDialog.ShowDialog() == DialogResult.OK)
            {
                if (frmSaveDialog._identificationNumber.Trim() != String.Empty)
                {
                    var username = frmSaveDialog._identificationNumber.Trim().ToLower();
                    var filePath = Application.StartupPath + String.Format("/{0}.bmp", username);
                    faceToSave.ToBitmap().Save(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = new BinaryReader(stream))
                        {
                            file = reader.ReadBytes((int) stream.Length);
                        }
                    }
                    var result = dataStore.SaveFace(username, file);
                    MessageBox.Show(result, "Save Result", MessageBoxButtons.OK);
                }

            }
        }

        private void btnAuthenticate_Click(object sender, EventArgs e)
        {
            try
            {
                var predictedUserId = _recognizerEngine.RecognizeUser(new Image<Gray, byte>(picCapturedUser.Image.Bitmap));
                if (predictedUserId == -1)
                    MessageBox.Show("This person is not recognized, Kindly register this face", "Authentication Result",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //proceed to documents library
                    IDataStoreAccess dataStore = new DataStoreAccess(_databasePath);
                    var username = dataStore.GetUsername(predictedUserId);
                    if (username != String.Empty)
                    {
                        int count = dataStore.CheckWithCourse(username);
                        if(count >= 1)
                        {
                            DialogResult result = MessageBox.Show("Student recognized as " + username + ". Is your Username " + username + "?", "Confirm your identity", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                int count2 = dataStore.CheckIfAlreadyExists(username);
                                if(count2 >= 1)
                                {
                                    MessageBox.Show("Username " + username + " is already marked present in today's class");
                                }
                                else
                                {
                                   string output = dataStore.MarkAttendance(username);
                                    if(output == "successful")
                                    {
                                        MessageBox.Show("Attendance marked successful for " + username + ". Also an email is sent to your email address showing Attendance Confirmation");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Attendance not marked since some error occured");
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Student Recognized as " + username + " but this student is not enrolled in this course");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Username for this face, Kindly register this face", "Authentication Result",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Authentication Result - Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }

        private bool TrainRecognizer(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                var hasTrainedRecognizer = _recognizerEngine.TrainRecognizer();
                return hasTrainedRecognizer;
            }
            return false;
        }

        private void bckGroundTrainer_DoWork(object sender, DoWorkEventArgs e)
        {
            
            var worker = sender as BackgroundWorker;
            e.Result = TrainRecognizer(worker, e);
        }
        
        private void bckGroundTrainer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                lblTrainingStatus.Text = "Training has been cancelled!";
            }
            else
            {
                var result = (bool) e.Result;
                lblTrainingStatus.Text = result ? "Training has been completed successfully!" : "Training could not be completed, An Error Occurred";
            }
            btnTrain.Enabled = true;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            btnTrain.Enabled = false;
            bckGroundTrainer.RunWorkerAsync();
        }

        //private void adminLoginToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    FrmAdminLogin frmAdmin = new FrmAdminLogin();
        //    frmAdmin.Show();
        //}

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _capture.Stop();
            _capture.Dispose();
            Application.Idle -= ProcessFrame;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            var adminoptions = new FrmAdminOptions();
            if (adminoptions.ShowDialog() == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }
    }
}
