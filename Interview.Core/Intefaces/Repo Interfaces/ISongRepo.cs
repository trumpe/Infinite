using Interview.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.Intefaces.Repo_Interfaces
{
    public interface ISongRepo
    {
        public Song Create(Song song);

        public Song Update(Song song);

        public bool Delete(Song song);

        public Song Get(Guid ID);

        public List<Song> GetAll(Guid user);

    }
}
