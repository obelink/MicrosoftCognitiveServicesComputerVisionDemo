using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;

namespace MicrosoftCognitiveServicesComputerVisionDemo
{
    public partial class MainFormOxford : Form
    {
        
        private readonly VisionServiceClient _visionServiceClient;
        private readonly VisualFeature[] _visualFeatures;
        private AnalysisResult _analysisResult;
        
        public MainFormOxford()
        {
            InitializeComponent();
            _visionServiceClient = new VisionServiceClient("17e72298c40a4532901b20c1df72c5b2", 
                                                           "https://westeurope.api.cognitive.microsoft.com/vision/v1.0");
            _visualFeatures = new[] { VisualFeature.Adult, VisualFeature.Categories, VisualFeature.Color,
                                      VisualFeature.Description, VisualFeature.Faces, VisualFeature.ImageType,
                                      VisualFeature.Tags };
        }

  
        private async void SelectImageFilePathButton_Click(object sender, EventArgs e)
        {
            // Reset
            _analysisResult = null;
            resultTextBox.Text = string.Empty;

            // Select a image
            var imageFilePath = FileHelper.GetImageFilePath();
            if (imageFilePath.Length <= 0) return;

            // Show the details
            imageFilePathTextBox.Text = imageFilePath;
            pictureBox.ImageLocation = imageFilePath;

            // Call the API and analyse the image
            _analysisResult = await GetAnalyzeImageResult(imageFilePath);

            // Extract the Description and Confidence
            var caption = _analysisResult?.Description?.Captions[0];
            resultTextBox.Text = $"{caption?.Text} ({caption?.Confidence})";

            // Force the Faces to draw
            pictureBox.Invalidate();
        }
        
        private  async Task<AnalysisResult> GetAnalyzeImageResult(string imageFilePath)
        {
            using (Stream imageFileStream = File.OpenRead(imageFilePath))
            {
                // Call the API and analyse the image
                return await _visionServiceClient.AnalyzeImageAsync(imageFileStream, _visualFeatures);
            }
            
        }
        
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_analysisResult?.Faces?.Length > 0)
            {
               DrawFaces(e);
            }
        }

        private void DrawFaces(PaintEventArgs e)
        {
            // Calculate ScaleFactor
            var scaleFactorX = (double)pictureBox.Width / pictureBox.Image.Width;
            var scaleFactorY = (double)pictureBox.Height / pictureBox.Image.Height;

            foreach (var face in _analysisResult.Faces)
            {
                DrawFace(e, scaleFactorX, scaleFactorY, face);
            }
        }

        private static void DrawFace(PaintEventArgs e, double scaleFactorX, double scaleFactorY, Face face)
        {
            var rectangle = new System.Drawing.Rectangle((int) (face.FaceRectangle.Left * scaleFactorX),
                                                         (int) (face.FaceRectangle.Top * scaleFactorY),
                                                         (int) (face.FaceRectangle.Width * scaleFactorX),
                                                         (int) (face.FaceRectangle.Height * scaleFactorY));

            using (var pen = new Pen(System.Drawing.Color.Red, 4))
            {
                e.Graphics.DrawRectangle(pen, rectangle);
            }

            var caption = $"{face.Age} - {face.Gender}";
            var yellowBrush = new SolidBrush(System.Drawing.Color.Yellow);
            e.Graphics.DrawString(caption, new Font("Arial", 12), yellowBrush, rectangle);
        }

    }
}
    