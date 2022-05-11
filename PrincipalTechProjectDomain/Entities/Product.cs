using System;
using System.Collections.Generic;
using System.Text;

namespace PrincipalTechProject.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Category { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
