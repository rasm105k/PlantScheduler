using System;

namespace PlantScheduler.Api.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Species { get; set; }
        public DateTime LastWatered { get; set; }
    }
}