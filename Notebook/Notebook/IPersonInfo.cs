using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public interface IPersonInfo
    {
        void AddPerson();
        void ShowAllInfo(PersonInfo personInfo);
        void ShowShortInfo(PersonInfo personInfo);
        void CorrectInfo();
        void DeleteInfo();
        void ShowAllPersons();
    }
}
