using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{
    public class PersonMan
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Id { get; set; }

        public string PhoneNo { get; set; }

        public override string ToString()
        {
            return $"{Id}, {FirstName} {LastName}, {PhoneNo}";
        }
    }
}
