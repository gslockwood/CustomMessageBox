using System.Drawing;
using System.Windows.Forms;

namespace CustomMessageBox
{
    public abstract class MessageBox
    {
        static Color primaryColor = Color.White;
        public static Color PrimaryColor
        {
            get { return primaryColor; }
            set { primaryColor = value; }
        }

        public static System.Windows.Forms.FormStartPosition StartPosition { get;set;}

        public static DialogResult Show(string text)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text))
            {                
                msgForm.PrimaryColor = PrimaryColor;
                result = msgForm.ShowDialog();
            }
            return result;
        }
        public static DialogResult Show(string text, string caption)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text, caption))
            { msgForm.PrimaryColor = PrimaryColor; result = msgForm.ShowDialog(); }
            return result;
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text, caption, buttons))
            { msgForm.PrimaryColor = PrimaryColor; result = msgForm.ShowDialog(); }
            return result;
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text, caption, buttons, icon))
            { msgForm.PrimaryColor = PrimaryColor; result = msgForm.ShowDialog(); }
            return result;
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text, caption, buttons, icon, defaultButton))
            { msgForm.PrimaryColor = PrimaryColor; result = msgForm.ShowDialog(); }
            return result;
        }

        /*-> IWin32Window Owner:
            *      Displays a message box in front of the specified object and with the other specified parameters.
            *      An implementation of IWin32Window that will own the modal dialog box.*/
        public static DialogResult Show(IWin32Window owner, string text)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text))
            {
                msgForm.StartPosition = StartPosition;
                msgForm.PrimaryColor = PrimaryColor;result = msgForm.ShowDialog(owner);}
            return result;
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text, caption))
                { msgForm.StartPosition = StartPosition; msgForm.PrimaryColor = PrimaryColor;result = msgForm.ShowDialog(owner);}
            return result;
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text, caption, buttons))
                { msgForm.StartPosition = StartPosition; msgForm.PrimaryColor = PrimaryColor;result = msgForm.ShowDialog(owner);}
            return result;
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text, caption, buttons, icon))
                { msgForm.StartPosition = StartPosition; msgForm.PrimaryColor = PrimaryColor;result = msgForm.ShowDialog(owner);}
            return result;
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text, caption, buttons, icon, defaultButton))
                { msgForm.StartPosition = StartPosition; msgForm.PrimaryColor = PrimaryColor;result = msgForm.ShowDialog(owner);}
            return result;
        }
    }
}
