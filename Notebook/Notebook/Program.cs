using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует Ваш личный помощник, какое действие вы бы хотели сделать?? Для завершения работы со мной введите 0");
            string inputString = "-1";
            while(inputString != "0")
            {
                Console.WriteLine("Введите 1 - для добавления записи, 2 - для редактирования записи, 3 - для удаления записи," +
                    "4 - для просмотра учетной записи, 5 - для просмотра всех учетных записей");
                inputString = Console.ReadLine();
                switch (inputString)
                {
                    case ("1"):
                        PersonInfo.AddPerson();
                        break;
                    case ("2"):
                        PersonInfo.CorrectInfo();
                        break;
                    case ("3"):
                        PersonInfo.DeleteInfo();
                        break;
                    case ("4"):
                        PersonInfo.ShowAllInfo(PersonInfo.FindPersonById());
                        break;
                    case ("5"):
                        PersonInfo.ShowAllPersons();
                        break;
                }
            }
        }
    }
}
