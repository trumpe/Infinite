using Interview.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.Intefaces
{
    public interface ISongService
    {
        public SongDto Create(SongDto songDto);
        public List<SongDto> GetSongs(Guid user);

    }
}
