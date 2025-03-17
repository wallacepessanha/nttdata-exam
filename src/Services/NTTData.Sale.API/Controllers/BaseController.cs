using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NTTData.Core.CommunicationResponse;

namespace NTTData.Sale.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object? result = null)
        {
            if (ValidOperation())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AddProcessError(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AddProcessError(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult resposta)
        {
            ResponseHasErrors(resposta);

            return CustomResponse();
        }

        protected bool ResponseHasErrors(ResponseResult resposta)
        {
            if (resposta == null || !resposta.Errors.Messages.Any()) return false;

            foreach (var mensagem in resposta.Errors.Messages)
            {
                AddProcessError(mensagem);
            }

            return true;
        }

        protected bool ValidOperation()
        {
            return !Errors.Any();
        }

        protected void AddProcessError(string erro)
        {
            Errors.Add(erro);
        }

        protected void CleanProcessError()
        {
            Errors.Clear();
        }
    }
}
