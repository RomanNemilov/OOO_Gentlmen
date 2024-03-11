using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using OOO_Gentlmen;

namespace OOO_Gentlmen.Classes
{
    public class Helper
    {
        public static Order Order { get; set; }

        public static Model.dbGentlmen DB { get; set; }

        //Пользователь который вошёл в систему
        public static Model.User User { get; set; }
    }
}
