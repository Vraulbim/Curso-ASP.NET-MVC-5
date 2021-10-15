using DevIO.Bussines.Core.Models;
using DevIO.Bussines.Core.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace DevIO.Bussines.Core.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult result)
        {
            foreach (var error in result.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecValidacao<TV, TE>(TV validacao, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entity);

            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }
    }
}
