using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class PersonInfo 
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

        public static List<PersonInfo> personsList = new List<PersonInfo>();

        #region Metods

        public PersonInfo(string surname, string name, int phone)
        {
            Id = personsCount;
            Surname = surname;
            Name = name;
            Phone = phone;
            personsCount++;
        }

        public static void AddPerson()
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

            Console.WriteLine("Предлагаем Вам ввести дополнительные данные, для выхода введите 0");

            bool end = false;
            while (!end)
            {
                Console.WriteLine("Введите нужное число для редактирования: 1 - Отчество, " +
                    "2 - Дата рождения, 3 - Организация, 4 - Должность, 5 - Заметки. Для завершения введите 0");
                string inputNumber = Console.ReadLine();
                switch (inputNumber)
                {
                    case ("0"):
                        end = true;
                        break;
                    case ("1"):
                        Console.WriteLine("Введите значение отчества");
                        personInfo.SecondName = Console.ReadLine();
                        break;
                    case ("2"):
                        Console.WriteLine("Введите значение дня рождения");
                        personInfo.Birthday = Console.ReadLine();
                        break;
                    case ("3"):
                        Console.WriteLine("Введите значение организации");
                        personInfo.Company = Console.ReadLine();
                        break;
                    case ("4"):
                        Console.WriteLine("Введите значение должности");
                        personInfo.Position = Console.ReadLine();
                        break;
                    case ("5"):
                        Console.WriteLine("Введите заметки");
                        personInfo.Notes = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Введено неверное значение. Попробуйте снвоа");
                        break;
                }
            }

            personsList.Add(personInfo);
        }

        public static void ShowAllInfo(PersonInfo personInfo)
        {
            Console.Write($"ID: {personInfo.Id} Фамилия: {personInfo.Surname} Имя: {personInfo.Name} ");
            if (!String.IsNullOrEmpty(personInfo.SecondName)) { Console.Write($"Отчество: {personInfo.SecondName} "); }
            Console.Write($"Телефон +7{personInfo.Phone} ");
            if (!String.IsNullOrEmpty(personInfo.Birthday)) { Console.Write($"Дата рождения: {personInfo.Birthday} "); }
            if (!String.IsNullOrEmpty(personInfo.Company)) { Console.Write($"Компания: {personInfo.Company} "); }
            if (!String.IsNullOrEmpty(personInfo.Position)) { Console.Write($"Должность: {personInfo.Position} "); }
            if (!String.IsNullOrEmpty(personInfo.Notes)) { Console.Write($"Заметки: {personInfo.Notes} "); }
            Console.WriteLine();
        }

        public static void ShowShortInfo(PersonInfo personInfo)
        {
            Console.WriteLine($"ID: {personInfo.Id} Фамилия: {personInfo.Surname} Имя: {personInfo.Name} +7{personInfo.Phone}");
        }

        public static void CorrectInfo()
        {
            personsList.Sort();
            ShowAllPersons();
            Console.WriteLine("Введите ID человека для редактирования его записи");
            string inputValue = Console.ReadLine();
            int id = CheckForIntIndex(inputValue);

            bool end = false;
            while (!end)
            {
                Console.WriteLine("Введите нужное число для редактирования: 1 - Фамилия, 2 - Имя, 3 - Отчество, 4 - Номер телефона, " +
                    "5 - Дата рождения, 6 - Организация, 7 - Должность, 8 - Заметки. Для завершения введите 0");
                string inputNumber = Console.ReadLine();
                switch (inputNumber)
                {
                    case ("0"):
                        end = true;
                        break;
                    case ("1"):
                        Console.WriteLine("Введите новое значение фамилии");
                        personsList[id].Surname = Console.ReadLine();
                        break;
                    case ("2"):
                        Console.WriteLine("Введите новое значение имени");
                        personsList[id].Name = Console.ReadLine();
                        break;
                    case ("3"):
                        Console.WriteLine("Введите новое значение отчества");
                        personsList[id].SecondName = Console.ReadLine();
                        break;
                    case ("4"):
                        Console.WriteLine("Введите новое значение телефона");
                        bool successPhone = false;
                        int phone = 0;
                        while (successPhone != true)
                        {
                            successPhone = Int32.TryParse(Console.ReadLine(), out int number);
                            if (!successPhone) { Console.WriteLine("Номер введен некорректно. Номер должен состоять только из цифр, записанных без пробела"); }
                            else { phone = number; }
                        }
                        personsList[id].Phone = phone;
                        break;
                    case ("5"):
                        Console.WriteLine("Введите новое значение даты рождения");
                        personsList[id].Birthday = Console.ReadLine();
                        break;
                    case ("6"):
                        Console.WriteLine("Введите новое значение организации");
                        personsList[id].Company = Console.ReadLine();
                        break;
                    case ("7"):
                        Console.WriteLine("Введите новое значение должности");
                        personsList[id].Position = Console.ReadLine();
                        break;
                    case ("8"):
                        Console.WriteLine("Введите новое значение заметок");
                        personsList[id].Notes = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Введено неверное значение. Попробуйте снвоа");
                        break;
                }
            }
            
        }

        public static void DeleteInfo()
        {
            personsList.Sort();
            ShowAllPersons();
            Console.WriteLine("Введите ID человека для удаления его записи");
            string inputValue = Console.ReadLine();
            int id = CheckForIntIndex(inputValue);
            personsList.Remove(personsList[id]);
        }

        public static void ShowAllPersons()
        {
            personsList.Sort();
            foreach(PersonInfo personInfo in personsList)
            {
                ShowShortInfo(personInfo);
            }
        }

        public static int CheckForIntIndex(String inputValue)
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

        public static PersonInfo FindPersonById()
        {
            personsList.Sort();
            ShowAllPersons();
            Console.WriteLine("Введите индекс нужного человека");
            string inputValue = Console.ReadLine();
            int id = CheckForIntIndex(inputValue);
            return personsList[id];
        }


        #endregion
    }
}
