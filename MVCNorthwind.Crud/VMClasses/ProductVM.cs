using MVCNorthwind.Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNorthwind.Crud.VMClasses
{
    public class ProductVM
    {
        public  Product Product { get; set; }

        public  List<Product>Products { get; set; }
       
        public  List<Category>Categories { get; set; }
    }
}