using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    public class Manager
    {
        public Manager() { }
        public Manager(string name, bool human)
        {
            Name = name;
            isHuman = human;
        }

        [Key]
        public int ManagerId { get; set; }

        public bool isHuman { get; set; }

        public string Name { get; set; }

    }
}