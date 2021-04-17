using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;

namespace DBL
{
    public static class SampleData
    {
        public static void InitData(AppDBContext context)
        {
            if (!context.categories.Any())
            {
                context.categories.Add(new Category() { Name="Petrol Category", Desc="Авто с бензиновым двигателем"});
                context.categories.Add(new Category() { Name = "Diesel Category", Desc = "Авто с дизельным двигателем" });
                context.categories.Add(new Category() { Name = "Electric Category", Desc = "Авто с электродвигателем" });
                context.SaveChanges();
            }

            if (!context.cars.Any())
            {
                context.cars.Add(new Car() { Name = "Aston Martin Vanquish II", Desc = "Самый дорогой среди бензиновых автомобилей.", Price = 17845000, CategoryID = context.categories.First().ID });
                context.cars.Add(new Car() { Name = "Mercedes - Benz S VII", Desc = "Самый дорогой среди дизельных автомобилей.", Price = 13370000, CategoryID = context.categories.Skip(1).First().ID });
                context.cars.Add(new Car() { Name = "Porsche Taycan I", Desc = "Самый дорогой среди электромобилей.", Price = 12310000, CategoryID = context.categories.Skip(2).First().ID });
                context.SaveChanges();
            }
        }
    }
}
