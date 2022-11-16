using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportCenter.Models.Identity;
using SportCenter.Models.DataModels;
using SportCenter.Data;
using SportCenter.Converters;
using SportCenter.Managers;

namespace SportCenter.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepository _repository;
        private readonly MembershipManager _membershipManager;

        public MembershipController(UserManager<User> userManager, IRepository repository, MembershipManager membershipManager)
        {
            _userManager = userManager;
            _repository = repository;
            _membershipManager = membershipManager;
        }

        [HttpPost("Set")]
        public async Task<IActionResult> BuyMembership([FromBody] MembershipType type)
        {
            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var membership = await _repository.GetByIdAsync<Membership>(user.MembershipId);

                user.Membership = _membershipManager.GetMembershipByType(type);

                await _userManager.UpdateAsync(user);
                await _repository.RemoveByIdAsync<Membership>(membership.Id);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }     
        }

        [HttpGet("Check")]
        public async Task<IActionResult> CheckMembership()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
       
            var membership = await _repository.GetByIdAsync<Membership>(user.MembershipId);

            var DaysToBurn = membership.ValidityPeriod - (DateTime.Now - membership.DateOfPurchase).Days;

            if (DaysToBurn <= 0)
            {
                user.Membership = new Membership();
                await _userManager.UpdateAsync(user);
                await _repository.RemoveByIdAsync<Membership>(membership.Id);
                return BadRequest(new { Error = "У вас нет активного абонементa!" });
            }
            return Ok(ViewModelConverter.ConvertMembership(membership, DaysToBurn));
        }
    }
}
