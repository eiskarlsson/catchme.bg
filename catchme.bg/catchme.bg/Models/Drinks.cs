﻿namespace catchme.bg.Models
{
    public class Drinks : IProfileItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
    }
}