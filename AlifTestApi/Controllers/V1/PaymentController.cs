using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlifTestApi.Models;
using AlifTestApi.Interfaces;
using Microsoft.Extensions.Logging;
using FluentValidation;
using FluentValidation.Results;
using AlifTestApi.Helpers;

namespace AlifTestApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/api/payments")]
    public class PaymentController : ControllerBase
    {
        private IValidator<PayInstallmentsModel> _validator;
        private ILogger<PaymentController> _log;
        private IPaymentHelper _paymentHelper;

        public PaymentController(IValidator<PayInstallmentsModel> validator, ILogger<PaymentController> log, IPaymentHelper paymentHelper)
        {
            _validator = validator;
            _log = log;
            _paymentHelper = paymentHelper;
        }

        [HttpPost, Route("payByInstallments")]

        public async Task<IActionResult> PayByInstallmentsAsync(PayInstallmentsModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    return BadRequest(error.ErrorMessage);
                }
            }

            var totalPrice = 0m;
            var totalRangePercent = 0m;

            switch (model.ProductId)
            {
                case Utils.PhoneProduct:
                    totalRangePercent = _paymentHelper.CalculateTotalRangePercent(model.CreditRange, Utils.PhonePercent, Utils.MaxPhoneRange);
                    totalPrice = _paymentHelper.CalculateTotalProductPrice(model.Price, totalRangePercent);
                    break;
                case Utils.ComputerProduct:
                    totalRangePercent = _paymentHelper.CalculateTotalRangePercent(model.CreditRange, Utils.ComputerPercent, Utils.MaxComputerRange);
                    totalPrice = _paymentHelper.CalculateTotalProductPrice(model.Price, totalRangePercent);
                    break;
                case Utils.TVProduct:
                    totalRangePercent = _paymentHelper.CalculateTotalRangePercent(model.CreditRange, Utils.TVPercent, Utils.MaxTVRange);
                    totalPrice = _paymentHelper.CalculateTotalProductPrice(model.Price, totalRangePercent);
                    break;
            }
        
            return Ok(String.Format("Total price is {0}", totalPrice));

        }
    }
}
