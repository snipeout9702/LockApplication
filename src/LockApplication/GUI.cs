using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace LockApplication
{
    public class GUI
    {
        public UserDetails UD = new UserDetails();

        /* Form */
        public Form Window = new Form()
        {
                Text = "LockScreen"
        };
        // Adds defined controls to the form
        public void AddControls()
        {
            InstructionBox.SelectAll();
            InstructionBox.SelectionAlignment = HorizontalAlignment.Center;
            InstructionBox.DeselectAll();
            InstructionBox.ReadOnly = true;
            PassBox.TextChanged += PassTextChanged;
            Window.Controls.Add(PassBox);
            Window.Controls.Add(InstructionBox);
        }
        // Called when the form begins closing // Cancels close requests without password
        void Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) { e.Cancel = true; }
            if (e.CloseReason == CloseReason.TaskManagerClosing) { e.Cancel = true; }
            if (e.CloseReason == CloseReason.None) { e.Cancel = true; }
        }
        // Show form
        public void Show()
        {
            // Set window propeties
            Window.FormBorderStyle = FormBorderStyle.None;
            Window.WindowState = FormWindowState.Maximized;
            Window.TopMost = true;
            // Se window Events
            Window.Deactivate += delegate
            {
                    Window.Activate();
            };
            Window.FormClosing += Closing;
            Window.SizeChanged += delegate { SetPassBoxSizeLocation(); SetInstructionBoxSizeLocation(); };
            Window.MouseLeave += delegate
            {
                    Cursor.Position = new Point(
                        Screen.PrimaryScreen.Bounds.Width / 2,
                        Screen.PrimaryScreen.Bounds.Height / 2
                    );
            };
            Window.LostFocus += delegate
            {
                    Console.WriteLine("Focus Lost!");
            };
            // Set the size/location of form objects when form has finished modification
            SetPassBoxSizeLocation();
            SetInstructionBoxSizeLocation();
            // Show window
            Window.ShowDialog();
        }
        /* Pasword box */
        TextBox PassBox = new TextBox()
        {
                Width = 100,
                Multiline = false,
                AcceptsTab = false,
                AcceptsReturn = false,
                UseSystemPasswordChar = true
        };
        void SetPassBoxSizeLocation()
        {
            PassBox.Width = Window.Width / 10;
            PassBox.Location = new Point(
                Screen.PrimaryScreen.Bounds.Width /2 - PassBox.Width /2,
                Screen.PrimaryScreen.Bounds.Height /2 - 35
            );
        }
        // When the Password box text is changed
        void PassTextChanged(object sender, EventArgs e)
        {
            if (PassBox.Text == UD.Password)
            {
                Environment.Exit(0);
            }
        }
        /* Instructions box */
        RichTextBox InstructionBox = new RichTextBox()
        {
                Width = (Screen.PrimaryScreen.Bounds.Width /5) *4,
                Height = Screen.PrimaryScreen.Bounds.Height /4,
                BackColor = Color.White
        };
        // Set the size/location reletive to size of Form
        void SetInstructionBoxSizeLocation()
        {
            InstructionBox.Size = new Size(
                (Screen.PrimaryScreen.Bounds.Width /5) *4,
                Screen.PrimaryScreen.Bounds.Height /4
            );
            InstructionBox.Location = new Point(
                Screen.PrimaryScreen.Bounds.Width /10,
                Screen.PrimaryScreen.Bounds.Height /4 - Screen.PrimaryScreen.Bounds.Height /8
            );
        }
        // Public function to change the text in the box
        public void SetInstructionText(string Text)
        {
            InstructionBox.Text = Text;
        }
    }
}
