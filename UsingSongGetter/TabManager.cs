using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingSongGetter
{
    class TabManager
    {

        //Return all open tabs of the Specified Browser, as a String array.
        public static String[] getTabNames(SongSource source)
        {
            //Check which Browser is selected.
            switch(source)
            {
                //When Browser is InternetExplorer.
                case SongSource.IE:
                    List<string> tabs = new List<string>();
                    foreach (InternetExplorer ie in new ShellWindows())
                    {
                        //When task executable is iexplore.
                        string filename = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                        if (filename.Equals("iexplore"))
                        {
                            //Get the page Document, and get put the Title in the tab List.
                            IHTMLDocument2 doc = ie.Document;
                            tabs.Add(doc.title);
                        }
                    }
                    //Return all tabs.
                    return tabs.ToArray();
                default:
                    //Return Empty Array if a wrong Source is Selected.
                    return new String[0];
            }
        }

    }
}
