using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Container : IEntity
    {
        public int Id { get; set; }
        public string ContainerNumber { get; set; }
        public string Size { get; set; }
        public string Frozen { get; set; }
        public string Dangerous { get; set; }
    }
}
