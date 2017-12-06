﻿using System;
using System.Collections.Generic;
using System.Text;
using Movies.Infrastructure.DTO;
using Movies.Core.Repositories;
using AutoMapper;
using Movies.Core.Domain;
using Movies.Infrastructure.Commands.Movies;

namespace Movies.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public void CreateMovie(CreateMovie command)
        {
            var movie = Movie.CreateMovie(command.Title, command.DurationMinutes);
            _movieRepository.AddMovie(movie);
        }

        public void DeleteMovie(Guid id)
        {
            _movieRepository.DeleteMovie(id);
        }

        public IEnumerable<MovieDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(_movieRepository.GetAll());
        }

        public MovieDTO GetMovie(Guid id)
        {
            var movie = _movieRepository.GetMovie(id);
            return _mapper.Map<Movie, MovieDTO>(movie);
        }

        public void UpdateMovie(UpdateMovie command)
        {
            var movie = _movieRepository.GetMovie(command.Id);
            movie.Title = command.Title;
            movie.DurationMinutes = command.DurationMinutes;
            _movieRepository.UpdateMovie(movie);
        }
    }
}
