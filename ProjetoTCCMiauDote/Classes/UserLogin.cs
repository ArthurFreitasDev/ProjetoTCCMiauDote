using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCCMiauDote.Classes
{
    public class UserLogin
    {
        public string ID { get; private set; }
        public bool IsAuthenticate => !string.IsNullOrEmpty(ID);

        public void ManterLogin(string id)
        {
            ID = id;
        }

        public string GetLogin()
        {
            return ID;
        }

        public void Logout()
        {
            ID = null;
        }
    }
}
