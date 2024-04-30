using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVVMProject.Models
{
    public class Person
    {

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime Birthday { get; set; }

        public override string ToString() => $"{Name}";

        public override bool Equals(object? obj)
        {
            Person person = obj as Person;
            if (person.Name==Name && person.Surname==Surname && person.Email==Email && person.Phone==Phone &&  person.Birthday==Birthday)
            {
                return true;
            }
            else return false;
        }
    }
}
