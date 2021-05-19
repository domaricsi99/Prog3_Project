// <copyright file="MapperFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTradingMVC.Web.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;

    /// <summary>
    /// Mapper factory.
    /// </summary>
    public static class MapperFactory
    {
        /// <summary>
        /// Create mapper.
        /// </summary>
        /// <returns>imapper.</returns>
        public static IMapper CreateCryptoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Models.Crypto,
                    Web.Model.Crypto>().ForMember(dest => dest.ID, map => map.MapFrom(src => src.CryptoID)).
                    ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name)).
                    ForMember(dest => dest.ShortName, map => map.MapFrom(src => src.ShortName)).
                    ForMember(dest => dest.Value, map => map.MapFrom(src => src.Value));
            });
            return config.CreateMapper();
        }
    }
}
