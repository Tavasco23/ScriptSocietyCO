﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ScriptSocietyCO.Models
{
    public class Script
    {
        [Key]
        public int ProductId { get; set; }

       
        public string Name { get; set; }

      
        public string Type { get; set; }

        
        public string Color { get; set; }


        public double Price { get; set; }

       
        public string Size { get; set; }

  
        public int StockTotal { get; set; }

   

  
    
    }
}
