﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Dal.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }
        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
