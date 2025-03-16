using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using zipDeleter.Utility;

namespace Zip_Deleter
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0) {
                ZipHelper.ExtractAndDelete(args[0]);
                return;
            }

            DialogResult result = MessageBox.Show("우클릭 메뉴에 등록하시겠습니까? 😃", "설정", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                RegisterContextMenu();
                MessageBox.Show("✨등록 완료✨", "알림");
            }
        }

        static void RegisterContextMenu()
        {
            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            string regPath = @"Software\Classes\SystemFileAssociations\.zip\shell\압축 해제 후 삭제\command";

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(regPath))
            {
                key.SetValue("", $"\"{exePath}\" \"%1\"");
            }
        }
    }
}