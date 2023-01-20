using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<PersonDTO, Person>();
        }
    }
}
