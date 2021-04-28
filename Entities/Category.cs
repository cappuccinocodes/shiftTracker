

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace cappuccino.shifttracker.Entities
{
    public class Category
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Shift> Shifts { get; set; }
    }
}