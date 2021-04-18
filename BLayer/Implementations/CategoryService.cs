using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BLayer.Interfaces;
using DBL;
using Domain.Interfaces;
using Domain.Models;

namespace BLayer.Implementations
{
    public class CategoryService : /*BaseService,*/ ICategoryService
    {
        private AppDBContext context;
        //private List<Category> _cars;

        public CategoryService(AppDBContext context)
        {
            this.context = context;
        }

        public Category Add(Category category)
        {
            try
            {
                Category created_category = context.categories.Add(category).Entity;
                context.SaveChanges();
                return created_category;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при создании машины.");
            }
        }


        public void Delete(int ID)
        {
            var category = context.categories.FirstOrDefault(x => x.ID == ID);

            if (category == null)
                throw new Exception("Машина с ID:" + ID.ToString() + " не найдена.");

            try
            {
                context.categories.Remove(category);

                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при удалении машины");
            }
        }

        public List<Category> Get()
        {
            var categories = context.categories.ToList();
            foreach (var category in categories)
            {
                category.Cars = (from _cars_ in context.cars
                                 where _cars_.CategoryID == category.ID
                                 select _cars_).ToList();
            }

            return categories;
        }

        public Category Get(int ID)
        {
            var category = context.categories.FirstOrDefault(x => x.ID == ID);

            if (category != null)
            {

                category.Cars = (from _cars_ in context.cars
                                 where _cars_.CategoryID == category.ID
                                 select _cars_).ToList();
            }

            return category;
        }

        public void Update(int ID, Category category)
        {
            var Old_Category = context.categories.FirstOrDefault(x => x.ID == ID);

            if (Old_Category == null)
                throw new Exception("Машина с ID:" + ID.ToString() + " не найдена.");

            try
            {
                Old_Category.Name = category.Name;
                //Old_Category.Cars = category.Cars;
                Old_Category.Desc = category.Desc;

                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при обновлении машины");
            }
        }
    }
}
