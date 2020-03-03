using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestUser.Model
{
    public class Address
    {
        int id;
        string userName;
        string address;

        public int ID {
            get { return id; }
            set { id = value; }

        }
        public string UserName {
            get { return userName; }
            set { userName = value; }
        }

        public string UserAddress {
            get { return address; }
            set { address = value; }
        }
    }
}
