using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal interface IMenu
    {
        string GetType();
        void ShowMenu();
        string ChoiceMenu();
    }
}
