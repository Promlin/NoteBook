﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class PersonInfo : IPersonInfo
    {
        #region values
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Notes { get; set; }

        public int personsCount = 0;
        #endregion

        public List<PersonInfo> personsList = new List<PersonInfo>();

        #region Metods

        public PersonInfo(string surname, string name, int phone)
        {
            Id = personsCount;
            Surname = surname;
            Name = name;
            Phone = phone;
            personsCount++;
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
            Console.WriteLine($"ID: {personInfo.Id} Фамилия: {personInfo.Surname} Имя: {personInfo.Name} +7{personInfo.Phone}");
        }

        public void CorrectInfo()
        {
            throw new NotImplementedException();
        }

        public void DeleteInfo()
        {
            personsList.Sort();
            ShowAllPersons();
            Console.WriteLine("Введите ID человека для удаления его записи");
            int id = 0;
            bool success = true;
            while (!success)
            {
                success = Int32.TryParse(Console.ReadLine(), out int index);
                if (success) { id = index; }
                else { Console.WriteLine("Введено неверное значение. Попробуйте еще раз"); }
            }
            if (personsList.Contains(personsList[id]))
            {
                personsList.Remove(personsList[id]);
            }
            else
            {
                Console.WriteLine($"В списке нет человека с индексом {id}");
            }
            
        }

        public void ShowAllPersons()
        {
            personsList.Sort();
            foreach(PersonInfo personInfo in personsList)
            {
                ShowShortInfo(personInfo);
            }
        }
        #endregion
    }
}
