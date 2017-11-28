﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Movies.Core.Domain;
using Movies.Infrastructure.DTO;

namespace Movies.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
           => new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Movie, MovieDTO>();
           })
            .CreateMapper();
        /*Mogłby zwracać tablicę konfiguracji, która teraz jest ładowana do MapperConfiguration i tworzony mapper.
         W Webowej uzupełnić tablicę i dopiero utworzyć mappera.*/

        public static Action<IMapperConfigurationExpression> GetMapperConfigurationExpression() =>
            (cfg) => { cfg.CreateMap<Movie, MovieDTO>(); };
            
    }
}
