using AutoMapper;
using Interview.Core.Dtos;
using Interview.Core.Entities;
using Interview.Core.Intefaces;
using Interview.Core.Intefaces.AutoMaper_interface;
using Interview.Core.Intefaces.Repo_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepo _songRepo;
        private readonly IMapper _autoMapper;

        public SongService(IAutoMapper autoMapper, ISongRepo songRepo)
        {
            _autoMapper = autoMapper.Get();
            _songRepo = songRepo;
        }

        public SongDto Create(SongDto songDto)
        {

            var song = _autoMapper.Map<SongDto, Song>(songDto);
            song = _songRepo.Create(song);
            return _autoMapper.Map<Song, SongDto>(song);

        }
        public List<SongDto> GetSongs(Guid user)
        {
            var songs = _songRepo.GetAll(user);
            var songsDto = new List<SongDto>();
            foreach (var song in songs)
            {
                songsDto.Add(_autoMapper.Map<Song, SongDto>(song));
            }
            return songsDto;
        }

    }
}
