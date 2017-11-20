using System;
namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        //IJokeRepository JokeRepository { get; }

        int Complete();
    }
}
