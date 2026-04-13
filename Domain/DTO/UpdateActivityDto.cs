using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UpdateActivityDto
    {
        //public string Title { get; set; }
        //public string Venue { get; set; }
        //public bool IsCancelled { get; set; }
        //public string City { get; set; }
        //public double Latitude { get; set; }
        //public double Longitude { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsCancelled { get; set; }
        public required string Category { get; set; }

        //Location
        public required string City { get; set; }
        public required string Venue { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
