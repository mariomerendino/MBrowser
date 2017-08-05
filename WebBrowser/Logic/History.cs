using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Logic
{
    public class History
    {
        public String URL;
        public String timeStamp;

        public History(String u, String t)
        {
            URL = u;
            timeStamp = t;
        }
    }
}
