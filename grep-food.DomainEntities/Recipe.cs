﻿using System;
using System.Collections.Generic;
using System.Text;

namespace grep_food.DomainEntities
{
    public class Recipe
    {
        public Recipe()
        {
            Id = Guid.NewGuid();

        }

        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public Utilites.Time Time { get; set; }

        public string Instructions { get; set; }
        public List<Guid> IngredientsID { get; set; } //!!!!!

        public string ImagePath { get; set; }
    }
}
