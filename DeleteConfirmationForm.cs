using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zipDeleter.Forms
{
    public class DeleteConfirmationForm : Form
    {
        private CheckBox chkDoNotAskAgain;
        private Button btnYes;
        private Button btnNo;

        public bool DoNotAskAgain { get; private set; }

        public DeleteConfirmationForm()
        {
            Text = "삭제 확인";
            Size = new System.Drawing.Size(350, 180);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            Label lblMessage = new Label
            {
                Text = "원본 압축 파일을 삭제하시겠습니까? 😲",
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20)
            };
            Controls.Add(lblMessage);

            chkDoNotAskAgain = new CheckBox
            {
                Text = "다시 묻지 않고 압축 파일 삭제하기",
                AutoSize = true,
                Location = new System.Drawing.Point(20, 50)
            };
            Controls.Add(chkDoNotAskAgain);

            btnYes = new Button
            {
                Text = "예",
                DialogResult = DialogResult.Yes,
                Location = new System.Drawing.Point(50, 90),
                Size = new System.Drawing.Size(80, 30)
            };
            btnYes.Click += (sender, e) => { DoNotAskAgain = chkDoNotAskAgain.Checked; Close(); };
            Controls.Add(btnYes);

            btnNo = new Button
            {
                Text = "아니오",
                DialogResult = DialogResult.No,
                Location = new System.Drawing.Point(150, 90),
                Size = new System.Drawing.Size(80, 30)
            };
            btnNo.Click += (sender, e) => { Close(); };
            Controls.Add(btnNo);

            AcceptButton = btnYes;
            CancelButton = btnNo;
        }
    }
}
