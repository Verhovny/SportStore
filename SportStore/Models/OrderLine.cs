﻿using System.ComponentModel.DataAnnotations;

namespace SportStore.Models
{
    public class OrderLine
    {
        public long Id { get; set; }
        
        public int Quantity { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }


        public long OrderId { get; set; }
        public Order Order { get; set; }


    }

}