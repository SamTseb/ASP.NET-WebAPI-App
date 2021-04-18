using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Interfaces;
using System.IO;
using BLayer.Interfaces;
using DBL;

namespace BLayer.Implementations
{
    public class CarService : ICarService
    {
        private AppDBContext context;
        //private List<Car> _cars;

        public CarService(AppDBContext context)
        {
            this.context = context;
        }

        public Car Add(Car car)
        {
            try
            {
                Car created_car = context.cars.Add(car).Entity;
                context.SaveChanges();
                return created_car;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при создании машины.");
            }
        }


        public void Delete(int ID)
        {
            var car = context.cars.FirstOrDefault(x => x.ID == ID);

            if (car == null)
                throw new Exception("Машина с ID:" + ID.ToString() + " не найдена.");

            try
            {
                context.cars.Remove(car);

                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при удалении машины");
            }
        }

        public List<Car> Get()
        {
            return context.cars.ToList();
        }

        public Car Get(int ID)
        {
            return context.cars.FirstOrDefault(x => x.ID == ID);
        }

        public void Update(int ID, Car car)
        {
            var Old_Car = context.cars.FirstOrDefault(x => x.ID == ID);

            if (Old_Car == null)
                throw new Exception("Машина с ID:" + ID.ToString() + " не найдена.");

            try
            {
                Old_Car.Name = car.Name;
                Old_Car.Price = car.Price;
                Old_Car.Available = car.Available;
                Old_Car.CategoryID = car.CategoryID;
                Old_Car.Desc = car.Desc;

                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при обновлении машины");
            }
        }
    }
}
