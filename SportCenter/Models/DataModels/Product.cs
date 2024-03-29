﻿namespace SportCenter.Models.DataModels
{
    public class Product : IWithId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
