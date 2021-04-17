using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace BLayer.Interfaces
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Update(int Id, Category category);
        void Delete(int ID);
        List<Category> Get();
        Category Get(int ID);
    }
}
