using System.Windows.Forms;

namespace MicrosoftCognitiveServicesComputerVisionDemo
{
    public class FileHelper
    {

        public static string GetImageFilePath()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return string.Empty;
        }
    }
}
