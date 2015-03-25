using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elifoot.Logic
{
    public static class Randomizer
    {
        private static Random rand = new Random();

        public static Random GetRandomizer
        {
            get { return rand; }
        }
    }
}