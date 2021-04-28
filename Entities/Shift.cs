using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cappuccino.shifttracker.Entities
{
    public class Shift
    {
        [Key]       
        public int Id { get; set; }
        public int CategoryId {get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int LocationId {get; set; }
        public DateTime Start {get; set; }
        public DateTime End {get; set; }
        public TimeSpan Duration {get; set; }
        public decimal Rate{get; set;}
        public decimal? Money { get; set; }
    }
}
