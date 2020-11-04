using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labb5_web_scraper
{
    public partial class Scraper : Form
    { 
        public string filePath;
        int counter = 1;
        
        HttpClient client = new HttpClient();

        public Scraper()
        {
            InitializeComponent();
        }
        private async void extractButton_Click(object sender, EventArgs e)
        {
            urlListBox.Items.Clear();
            try
            {
                if (URLTextBox.Text.Contains("http"))
                {
                    await GetWebpageHTML(URLTextBox.Text);
                    numberOfURLLabel.Text = $"Number of images found: {urlListBox.Items.Count}";
                }
                else
                {
                    URLTextBox.Text = "https://" + URLTextBox.Text;
                    await GetWebpageHTML(URLTextBox.Text);
                    numberOfURLLabel.Text = $"Number of images found: {urlListBox.Items.Count}";
                }
            }
            catch
            {
                MessageBox.Show("Webpage not found!\n" +
                                "(Invalid URL?)");
                numberOfURLLabel.Text = "No images found!";
            }

            if (urlListBox.Items.Count > 0)
            {
                saveButton.Enabled = true;
            }

            numberOfURLLabel.Visible = true;
        }
        private async Task GetWebpageHTML(string url)
        {
            using (Task<string> download = client.GetStringAsync(url))
            {
                await download;
                string userInputURL;

                Regex regex = new Regex(@"(?<=<img.*src="").+?(?="".*"">)");
                if (regex.IsMatch(download.Result))
                {
                    foreach (Match match in regex.Matches(download.Result))
                    {
                        if (!match.Value.StartsWith("http"))
                        {
                            userInputURL = URLTextBox.Text + match.Value;
                        }
                        else
                        {
                            userInputURL = match.Value;
                        }
                        urlListBox.Items.Add(userInputURL + Environment.NewLine);
                    }
                }
            }
        }
        private async void saveButton_Click(object sender, EventArgs e)
        {
            int failedCounter = 0;
            saveButton.Enabled = false;

            List<Task<byte[]>> imageData = new List<Task<byte[]>>();
            FolderBrowserDialog imageFolderDialog = new FolderBrowserDialog();

            imageFolderDialog.ShowDialog();
            filePath = imageFolderDialog.SelectedPath;

            foreach (string url in urlListBox.Items)
            {
                try
                {
                    imageData.Add(client.GetByteArrayAsync(url.Trim()));
                }
                catch
                {
                    continue;
                }
            }

            savedResultLabel.Visible = true;

            while (imageData.Count > 0)
            {
                Task<byte[]> task = null;
                try
                {
                    using (task = await Task.WhenAny(imageData))
                    {
                        await SaveFileAsync(task.Result);
                    }
                }
                catch
                {
                    failedCounter++;
                }
                finally
                {
                    imageData.Remove(task);
                }
                savedResultLabel.Text = $"{counter - 1} images saved to disk. {failedCounter} failed.";
            }
            MessageBox.Show("Download complete!");
        }
        private async Task SaveFileAsync(byte[] imageDataArray)
        {
            string fileType;
            switch (imageDataArray[0])
            {
                case 255:
                    fileType = ".jpg";
                    break;
                case 137:
                    fileType = ".png";
                    break;
                case 47:
                    fileType = ".gif";
                    break;
                case 66:
                    fileType = ".bmp";
                    break;
                default:
                    throw new Exception();
            }
            using (FileStream fileStream = new FileStream(filePath + $"\\image{counter}" + 
                                            fileType, FileMode.CreateNew))
            {
                await fileStream.WriteAsync(imageDataArray, 0, imageDataArray.Length);
            }
            counter++;
        }
        private void URLTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                extractButton.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}