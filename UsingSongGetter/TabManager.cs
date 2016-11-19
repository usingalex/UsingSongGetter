using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    UsingSongGetter is a easy to use Program, to get your Current Playing Song
    and Display it for example in your Livestream.

    Copyright (C) 2016  usingalex

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

	If you need Help, or you have any Questions Contact me at: usingalex@gmail.com
*/

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
