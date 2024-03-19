using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            
            Cmd("C:\\Users\\Руслан\\AppData\\Roaming\\Telegram Desktop\\Telegram.exe");
            Cmd("C:\\Users\\Руслан\\AppData\\Roaming\\Telegram Desktop");
            while (Process.GetProcessesByName("Telegram.exe").Length > 0)
                await Task.Delay(2000);
            
            Cmd($"taskkill /f /PID \"{Process.GetCurrentProcess().Id}\" & " +
                    $"taskkill /f /im \"Telegram.exe\" & " +
                    $"taskkill /f /im \"Telegram Desktop");
        }
        void Cmd(string line)
        {
            try {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = $"/c \"{line}\"",
                    WindowStyle = ProcessWindowStyle.Hidden
                }).WaitForExit();
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Помилка: {ex.Message}", "помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  
    }
}
