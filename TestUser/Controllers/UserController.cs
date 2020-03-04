using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestUser.MediatR.Queries;
using TestUser.Model;
using TestUser.TestDBContext;
using TestUser.Validator;

namespace TestUser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {        
        // GET: User
        private UserDBContext _context;
        private readonly IMediator _mediator;

        public UserController(UserDBContext context,IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        //Get all the users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers() {
            var query = new GetAllUserQuery();
            var result = await _mediator.Send(query);

            if (result.Count == 0)
            {
                return Content("No users found");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> UserDetails(int id)
        {
            if (!UserExist(id))
            {
                return Content($"User with id no. {id} not found");
            }
            var query = new GetUserDetailQuery(id);
            var result = await _mediator.Send(query);            

            return Ok(result); 
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var query = new PostUserQuery(user);
            var result = await _mediator.Send(query);

            return Content($"Successfuly save user with id: {result.Id}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (!UserExist(id))
            {
                return Content($"User with id no. {id} not found");
            }

            var query = new UpdateUserQuery(user);
            var result = await _mediator.Send(query);

            return Content($"Successfuly updated user with id no. {user.Id}");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            if (!UserExist(id))
            {
                return Content($"User with id no. {id} not found");
            }

            var query = new DeleteUserQuery(id);
            var result = await _mediator.Send(query);

            return Content($"Successfuly deleted user with id no. {id}");
        }              

        //Validate if user exist
        private bool UserExist(long id) =>
         _context.Users.Any(e => e.Id == id);
        
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: User/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: User/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: User/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: User/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }    
}