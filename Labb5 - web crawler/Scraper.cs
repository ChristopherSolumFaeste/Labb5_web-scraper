using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labb5___web_crawler
{
    public partial class Scraper : Form
    {
        HttpClient client = new HttpClient();
        public Scraper()
        {
            InitializeComponent();
        }

        private void extractButton_Click(object sender, EventArgs e)
        {
            GetWebpageHTML(URLTextBox.Text.ToString());
            numberOfURLLabel.Text = $"Number of images found: {urlListBox.Items.Count}";
        }
        private void GetWebpageHTML(string url)
        {
            Task<string> download = client.GetStringAsync(url);
            download.Wait();

            string temp = @"(?<=<img .*src.*=.*"")([^"">]+.(?:jpg|png|bmp|jpeg|gif))[^""|^?]?";
            string urlTemp = "";
            Regex regex = new Regex(temp);
            if (regex.IsMatch(download.Result))
            {
                foreach (Match match in regex.Matches(download.Result))
                {
                    if (!match.Value.StartsWith("http"))
                    {
                        urlTemp = "https://gp.se" + match.Value;
                    }
                    else
                    {
                        urlTemp = match.Value;
                    }
                    urlListBox.Items.Add(urlTemp + Environment.NewLine);
                }
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog imageFolderDialog = new FolderBrowserDialog();
            imageFolderDialog.ShowDialog();
            //imageFolderDialog.SelectedPath
        }
        private async Task<T> ImageScraper(string filepath)
        {
            client.GetByteArrayAsync(urlListBox.);
        }
    }
}