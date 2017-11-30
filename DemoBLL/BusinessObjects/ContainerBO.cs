using DemoBLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class ContainerBO : IBusinessObject
    {
        public int Id { get; set; }
        public string ContainerNumber { get; set; }
        public string Size { get; set; }
        public string Frozen { get; set; }
        public string Dangerous { get; set; }
    }
}
