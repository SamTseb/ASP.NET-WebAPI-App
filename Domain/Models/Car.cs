using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;

namespace Domain.Models
{
    public class Car : I_Identifiable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }
        public int CategoryID { get; set; }
        //public virtual Category Category { get; set; }
    }
}
