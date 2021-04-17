using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAll_Cars
    {
        IEnumerable<Category> Cars { get; set; }
        IEnumerable<Category> GetFavCars { get; set; }
        Category GetCarByID(int CarID);
    }
}
