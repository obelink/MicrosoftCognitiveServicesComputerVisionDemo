using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicrosoftCognitiveServicesComputerVisionDemo
{
    public partial class MainForm : Form
    {
        private const string SubscriptionKey = "17e72298c40a4532901b20c1df72c5b2";

        public MainForm()
        {
            InitializeComponent();
        }

        private async void selectImageFilePathButton_Click(object sender, EventArgs e)
        {
            var imageFilePath = GetImageFilePath();

            imageFilePathTextBox.Text = imageFilePath;

            var json = await GetAnalyzeImageResult(imageFilePath);
              
            jsonResultTextBox.Text = FormatJson(json);
        }

        private static string GetImageFilePath()
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

        private static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (var fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    return binaryReader.ReadBytes((int)fileStream.Length);
                }
            }
        }

        private static string GetRequestUri()
        {
            const string uriBase = "https://westeurope.api.cognitive.microsoft.com/vision/v1.0/analyze";
            const string requestParameters = "visualFeatures=Categories,Tags,Description";

            return uriBase + "?" + requestParameters;
        }

        private static async Task<string> GetAnalyzeImageResult(string imageFilePath)
        {
            var byteData = GetImageAsByteArray(imageFilePath);
            var requestUri = GetRequestUri();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    
                    var response = await client.PostAsync(requestUri, content);

                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        private static string FormatJson(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");

            var stringBuilder = new StringBuilder();
            var quote = false;
            var ignore = false;
            var offset = 0;
            const int indentLength = 3;

            foreach (var ch in json)
            {
                switch (ch)
                {
                    case '"':
                        if (!ignore) quote = !quote;
                        break;
                    case '\'':
                        if (quote) ignore = !ignore;
                        break;
                }

                if (quote)
                    stringBuilder.Append(ch);
                else
                {
                    switch (ch)
                    {
                        case '{':
                        case '[':
                            stringBuilder.Append(ch);
                            stringBuilder.Append(Environment.NewLine);
                            stringBuilder.Append(new string(' ', ++offset * indentLength));
                            break;
                        case '}':
                        case ']':
                            stringBuilder.Append(Environment.NewLine);
                            stringBuilder.Append(new string(' ', --offset * indentLength));
                            stringBuilder.Append(ch);
                            break;
                        case ',':
                            stringBuilder.Append(ch);
                            stringBuilder.Append(Environment.NewLine);
                            stringBuilder.Append(new string(' ', offset * indentLength));
                            break;
                        case ':':
                            stringBuilder.Append(ch);
                            stringBuilder.Append(' ');
                            break;
                        default:
                            if (ch != ' ') stringBuilder.Append(ch);
                            break;
                    }
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
    