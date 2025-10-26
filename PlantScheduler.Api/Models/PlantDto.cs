using System;

namespace PlantScheduler.Api.Models
{
    public class PlantDto
    {
        public required string Name { get; set; }
        public required string Species { get; set; }
        public DateTime LastWatered { get; set; }
    }
}