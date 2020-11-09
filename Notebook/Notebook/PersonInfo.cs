using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class PersonInfo
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Notes { get; set; }  

        public PersonInfo(string surname, string name, string phone)
        {
            Surname = surname;
            Name = name;
            Phone = phone;
        }
    }
}
