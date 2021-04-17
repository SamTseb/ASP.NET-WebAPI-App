using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;

namespace Domain.Models
{
    public class Category : I_Identifiable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<Car> Cars { get; set; }
    }
}
