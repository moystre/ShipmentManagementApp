using System;
namespace DemoDAL.Entities
{
    public class Joke : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Funny { get; set; }
    }
}
