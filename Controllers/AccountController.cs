using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using resturant.api.Dtos.Account;
using resturant.api.Models;
using resturant.api.Services.Interfaces;

namespace resturant.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ITokenGeneration _token;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(ITokenGeneration token, UserManager<ApplicationUser> userManager)
        {
            _token = token;
            _userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model){
            if(!ModelState.IsValid){
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors)
                                      .Select(e => e.ErrorMessage)
                                      .ToList());
            }
            try {
                 var userExists = await _userManager.FindByEmailAsync(model.Email);
             if (userExists != null)
                return BadRequest("User already exists!");
            
            // Create a new user
            var user = new ApplicationUser
            {
                FullName = model.UserName,
                 UserName = Guid.NewGuid().ToString(),
                 Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);  
            if (!result.Succeeded)
            {
                // Return the errors if user creation failed
                var errors = result.Errors.Select(e => e.Description).ToList();
                return BadRequest(new { Errors = errors });
            }

            return Ok(new { Message = "User registered successfully!" });
            }
           catch(Exception ex){
            return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
           }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model){
            if(!ModelState.IsValid){
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors)
                                      .Select(e => e.ErrorMessage)
                                      .ToList());
            }
            try{
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var tokenString = _token.GenerateAccess(user);
                    return Ok(new { Token = tokenString });
                }

                return Unauthorized(); 
            }
            catch(Exception ex){
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }
    }
}