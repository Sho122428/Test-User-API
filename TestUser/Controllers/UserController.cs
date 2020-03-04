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

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> UserDetails(int id)
        {
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
            var query = new UpdateUserQuery(user);
            var result = await _mediator.Send(query);

            return Content($"Successfuly updated user with id: {user.Id}");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var query = new DeleteUserQuery(id);
            var result = await _mediator.Send(query);

            return Content($"Successfuly deleted user with id: {id}");
        }


        //public IEnumerable<NewUser> GetUsers()
        //{
        //    var userList = _context.Users;
        //    List<NewUser> newUserList = new List<NewUser>();           

        //    foreach (var dtl in userList)
        //    {
        //        NewUser user = new NewUser();

        //        user.Id = dtl.Id;
        //        user.FirstName = dtl.FirstName;
        //        user.LastName = dtl.LastName;

        //        newUserList.Add(user);
        //    }

        //    return newUserList;
        //}


        //Get the specific user
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> UserDetails(int id)
        //{
        //    var userList = _context.Users.Find(id);

        //    if (!UserExist(id))
        //    {
        //        return NotFound();
        //    }

        //    return userList;
        //}

        //Add the new user
        //[HttpPost]
        //public async Task<ActionResult<User>> AddUser(User user)
        //{
        //    //DataValidator validations = new DataValidator();
        //    //validations.Validate(user);

        //    if (UserExist(user.Id))
        //    {
        //        return Content("Id already exist");
        //    }
        //    else {
        //        _context.Users.Add(new User
        //        {
        //            Id = user.Id,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            DateOfBirth = user.DateOfBirth,
        //            IsActive = true,
        //            IsDeleted = false
        //        });

        //        _context.SaveChanges();
        //    }            

        //    return Content($"Successfuly save user with id: {user.Id}");
        //}

        //Update the data of the user
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUser(int id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var userToUpdate = await _context.Users.FindAsync(id);
        //    if (userToUpdate == null)
        //    {
        //        return NotFound();
        //    }

        //    userToUpdate.FirstName = user.FirstName;
        //    userToUpdate.LastName = user.LastName;
        //    userToUpdate.DateOfBirth = user.DateOfBirth;
        //    userToUpdate.IsActive = user.IsActive;
        //    userToUpdate.IsDeleted = user.IsDeleted;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException) when (!UserExist(id))
        //    {
        //        return NotFound();
        //    }

        //    return Content($"Successfuly updated user with id: {user.Id}");
        //}


        //[HttpDelete("{id}")]
        //public async Task<ActionResult<User>> DeleteUser(int id)
        //{
        //    var userToDelete = await _context.Users.FindAsync(id);
        //    if (userToDelete == null)
        //    {
        //        return NotFound();
        //    }
        //    if (userToDelete.IsDeleted)
        //    {
        //        return Content("User is already deleted");
        //    }

        //    userToDelete.IsActive = false;
        //    userToDelete.IsDeleted = true;

        //    //_context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    //return userToDelete;
        //    return Content($"Successfuly deleted user with id: {id}");
        //}

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