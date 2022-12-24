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

namespace AlifTestApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/api/payments")]
    public class PaymentController : ControllerBase
    {
        private IValidator<PayInstallmentsModel> _validator;
        private ILogger<PaymentController> _log;

        public PaymentController(IValidator<PayInstallmentsModel> validator, ILogger<PaymentController> log)
        {
            _validator = validator;
            _log = log;
        }

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

            return Ok();


        }
    }
}
