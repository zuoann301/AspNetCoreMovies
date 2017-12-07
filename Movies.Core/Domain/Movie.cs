﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double DurationMinutes { get; set; }

        protected Movie()
        {
            Id = Guid.NewGuid();
        }

        public Movie(string title, double durationMinutes)
        {
            Id = Guid.NewGuid();
            Title = title;
            DurationMinutes = durationMinutes;
        }

        public static async Task<Movie> CreateMovie(string title, double durationMinutes)
        {
            return new Movie(title, durationMinutes);
        }
    }
}
