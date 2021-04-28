
using System;
using System.Collections.Generic;
using cappuccino.shifttracker.Entities;

namespace Cappuccino.Shifttracker.Services
{
    public interface ICategoryRepository
    {    
        IEnumerable<Shift> GetShifts();
        IEnumerable<Shift> GetShifts(int categoryId);
        Shift GetShift(int categoryId, int ShiftId);
    //     void AddShift(int categoryId, Shift shift);
    //     void UpdateShift(Shift shift);
    //     void DeleteShift(Shift shift);
        IEnumerable<Category> GetCategories();
        IEnumerable<Category> GetCategories(string letter, string searchQuery);
        Category GetCategory(int categoryId);
    //     IEnumerable<Category> GetCategorys(IEnumerable<int> categoryIds);
    //     void AddCategory(Category category);
    //     void DeleteCategory(Category category);
    //     void UpdateCategory(Category category);
        bool CategoryExists(int categoryId);
    //     bool Save();
    }
}
