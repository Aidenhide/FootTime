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
        public Manager(string name)
        {
            Name = name;
        }

        [Key]
        public int ManagerId { get; set; } 
        
        public string Name { get; set; }

    }
}