﻿using System.ComponentModel.DataAnnotations;

namespace SportStore.Models
{
    public class Category
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

    }

}