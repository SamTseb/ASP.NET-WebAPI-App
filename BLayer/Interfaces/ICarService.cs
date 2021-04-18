using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace BLayer.Interfaces
{
    public interface ICarService
    {
        Car Add(Car car);
        void Update(int Id, Car car);
        void Delete(int ID);
        List<Car> Get();
        Car Get(int ID);
    }
}
