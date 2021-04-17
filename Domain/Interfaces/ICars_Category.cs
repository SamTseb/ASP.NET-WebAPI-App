using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICars_Category
    {
        IEnumerable<Category> Categories { get;}
    }
}
