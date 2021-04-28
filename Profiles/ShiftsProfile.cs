using AutoMapper;

namespace cappuccino.shifttracker.Profiles
{
    public class ShiftsProfile: Profile
    {
        public ShiftsProfile()
        {
            CreateMap<Entities.Shift, Models.ShiftDto>();
        }
        
    }
}