﻿using BangaloreWalks.api.Models.Domain;
 
namespace BangaloreWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public required string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }


        // Navigation properties
        public required Difficulty Difficulty { get; set; }
        public required Region Region { get; set; }
    }
}