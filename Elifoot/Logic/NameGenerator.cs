using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elifoot.Logic
{
    public class NameGenerator
    {
        List<string> nameList = new List<string>();
        private void getNames()
        {
            string[] text = System.IO.File.ReadAllLines("C:/Users/Nuno Teixeira/Desktop/NameList.txt");
            //C:/Users/Nuno Teixeira/Desktop/NameList.txt
            //C:/Users/Fabio Pacheco/Documents/Visual Studio 2013/Projects/Elifoot/Elifoot/Content/NameList.txt
            foreach (string x in text)
            {
                nameList.AddRange(x.Trim().Split());
            }
            
        }

        public NameGenerator()
        {
        }

        public List<string> Names
        {
            get {
                if(nameList.Count != 0) {
                    return nameList;
                }
                else
                {
                    getNames();
                    return nameList;
                }
            }
        }
    }

     
}