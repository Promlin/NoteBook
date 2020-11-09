using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class PersonInfo : IPersonInfo
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Notes { get; set; }

        public List<PersonInfo> personsList = new List<PersonInfo>();

        public PersonInfo(string surname, string name, int phone)
        {
            Surname = surname;
            Name = name;
            Phone = phone;
        }

        public void AddPerson()
        {
            Console.WriteLine("Введите фамилию человека: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Ведите имя человека:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите телефон после +7: ");
            bool success = false;
            int phone = 0;
            while(success != true)
            {
                success = Int32.TryParse(Console.ReadLine(), out int number);
                if (!success) { Console.WriteLine("Номер введен некорректно. Номер должен состоять только из цифр, записанных без пробела"); }
                else { phone = number; }
            }
            PersonInfo personInfo = new PersonInfo(surname, name, phone);
            personsList.Add(personInfo);
        }

        public void ShowAllInfo(PersonInfo personInfo)
        {
            throw new NotImplementedException();
        }

        public void ShowShortInfo(PersonInfo personInfo)
        {
            throw new NotImplementedException();
        }

        public void CorrectInfo()
        {
            throw new NotImplementedException();
        }

        public void DeleteInfo()
        {
            throw new NotImplementedException();
        }

        public void ShowAllPersons()
        {
            throw new NotImplementedException();
        }
    }
}
