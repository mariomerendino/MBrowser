using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class NewBookmark : Form
    {
        public String bookmarkURL;
        public NewBookmark(String Url)
        {
            bookmarkURL = Url;
            InitializeComponent();
            urlTextBox.Text = bookmarkURL;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void addBookmarkButton_Click(object sender, EventArgs e)
        {
            if (urlTextBox.Text != "" && nameTextBox.Text != "") { 
                FileIO io = new FileIO();
                io.addToBookmarks(urlTextBox.Text, nameTextBox.Text);
                this.Dispose(true);
            }
        }
    }
}
