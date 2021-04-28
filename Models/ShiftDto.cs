using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using cappuccino.shifttracker.Entities;

namespace cappuccino.shifttracker.Models
{
    public class ShiftDto
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Rate { get; set; }
        public decimal? Money { get; set; }

    }
}