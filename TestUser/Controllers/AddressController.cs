using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestUser.Model;
using TestUser.TestDBContext;
using TestUser.Validator;

namespace TestUser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : Controller
    {
        private UserDBContext _context;
        //private AddressValidator addressValidator;

        public AddressController(UserDBContext userDBContext){
            _context = userDBContext;
        }
        [HttpPost]
        public async Task<ActionResult<Address>> AddAddress(Address address)
        {
            //if (UserExist(user.Id))
            //{
            //    return Content("Id already exist");
            //}
            //else
            //{


                _context.Addresses.Add(new Address
                {
                    UserName = address.UserName,
                    UserAddress = address.UserAddress
                });

                _context.SaveChanges();
            //}

            return Content($"Successfuly saved user address for : {address.UserName}");
        }
        //Get all the users
        [HttpGet]
        public IEnumerable<Address> GetAddresses()
        {
            var addressList = _context.Addresses;
            List<Address> newAddressList = new List<Address>();

            foreach (var dtl in addressList)
            {
                Address address = new Address();

                address.ID = dtl.ID;
                address.UserName = dtl.UserName;
                address.UserAddress = dtl.UserAddress;

                newAddressList.Add(address);
            }

            return newAddressList;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}