using System;
namespace DemoDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IJokeRepository JokeRepository { get; }

        int Complete();
    }
}
