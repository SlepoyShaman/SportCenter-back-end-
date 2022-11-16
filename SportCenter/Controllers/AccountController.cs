using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportCenter.Models.DataModels;
using SportCenter.Models.ExchangeModels;
using SportCenter.Models.Identity;

namespace SportCenter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] GetRegisterModel model)
        {
            List<string> errors = new List<string>();

            if (ModelState.IsValid)
            {
                var user = new User() { Email = model.Email, UserName = model.Email, Membership = new Membership() };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok();
                }

                foreach (var e in result.Errors)
                    errors.Add(e.Description);
            }

            foreach (var el in ModelState)
                foreach (var error in el.Value.Errors)
                    errors.Add(error.ErrorMessage);

            return BadRequest(errors);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] GetLoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded) return Ok();
            else return BadRequest();
        }
    }
}
