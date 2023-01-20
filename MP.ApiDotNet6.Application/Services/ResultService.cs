using FluentValidation.Results;

namespace MP.ApiDotNet6.Application.Services
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ICollection<ErrorValidation> Errors { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        // Tratativas de Erros de requisição
        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        /*
         *  Classes para Falha
         */
        public static ResultService Fail(string message) => new ResultService { IsSuccess = false, Message = message };

        public static ResultService<T> Fail<T>(string message) => new ResultService<T> { IsSuccess = false, Message = message };

        /*
         *  Classes para Sucesso
         */
        public static ResultService OK(string message) => new ResultService { IsSuccess = true, Message = message };

        public static ResultService<T> OK<T>(T data) => new ResultService<T> { IsSuccess = true, Data = data };
    }
    /* 
     * Criação de uma classe, Tipo genérico (T)
     */
    public class ResultService<T> : ResultService
    {
        /*
         * Classe T, Tipo: Dados (Data)
         * Possíveis retornos de objetos, listas, classes que teremos
         * Desta forma conseguimos passar diversos tipos de retorno
         */
        public T Data { get; set; }
    }
}