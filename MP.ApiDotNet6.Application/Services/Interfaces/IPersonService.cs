using MP.ApiDotNet6.Application.DTOs;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
    public interface IPersonService
    {
        /*
         * App recebe os dados da classe Person para ser gravado e devolve PersonDTO
         */
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
    }
}
