using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFlashCards2._0.Classes
{
    class User
    {
        private string username { get; set; }
        private string email { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }

        public User()
        {

        }

        public User(string newName, string newEmail, string newFirst, string newLast)
        {
            username = newName;
            email = newEmail;
            firstName = newFirst;
            lastName = newLast;
        }
    }
}
