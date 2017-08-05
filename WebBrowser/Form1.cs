using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WebBrowser
{
    public partial class Form1 : Form
    {

        public Boolean fullscreen = true;
        /// <summary>
        /// Array of strings, used for forward & back. 
        /// </summary>
        public static Stack<String> tempHistory = new Stack<String>();
        /// <summary>
        /// Instantiates a FILE IO CLASS, used to interact with all external files. 
        /// </summary>
        public FileIO io = new FileIO();
        /// <summary>
        /// used with temp history to get the users current position in the List
        /// </summary>
        public static int currentPos = 0;
        public Form1()
        {

            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed= true;
        }

        /// <summary>
        /// Naviagtes to a URL
        /// </summary>
        private void Navigate()
        {
            webBrowser1.Navigate(addressBar.Text);
        }
        /// <summary>
        /// If the navbar is selected & the user hits enter, naviagte to the URL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13)
            {
                Navigate();
            }
        }
        /// <summary>
        /// if the main go button is hit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            Navigate();
        }

        /// <summary>
        /// About button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created By Mario J. Merendino 2017 \n Written In C# \n Version 0.0.1");
        }

        /// <summary>
        /// if the save button is hit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open a save dialog to save the HTML 
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "HTML files (*.html)|*.html";

            if (savefile.ShowDialog() == DialogResult.OK && savefile.FileName != "")
            {
                File.WriteAllText(savefile.FileName, webBrowser1.DocumentText);
            }
            else
            {
                MessageBox.Show("Error! \n Invailid File or File Path");
            }
        }
        /// <summary>
        /// If the progress changes update the progressbar. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try {
                if (e.CurrentProgress != 0 && e.MaximumProgress != 0)
                    toolStripProgressBar1.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            try
            {
                String newUrl = webBrowser1.Url.ToString();
                addressBar.Text = newUrl;
                if (tempHistory.Count() == 0)
                {
                    tempHistory.Push(newUrl);
                }
                else if (tempHistory.Peek() != newUrl)
                {
                    tempHistory.Push(newUrl);
                    io.addToHistory(newUrl);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Go backward on button click. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }
        /// <summary>
        /// Go forward on forward button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forwardButton_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void addBookmark_Click(object sender, EventArgs e)
        {
            try
            {
                NewBookmark addBookmark = new NewBookmark(webBrowser1.Url.ToString());
                addBookmark.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bookmarksButton_Click(object sender, EventArgs e)
        {
            try
            {
                BookmarkWindow window = new BookmarkWindow();
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void viewFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fullscreen)
            {
                fullscreen = false;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {

                fullscreen = true;
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
