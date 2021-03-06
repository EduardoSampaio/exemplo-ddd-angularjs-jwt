﻿using Desafio.Application.Interfaces;
using Desafio.Application.ViewModels;
using FluentValidation;
using FluentValidation.Results;

namespace Desafio.Service.Validations
{
    public class UserUpdateValidador : AbstractValidator<UserUpdateViewModel>
    {
        private readonly IUserAppService _service;
        public UserUpdateValidador(IUserAppService service)
        {
            _service = service;

            RuleFor(role => role.FirstName)
            .NotNull()
            .NotEmpty().WithMessage("Por favor preencha o nome")
            .MaximumLength(30).WithMessage("Excedeu número de 30 caracteres permitidos");

            RuleFor(role => role.LastName)
             .NotNull()
             .NotEmpty().WithMessage("Por favor preencha o sobrenome")
             .MaximumLength(30).WithMessage("Excedeu número de 30 caracteres permitidos");

            RuleFor(role => role.Cpf)
             .NotNull()
             .NotEmpty().WithMessage("Por favor preencha o cpf")
             .MaximumLength(15).WithMessage("Excedeu número de 15 caracteres permitidos")
             .Matches(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})");


            RuleFor(role => role.Age)
             .NotNull()
             .NotEmpty().WithMessage("Por favor preencha a idade");

            RuleFor(role => role.Nationality)
            .NotNull()
            .NotEmpty().WithMessage("Por favor preencha a nacionalidade")
            .MaximumLength(30).WithMessage("Excedeu número de 30 caracteres permitidos");


            RuleFor(role => role.Phone)
             .NotNull()
             .NotEmpty().WithMessage("Por favor preencha o telefone")
             .MaximumLength(20).WithMessage("Excedeu número de 20 caracteres permitidos");

            RuleFor(role => role.CellPhone)
             .NotNull()
             .NotEmpty().WithMessage("Por favor preencha o celular")
             .MaximumLength(20).WithMessage("Excedeu número de 20 caracteres permitidos");

            RuleFor(role => role.ProfileId)
             .NotNull()
             .NotEmpty().WithMessage("Por favor preencha o perfil");
        }

        public ValidationResult Validation(UserUpdateViewModel model)
        {
            var validator = new UserUpdateValidador(_service);
            return validator.Validate(model); ;
        }
    }
}