using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace zipDeleter.Utility
{
    internal class RegistryHelper
    {
        private const string RegistryKeyPath = @"Software\ZipDeleter";
        private const string RegistryValueName = "AutoDelete";

        public static bool GetAutoDeleteSetting()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                return key?.GetValue(RegistryValueName, "false").ToString() == "true";
            }
        }

        public static void SetAutoDeleteSetting(bool autoDelete) {
            using(RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
            {
                key.SetValue(RegistryValueName, autoDelete ? "true" : "false");
            }
        }
    }
}
