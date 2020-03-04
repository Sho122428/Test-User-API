using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestUser.Model
{
    public class NewUser
    {
        int id;
        string firstName;
        string lastName;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}
