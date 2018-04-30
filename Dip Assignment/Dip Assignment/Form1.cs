using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using System.IO;

namespace Dip_Assignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VideoCapture _capture = new VideoCapture();
            imgCamUser.Image = _capture.QueryFrame();

            CascadeClassifier _cascadeClassifier;
        _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "\\haarcascade_frontalface_default.xml");
using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
                {
                    if (imageFrame != null)
                    {
                        var grayframe = imageFrame.Convert<Gray, byte>();
    var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here
                        foreach (var face in faces)
                        {
                            imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them
                           
                        }
                    }
                    imgCamUser.Image = imageFrame;                    
                }

           
        }
    }
}
