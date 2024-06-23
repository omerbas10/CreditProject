using Microsoft.AspNetCore.Mvc;
using CreditApp.Services;

namespace CreditApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BanksController : ControllerBase
    {
        private readonly BankService _bankService;

        public BanksController(BankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public IActionResult GetBanks()
        {
            var banks = _bankService.GetBanks();
            return Ok(banks);
        }
    }
}
