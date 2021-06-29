using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cookbook.DbInfrastructure;
using Cookbook.Entities.Models;
using Cookbook.Dtos;

namespace Cookbook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public UsersController()
        {
            _unitOfWork = new UnitOfWork();
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserDto> GetUsers()
        {
            var users = _unitOfWork.Users
                .GetAll()
                .Select( item => item.ToDto() )
                .ToList();
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser( int id )
        {
            var user = _unitOfWork.Users.Get( id );

            if (user == null)
            {
                return NotFound();
            }

            return user.ToDto();
        }

        //// PUT: api/Users/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Users
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.Id }, user);
        //}

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser( int id )
        {
            var user = _unitOfWork.Users.Get( id );

            if (user == null)
            {
                return NotFound();
            }

            _unitOfWork.Users.Remove( user );
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        //private bool UserExists(int id)
        //{
        //    return _context.Users.Any(e => e.Id == id);
        //}
    }
}
