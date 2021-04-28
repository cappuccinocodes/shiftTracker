using AutoMapper;

namespace cappuccino.shifttracker.Profiles
{
    public class CategoriesProfile: Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Entities.Category, Models.CategoryDto>();
        }
        
    }
}