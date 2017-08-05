using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;
namespace WebBrowser
{
    public partial class BookmarkWindow : Form
    {
        public FileIO io = new FileIO();
        public BookmarkWindow()
        {
            InitializeComponent();
            fill();
        }
        public void fill()
        {
            List<Bookmark> bookmarks = io.getBookmarks();
            for(int i = 0; i < bookmarks.Count; i++)
            {
                dataGridView1.Rows.Add(bookmarks.ElementAt<Bookmark>(i).name, bookmarks.ElementAt<Bookmark>(i).URL);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //goToURL(e.RowIndex);
        }

    }
}
