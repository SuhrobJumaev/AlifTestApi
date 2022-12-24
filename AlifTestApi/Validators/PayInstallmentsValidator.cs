using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlifTestApi.Interfaces;
using FluentValidation;
using AlifTestApi.Models;
using AlifTestApi.Helpers;

namespace AlifTestApi.Validators
{
    public class PayInstallmentsValidator : AbstractValidator<PayInstallmentsModel>
    {
        private const string phoneNumberPattern = "^(+992[0-9]{9})$";
        public PayInstallmentsValidator()
        {
            RuleSet("default", () =>
            {
                RuleFor(r => r.ProductId)
                    .NotEmpty().WithMessage(Utils.ProductIdRequired)
                    .Must(BeAValidProductId).WithMessage(Utils.InvalidProductId);

                RuleFor(r => r.Price)
                    .NotEmpty().WithMessage(Utils.PriceRequired)
                    .Must(BeAValidPrice).WithMessage(Utils.InvalidPrice);

                RuleFor(r => r.PhoneNumber)
                    .NotEmpty().WithMessage(Utils.PhoneNumberRequired)
                    .Matches(phoneNumberPattern).WithMessage(Utils.InvalidPhoneNumber);

                RuleFor(r => r.CreditRange)
                   .NotEmpty().WithMessage(Utils.CreditRangeRequired);

            });
        }

        private bool BeAValidProductId(int productId)
        {
            if (productId != Utils.PhoneProduct && productId != Utils.ComputerProduct && productId != Utils.TVProduct)
                return false;
            return true;
        }

        private bool BeAValidPrice(decimal price)
        {
            if (price <= 0)
                return false;
            return true;
        }
    }
}
