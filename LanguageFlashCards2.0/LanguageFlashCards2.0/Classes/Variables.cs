using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFlashCards2._0.Classes
{
    class Variables
    {
        public static string connectionString { get; set; }
        public static DBController dBController { get; set; }
        public static User currentUser { get; set; }
        public static bool validUser { get; set; }
        public static int flashCardMode { get; set; }
        public static int flashCardCount { get; set; }

    }
}
