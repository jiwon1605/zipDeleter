using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using zipDeleter.Forms;

namespace zipDeleter.Utility
{
    internal class ZipHelper
    {
        public static void ExtractAndDelete(string zipPath)
        {
            string extractPath = Path.Combine(Path.GetDirectoryName(zipPath), Path.GetFileNameWithoutExtension(zipPath));
            Directory.CreateDirectory(extractPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);

            bool autoDelete = RegistryHelper.GetAutoDeleteSetting();

            if (!autoDelete)
            {
                using (DeleteConfirmationForm form = new DeleteConfirmationForm())
                {
                    DialogResult result = form.ShowDialog();

                    if (form.DoNotAskAgain)
                    {
                        RegistryHelper.SetAutoDeleteSetting(true);
                    }

                    if (result == DialogResult.Yes)
                    {
                        File.Delete(zipPath);
                        MessageBox.Show("압축 파일이 삭제되었습니다.😊", "완료");
                    }
                }
            }

            else
            {
                File.Delete(zipPath);
                MessageBox.Show("압축 파일이 자동 삭제되었습니다.😊", "완료");
            }
        }
    }
}
