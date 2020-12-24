using Interview.Core.Context;
using Interview.Core.Entities;
using Interview.Core.Intefaces.Repo_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview.Core.Repos
{
    public class SongRepo : ISongRepo
    {
        private readonly DatabaseContext _context;

        public SongRepo(DatabaseContext context)
        {
            _context = context;
        }

        public Song Create(Song song)
        {
            var created = _context.Songs.Add(song).Entity;
            _context.SaveChanges();
            return created;
        }
        public Song Update(Song song)
        {
            var updated = _context.Songs.Update(song).Entity;
            _context.SaveChanges();
            return updated;
        }
        public bool Delete(Song song)
        {
            _context.Songs.Remove(song);
            _context.SaveChanges();
            return true;
        }
        public Song Get(Guid ID)
        {
            var created = _context.Songs.FirstOrDefault(x => x.ID == ID);
            return created;
        }
        public List<Song> GetAll(Guid user)
        {
            var songs = _context.Songs.Where(x => x.UserID == user).ToList();
            return songs;
        }

        ~SongRepo()
        {
            _context.Dispose();
        }
    }
}
