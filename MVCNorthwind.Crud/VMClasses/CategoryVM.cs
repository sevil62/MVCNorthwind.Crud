﻿using MVCNorthwind.Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNorthwind.Crud.VMClasses
{
    public class CategoryVM
    {
        public Category Category { get; set; }
        public List<Category>Categories  { get; set; }
    }
}