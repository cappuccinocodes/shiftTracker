
using System;
using System.Collections.Generic;
using System.Linq;
using API.DbContexts;
using cappuccino.shifttracker.Controllers;
using cappuccino.shifttracker.Entities;
using Cappuccino.Shifttracker.Services;

namespace Cappuccino.Shifttracker.Services
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

    //     public void AddShift(int categoryId, Shift Shift)
    //     {
    //         if (categoryId == int.Empty)
    //         {
    //             throw new ArgumentNullException(nameof(categoryId));
    //         }

    //         if (Shift == null)
    //         {
    //             throw new ArgumentNullException(nameof(Shift));
    //         }
    //         // always set the categoryId to the passed-in categoryId
    //         Shift.categoryId = categoryId;
    //         _context.Shifts.Add(Shift); 
    //     }         

    //     public void DeleteShift(Shift Shift)
    //     {
    //         _context.Shifts.Remove(Shift);
    //     }
  
        public Shift GetShift(int categoryId, int shiftId)
        {
            if (categoryId == 0)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            if (shiftId == 0)
            {
                throw new ArgumentNullException(nameof(shiftId));
            }

            return _context.Shifts
              .Where(s => s.CategoryId == categoryId && s.Id == shiftId).FirstOrDefault();
        }

        public IEnumerable<Shift> GetShifts(int categoryId)
        {
            if (categoryId == 0)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            return _context.Shifts
                        .Where(s => s.CategoryId == categoryId)
                        .OrderBy(s => s.Id).ToList();
        }

        public IEnumerable<Shift> GetShifts()
        {

            return _context.Shifts.OrderBy(s => s.Id).ToList();
        }

    //     public void UpdateShift(Shift Shift)
    //     {
    //         // no code in this implementation
    //     }

        public void AddCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            // the repository fills the id (instead of using identity columns)
            // category.Id = int.Newint();

            // foreach (var Shift in category.Shifts)
            // {
            //     Shift.Id = int.Newint();
            // }

            _context.Categories.Add(category);
        }

        public bool CategoryExists(int categoryId)
        {
            if (categoryId == 0)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            return _context.Categories.Any(a => a.Id == categoryId);
        }

    //     public void DeleteCategory(Author category)
    //     {
    //         if (author == null)
    //         {
    //             throw new ArgumentNullException(nameof(category));
    //         }

    //         _context.Categories.Remove(category);
    //     }
        
        public Category GetCategory(int categoryId)
        {
            return _context.Categories.FirstOrDefault(a => a.Id == categoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList<Category>();
        }

        public IEnumerable<Category> GetCategories(CategoriesResourceParameters categoriesResourceParameters)
        {
            if (categoriesResourceParameters == null )
            {
                throw new ArgumentNullException(nameof(categoriesResourceParameters));
            }

            if(string.IsNullOrWhiteSpace(categoriesResourceParameters.Letter)
            && string.IsNullOrWhiteSpace(categoriesResourceParameters.SearchQuery))
            {
                return GetCategories();
            }

            var collection = _context.Categories as IQueryable<Category>; 

             if(!string.IsNullOrWhiteSpace(categoriesResourceParameters.Letter))
            {
                var letter = categoriesResourceParameters.Letter.Trim();
                collection  = collection.Where(c => c.Name.Contains(letter)); 
            }

             if(!string.IsNullOrWhiteSpace(categoriesResourceParameters.SearchQuery))
            {
                var searchQuery = categoriesResourceParameters.SearchQuery.Trim();
                collection = collection.Where(c => c.Name.Contains(searchQuery)
                     //|| c.AnyOtherProperty.Contains(searchquery) <<< SUPER INTERESTING
);
            }

            return collection.ToList();
        }
         
    //     public IEnumerable<Category> GetCategories(IEnumerable<int> categoryIds)
    //     {
    //         if (categoryIds == null)
    //         {
    //             throw new ArgumentNullException(nameof(categoryIds));
    //         }

    //         return _context.Categories.Where(a => categoryIds.Contains(a.Id))
    //             .OrderBy(a => a.FirstName)
    //             .OrderBy(a => a.LastName)
    //             .ToList();
    //     }

    //     public void UpdateCategory(Author category)
    //     {
    //         // no code in this implementation
    //     }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               // dispose resources when needed
            }
        }
    }
}
