﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Movies.Core.Domain;
using Movies.Core.Repositories;
using Movies.Infrastructure.LiteDB;

namespace Movies.Infrastructure.Repositories
{
    /// <summary>
    /// No sql database
    /// </summary>
    public class LiteDbMovieRepository : IMovieRepository
    {
        private LiteDatabase _conection;
        private const string tableName = "Movies";
        //private const string databaseName = "DbNoSqlLiteDatabase.db";

        public LiteDbMovieRepository(LiteDbSettings settings)
        {
            _conection = new LiteDatabase(settings.DatabaseName);
        }
        public async Task<Movie> GetMovie(Guid id)
        {
            var colection = _conection.GetCollection<Movie>(tableName);
            return  colection.FindById(id);
        }

        public async Task AddMovie(Movie movie)
        {
            InsertOrUpdate(movie);
        }

        public async Task UpdateMovie(Movie movie)
        {
            InsertOrUpdate(movie);
        }

        public async Task DeleteMovie(Guid id)
        {
            var collection = _conection.GetCollection<Movie>(tableName);
            var row = collection.FindOne(x => x.Id == id);
            collection.Delete(row.Id);
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var colection = _conection.GetCollection<Movie>(tableName);
            return colection.FindAll();
        }

        private void InsertOrUpdate(Movie model)
        {
            var colection = _conection.GetCollection<Movie>(tableName);
            if (colection.Find(x => x.Id == model.Id).Any())
            {
                colection.Update(model);
            }
            else
            {
                colection.Insert(model);
                colection.EnsureIndex(x => x.Title);
            }
        }
    }
}
