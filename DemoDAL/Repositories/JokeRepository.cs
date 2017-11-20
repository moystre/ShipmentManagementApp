using System;
using System.Collections.Generic;
using System.Linq;
using DemoDAL.Context;
using DemoDAL.Entities;

namespace DemoDAL.Repositories
{
    class JokeRepository : IJokeRepository
    {
        EASVContext _context;
        public JokeRepository(EASVContext context)
        {
            _context = context;
        }

        public Joke Create(Joke joke)
        {
            _context.Jokes.Add(joke);
            return joke;
        }

        public Joke Delete(int Id)
        {
            var jokeToDelete = _context.Jokes.FirstOrDefault(
                    j => j.Id == Id
            );
            _context.Jokes.Remove(jokeToDelete);
            return jokeToDelete;
        }

        public Joke Get(int Id)
        {
            return _context.Jokes.FirstOrDefault(j => j.Id == Id);
        }

        public IEnumerable<Joke> GetAll()
        {
            return _context.Jokes;
        }

        public IEnumerable<Joke> GetAllById(List<int> ids)
        {
            if(ids == null){
                return null;
            }
            return _context.Jokes.Where(j => ids.Contains(j.Id) );

        }
    }
}
