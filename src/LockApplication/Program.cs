using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace LockApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            new Program().Start();
        }

        GUI Window = new GUI();
        static UserDetails UD;

        public void Start()
        {
            UD = Window.UD;
            string InstructionText = File.ReadAllText("Settings/InstructionBoxText.txt");
            /* Replace identifier with value */
            InstructionText = InstructionText.Replace("%pass%", UD.Password);
            InstructionText = InstructionText.Replace("%hint%", UD.PassHint);
            InstructionText = InstructionText.Replace("%user%", UD.Username);
            /* Set text */
            Window.SetInstructionText(InstructionText);
            /* Window setup/show */
            Window.AddControls();
            Window.Show();
        }
    }
}
