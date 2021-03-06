﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Peanut.Data.Models;
using Peanut.Services.Mapping;

namespace Peanut.Services.Models.Categories
{
    public class CategoryIdAndNameViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameAndCount =>
            $"{this.Name} ({this.CountOfAllSayings})";

        // SayingsCount
        public int CountOfAllSayings { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Category, CategoryIdAndNameViewModel>()
                .ForMember(x => x.CountOfAllSayings,
                    m => m.MapFrom(c => c.Sayings.Count()));
        }
    }
}