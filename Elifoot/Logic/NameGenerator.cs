using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elifoot.Logic
{
    public class NameGenerator
    {
        private NameGenerator nameGenerator;
        List<string> nameList;
        private void getNames()
        {
            string text = System.IO.File.ReadAllText("C:/Users/Fabio Pacheco/documents/visual studio 2013/Projects/Elifoot/Elifoot/Content/NameList.txt");
            nameList = new List<string>(text.Split());
        }

        public NameGenerator()
        {

        }

        public List<string> Names
        {
            get {
                if(nameList != null) {
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