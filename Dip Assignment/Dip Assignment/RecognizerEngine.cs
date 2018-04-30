using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Microsoft.SqlServer.Server;

namespace Dip_Assignment
{
    class RecognizerEngine
    {
        private FaceRecognizer _faceRecognizer;
        private DataStoreAccess _dataStoreAccess;
        private String _recognizerFilePath;

        public RecognizerEngine(String databasePath, String recognizerFilePath)
        {
            _recognizerFilePath = recognizerFilePath;
            _dataStoreAccess = new DataStoreAccess(databasePath);
            //_faceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
            _faceRecognizer = new LBPHFaceRecognizer(1, 8, 8, 8, double.PositiveInfinity);
        }

        public bool TrainRecognizer()
        {
            var allFaces = _dataStoreAccess.CallFaces("ALL_USERS");
            if (allFaces != null)
            {
                var faceImages = new Image<Gray, byte>[allFaces.Count];
                var faceLabels = new int[allFaces.Count];
                for (int i = 0; i < allFaces.Count; i++)
                {
                    Stream stream = new MemoryStream();
                    stream.Write(allFaces[i].Image, 0, allFaces[i].Image.Length);
                    var faceImage = new Image<Gray, byte>(new Bitmap(stream));
                    faceImages[i] = faceImage.Resize(100,100,Inter.Cubic);
                    faceLabels[i] = allFaces[i].UserId;
                }
                _faceRecognizer.Train(faceImages, faceLabels);
                _faceRecognizer.Save(_recognizerFilePath);
            }
            return true;
           
        }

        public void LoadRecognizerData()
        {
            _faceRecognizer.Load(_recognizerFilePath);
        }

        public int RecognizeUser(Image<Gray, byte> userImage)
        {
          /*  Stream stream = new MemoryStream();
            stream.Write(userImage, 0, userImage.Length);
            var faceImage = new Image<Gray, byte>(new Bitmap(stream));*/
            _faceRecognizer.Load(_recognizerFilePath);

            var result = _faceRecognizer.Predict(userImage.Resize(100, 100, Inter.Cubic));
            return result.Label;
        }
    }
}
