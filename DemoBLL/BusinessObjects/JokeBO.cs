using System;
namespace DemoBLL.BusinessObjects
{
    public class JokeBO : IBusinessObject
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Funny { get; set; }
    }
}
