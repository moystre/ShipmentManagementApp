using System;
namespace DemoBLL
{
    public interface IBLLFacade
    {
        IJokeService JokeService { get; }
    }
}
