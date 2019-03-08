using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Core.Domain;
using Task.Core.Infrastructure.Mapper;
using Task.Models;

namespace Task.Infrastructure.Mapper
{
    public class AdminMapperConfiguration : Profile, IOrderedMapperProfile
    {
        protected virtual void CreateCatalogMaps()
        {
            CreateMap<NaseejProduct, ProductModel>().ReverseMap();
        }

        #region Properties
        /// <summary>
        /// Order of th
        public int Order => 0;
        #endregion
    }
}
