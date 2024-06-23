using Microsoft.AspNetCore.Mvc;
using CreditApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace CreditApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly CardService _cardService;

        public CardsController(CardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public IActionResult GetCards([FromQuery] bool? isBlocked, [FromQuery] string cardNumber, [FromQuery] int? bankCode)
        {
            var user = HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
            
            var cards = _cardService.GetCards(isBlocked, cardNumber, bankCode);
            return Ok(cards);
        }

        [HttpPost("increase-limit")]
        public IActionResult IncreaseCreditLimit([FromBody] CreditLimitRequest request)
        {

            var user = HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
            return Unauthorized(new { message = "Unauthorized" });
            }

            var success = _cardService.IncreaseCreditLimit(request.CardNumber, request.RequestedLimit, request.Occupation, request.MonthlyIncome);
            if (success)
            {
                return Ok(new { success = true, message = "הגדלת מסגרת בוצעה בהצלחה" });
            }
            return Ok(new { success = false, message = "הגדלת מסגרת נכשלה" });
        }
    }

    public class CreditLimitRequest
    {
        public string CardNumber { get; set; }
        public decimal RequestedLimit { get; set; }
        public string Occupation { get; set; }
        public decimal MonthlyIncome { get; set; }
    }
}
