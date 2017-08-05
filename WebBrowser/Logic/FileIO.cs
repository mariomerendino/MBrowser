using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;

namespace WebBrowser
{
    public class FileIO
    {
        //File Paths for all file input & output. 
        public static String dataFolderPath = Directory.GetCurrentDirectory() + "/BrowsingData";
        public static String bookMarksFilePath = dataFolderPath + "/bookmarks.csv";
        public static String historyFilePath = dataFolderPath + "/history.csv";
        public static String homeFilePath = dataFolderPath + "/home.csv";
        public FileIO()
        {
            //Checks if data folder exists, if not create the folder and essential files. 
            if (Directory.Exists(dataFolderPath))
            {
                

            }
            else
            {
                Directory.CreateDirectory(dataFolderPath);
                File.Create(bookMarksFilePath);
                File.Create(historyFilePath);
                File.Create(homeFilePath);
            }

        }
        /// <summary>
        /// Prints a line to the history File. 
        /// </summary>
        /// <param name="url"></param>
        public void addToHistory(String url)
        {
            File.AppendAllText(historyFilePath, url + "," + DateTime.Now.ToString("MM dd yyyy HH mm ss") + Environment.NewLine);
        }
        
        /// <summary>
        /// Prints a line to the bookmarks file.  
        ///
        /// </summary>
        /// <param name="url"></param>
        /// <param name="bookmarkName"></param>
        public void addToBookmarks(String url, String bookmarkName)
        {
            try
            {
                File.AppendAllText(bookMarksFilePath, url + "," + bookmarkName + Environment.NewLine);
            }
            catch(Exception e)
            {

            }
        }
        /// <summary>
        /// Reads history file
        /// </summary>
        /// <returns>a list of history objects</returns>
        public List<History> getHistory()
        {
            List<History> historyObj = new List<History>();
            String line;
            StreamReader file = new StreamReader(historyFilePath);
            while ((line = file.ReadLine()) != null)
            {

            }
            return historyObj;
        }
        /// <summary>
        /// Reads bookmark file
        /// </summary>
        /// <returns>a list of history objects</returns>
        public List<Bookmark> getBookmarks()
        {
            List<Bookmark> bookmarkObj = new List<Bookmark>();
            String line;
            String[] split;
            StreamReader file = new StreamReader(bookMarksFilePath);
            while ((line = file.ReadLine()) != null)
            {
                //split by commas
                split = line.Split(',');

                bookmarkObj.Add(new Bookmark(split[0], split[1]));

            }
            return bookmarkObj;
        }


    }
}
