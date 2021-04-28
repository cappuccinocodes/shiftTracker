
using System;
using System.Collections.Generic;
using System.Linq;
using API.DbContexts;
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

    //     public void AddCategory(Author author)
    //     {
    //         if (author == null)
    //         {
    //             throw new ArgumentNullException(nameof(author));
    //         }

    //         // the repository fills the id (instead of using identity columns)
    //         author.Id = int.Newint();

    //         foreach (var Shift in author.Shifts)
    //         {
    //             Shift.Id = int.Newint();
    //         }

    //         _context.Categories.Add(author);
    //     }

        public bool CategoryExists(int categoryId)
        {
            if (categoryId == 0)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            return _context.Categories.Any(a => a.Id == categoryId);
        }

    //     public void DeleteCategory(Author author)
    //     {
    //         if (author == null)
    //         {
    //             throw new ArgumentNullException(nameof(author));
    //         }

    //         _context.Categories.Remove(author);
    //     }
        
        public Category GetCategory(int categoryId)
        {
            return _context.Categories.FirstOrDefault(a => a.Id == categoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList<Category>();
        }

        public IEnumerable<Category> GetCategories(string letter, string searchQuery)
        {
            if(string.IsNullOrWhiteSpace(letter)
            && string.IsNullOrWhiteSpace(searchQuery))
            {
                return GetCategories();
            }

            var collection = _context.Categories as IQueryable<Category>; 

             if(!string.IsNullOrWhiteSpace(letter))
            {
                collection  = collection.Where(c => c.Name.Contains(letter)); 
            }

             if(!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
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

    //     public void UpdateCategory(Author author)
    //     {
    //         // no code in this implementation
    //     }

    //     public bool Save()
    //     {
    //         return (_context.SaveChanges() >= 0);
    //     }

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
