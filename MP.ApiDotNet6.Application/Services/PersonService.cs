using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Application.DTOs.Validations;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Application.Services
{
    public class PersonService : IPersonService
    {
        /*
         * Colocar quais as Interfaces que serão utilizadas PersonRepositories e o Map,
         * mapeando a classe que esta vindo(DTO), transformando ela na classe Person, 
         * devolvendo a DTO.
         */
        private readonly IPersonRepository _personRepository;

        // Biblioteca que transforma uma classe ma outra (somente Atributos iguais)
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                ResultService.Fail<PersonDTO>("Objeto deve ser informado!");

            // Verifica se todos os objetos são válidos
            var result = new PersonDTOValidator().Validate(personDTO);
            if (! result.IsValid)
                return ResultService.RequestError<PersonDTO>("Problemas de validação!", result);

            /*
             * Transforma a personDTO em Entidade (person)
             * Cria um objeto no DB e retorna o ID (data)
             * Retorna para a aplicação este ID, para eventualmente ser demonstrado para o usuário o sucesso da ação (return)
             */
            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);

            return ResultService.OK<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }
    }
}
