using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Logic
{
    public class Bookmark
    {
        public Bookmark(String u, String n)
        {
            URL = u;
            name = n; 
        }
        public String URL;
        public String name;
    }
}
