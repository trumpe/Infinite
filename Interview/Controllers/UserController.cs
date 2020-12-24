using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Interview.Api.ApiModels;
using Interview.Core.Authentication;
using Interview.Core.Dtos;
using Interview.Core.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Interview.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly ISongService _songService;
        private readonly IUserService _userService;

        public UserController(IJwtAuthenticationManager jwtAuthenticationManager,ISongService songService,IUserService userService)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _songService = songService;
            _userService = userService;
        }
        
        [HttpPost("song")]
        public IActionResult PostSong([FromBody] SongApiModel song)
        {
            string username = User.FindFirst(ClaimTypes.Name)?.Value;
            var user = _userService.GetUserByName(username);


            var songDto = new SongDto()
            {
                Author = song.Author,
                Description = song.Description,
                Title = song.Title,
                UserID = user.ID
            };
            try
            {
                var created = _songService.Create(songDto);
                return Ok(created);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           

           
        }

        [HttpGet("songs")]
        public IEnumerable<SongDto> GetMySongs()
        {
            string username = User.FindFirst(ClaimTypes.Name)?.Value;           
            var user = _userService.GetUserByName(username);            
            return _songService.GetSongs(user.ID);
          
        }
        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] Login login)
        {
            var user = new UserDto()
            {
                Username = login.Username,
                Password = login.Password
            };
            user = _userService.Create(user);
            if (user== null)
            {
                return BadRequest("Username is already taken");
            }
            return Ok("Successfuly Created!");
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public IActionResult Signin([FromBody] Login login)
        {            
            if (!_userService.LogIn(login.Username, login.Password))
            {
                return Unauthorized("Username and password don't mach");
            }
            var token = _jwtAuthenticationManager.Authenticate(login.Username, login.Password);
            LoginRespose response = new LoginRespose()
            {
                Username = login.Username,
                Token = token
            };
            return Ok(response);
        }
       
    }
}
