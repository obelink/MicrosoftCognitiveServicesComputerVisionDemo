using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Color = Microsoft.ProjectOxford.Vision.Contract.Color;

namespace MicrosoftCognitiveServicesComputerVisionDemo
{
    public partial class MainFormOxford : Form
    {
        
        private readonly VisionServiceClient _visionServiceClient = new VisionServiceClient("17e72298c40a4532901b20c1df72c5b2", "https://westeurope.api.cognitive.microsoft.com/vision/v1.0");
        private AnalysisResult _analysisResult;

        public MainFormOxford()
        {
            InitializeComponent();
        }

        private async void selectImageFilePathButton_Click(object sender, EventArgs e)
        {
            var imageFilePath = FileHelper.GetImageFilePath();

            pictureBox.Image = null;

            imageFilePathTextBox.Text = imageFilePath;
            pictureBox.ImageLocation = imageFilePath;

            _analysisResult =  await GetAnalyzeImageResult(imageFilePath);

            var caption = _analysisResult?.Description?.Captions[0];
            resultTextBox.Text = $"{caption?.Text} ({caption?.Confidence})";


            pictureBox.Invalidate();
        }
        
        private  async Task<AnalysisResult> GetAnalyzeImageResult(string imageFilePath)
        {
          
            using (Stream imageFileStream = File.OpenRead(imageFilePath))
            {
                var visualFeatures = new[] { VisualFeature.Adult, VisualFeature.Categories, VisualFeature.Color,
                                             VisualFeature.Description, VisualFeature.Faces, VisualFeature.ImageType,
                                             VisualFeature.Tags };

                return await _visionServiceClient.AnalyzeImageAsync(imageFileStream, visualFeatures);
            }
            
        }
        

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_analysisResult == null || _analysisResult.Faces.Length <= 0) return;

            var scaleFactorX = (double) pictureBox.Width / pictureBox.Image.Width;
            var scaleFactorY = (double) pictureBox.Height / pictureBox.Image.Height;

            foreach (var face in _analysisResult.Faces)
            {
                var rectangle = new System.Drawing.Rectangle((int) (face.FaceRectangle.Left * scaleFactorX),
                    (int) (face.FaceRectangle.Top * scaleFactorY),
                    (int) (face.FaceRectangle.Width * scaleFactorX),
                    (int) (face.FaceRectangle.Height * scaleFactorY));

                using (var pen = new Pen(System.Drawing.Color.Red, 3))
                {
                    e.Graphics.DrawRectangle(pen, rectangle);
                }

                var caption = $"{face.Age} - {face.Gender}";
                e.Graphics.DrawString(caption, new Font("Arial", 15, FontStyle.Bold),
                    new SolidBrush(System.Drawing.Color.Yellow), rectangle);
            }
        }
    }
}
    