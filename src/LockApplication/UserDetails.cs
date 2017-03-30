using System;
using System.Security;
using System.IO;
using System.Text;

namespace LockApplication
{
    public class UserDetails
    {
        public string Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string Password = File.ReadAllText("Settings/Password.txt").Replace(Environment.NewLine, "");
        public string PassHint = File.ReadAllText("Settings/Hint.txt");
    }
}

