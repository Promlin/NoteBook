using System;
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
        public string Birthday { get; set; }
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

            Console.WriteLine("Вы хотите ввести Отчество?  Нет - 0, Да - 1");
            string inputString = Console.ReadLine();
            int answer = CheckForInputValue(inputString);
            if(answer == 1)
            {
                Console.WriteLine("Введите отчество рождения:");
                personInfo.SecondName = Console.ReadLine();
            }

            Console.WriteLine("Вы хотите ввести дату рождения?  Нет - 0, Да - 1");
            inputString = Console.ReadLine();
            answer = CheckForInputValue(inputString);
            if (answer == 1)
            {
                Console.WriteLine("Введите дату рождения:");
                personInfo.Birthday = Console.ReadLine();
            }

            Console.WriteLine("Вы хотите ввести организацию?  Нет - 0, Да - 1");
            inputString = Console.ReadLine();
            answer = CheckForInputValue(inputString);
            if (answer == 1)
            {
                Console.WriteLine("Введите организацию:");
                personInfo.Company = Console.ReadLine();
            }

            Console.WriteLine("Вы хотите ввести должность?  Нет - 0, Да - 1");
            inputString = Console.ReadLine();
            answer = CheckForInputValue(inputString);
            if (answer == 1)
            {
                Console.WriteLine("Введите должность:");
                personInfo.Position = Console.ReadLine();
            }

            Console.WriteLine("Вы хотите ввести дополнительные заметки?  Нет - 0, Да - 1");
            inputString = Console.ReadLine();
            answer = CheckForInputValue(inputString);
            if (answer == 1)
            {
                Console.WriteLine("Введите заметки:");
                personInfo.Notes = Console.ReadLine();
            }
        }

        public void ShowAllInfo(PersonInfo personInfo)
        {
            Console.Write($"ID: {personInfo.Id} Фамилия: {personInfo.Surname} Имя: {personInfo.Name} ");
            if (!String.IsNullOrEmpty(personInfo.SecondName)) { Console.Write($"Отчество: {personInfo.SecondName} "); }
            Console.Write($"Телефон +7{personInfo.Phone} ");
            if (!String.IsNullOrEmpty(personInfo.Birthday)) { Console.Write($"Дата рождения: {personInfo.Birthday} "); }
            if (!String.IsNullOrEmpty(personInfo.Company)) { Console.Write($"Компания: {personInfo.Company} "); }
            if (!String.IsNullOrEmpty(personInfo.Position)) { Console.Write($"Должность: {personInfo.Position} "); }
            if (!String.IsNullOrEmpty(personInfo.Notes)) { Console.Write($"Заметки: {personInfo.Notes} "); }
        }

        public void ShowShortInfo(PersonInfo personInfo)
        {
            Console.WriteLine($"ID: {personInfo.Id} Фамилия: {personInfo.Surname} Имя: {personInfo.Name} +7{personInfo.Phone}");
        }

        public void CorrectInfo()
        {
            personsList.Sort();
            ShowAllPersons();
            Console.WriteLine("Введите ID человека для редактирования его записи");
            string inputValue = Console.ReadLine();
            int id = CheckForIntIndex(inputValue);

            Console.WriteLine("");
        }

        public void DeleteInfo()
        {
            personsList.Sort();
            ShowAllPersons();
            Console.WriteLine("Введите ID человека для удаления его записи");
            string inputValue = Console.ReadLine();
            int id = CheckForIntIndex(inputValue);
            personsList.Remove(personsList[id]);
        }

        public void ShowAllPersons()
        {
            personsList.Sort();
            foreach(PersonInfo personInfo in personsList)
            {
                ShowShortInfo(personInfo);
            }
        }

        public int CheckForIntIndex(String inputValue)
        {
            int id = 0;
            bool success = true;
            while (!success)
            {
                success = Int32.TryParse(inputValue, out int index);
                if (success) 
                {
                    if (!personsList.Contains(personsList[id]))
                    {
                        Console.WriteLine($"В списке нет человека с индексом {id}");
                    }
                    else
                    {
                        id = index;
                    }
                }
                else { Console.WriteLine("Введено неверное значение. Попробуйте еще раз"); }
            }
            
            return id;
        }

        public PersonInfo FindPersonById()
        {
            personsList.Sort();
            ShowAllPersons();
            Console.WriteLine("Введите индекс нужного человека");
            string inputValue = Console.ReadLine();
            int id = CheckForIntIndex(inputValue);
            return personsList[id];
        }

        public int CheckForInputValue(string value)
        {
            bool success = false;
            while (!success)
            {
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case ("0"):
                        success = true;
                        return 0;
                    case ("1"):
                        success = true;
                        return 1;
                    default:
                        Console.WriteLine("Указано неверное значение, попробуйте еще раз");
                        break;
                }
            }
            return 0;
        }

        #endregion
    }
}
