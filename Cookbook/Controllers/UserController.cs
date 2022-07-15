using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cookbook.DAL.DbInfrastructure;
using Cookbook.DAL;
using Cookbook.Models;
using Microsoft.AspNetCore.Authorization;
using Cookbook.DTOs;
using Cookbook.Exceptions;

namespace Cookbook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody]UserRegisterDTO user)
        {
            try
            {
                _unitOfWork.UserRepository.Register(user);
                _unitOfWork.Save();
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
