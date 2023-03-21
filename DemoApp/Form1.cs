using CustomMessageBox;

namespace DemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            CustomMessageBox.MessageBox.PrimaryColor = Color.CornflowerBlue;

            //CustomMessageBox.MessageBox.Show("Demo");

            CustomMessageBox.DialogResult result;
        again:
            CustomMessageBox.MessageBox.StartPosition = FormStartPosition.CenterScreen;
            result = CustomMessageBox.MessageBox.Show(this, "with owner / Custom2Buttons", "caption", CustomMessageBox.MessageBoxButtons.Custom2Buttons, new string[] { "Custom1", "Custom2" }, MessageBoxIcon.Hand);
            System.Diagnostics.Debug.WriteLine(result);
            
            //goto again;

            result = CustomMessageBox.MessageBox.Show("Custom2Buttons", "caption", CustomMessageBox.MessageBoxButtons.Custom2Buttons, new string[] { "1", "2" }, MessageBoxIcon.Hand);
            System.Diagnostics.Debug.WriteLine(result);
            result = CustomMessageBox.MessageBox.Show("Custom3Buttons", "caption", CustomMessageBox.MessageBoxButtons.Custom3Buttons, new string[] { "Exit", "Save/Exit", "Cancel" }, MessageBoxIcon.Hand);
            System.Diagnostics.Debug.WriteLine(result);
            result = CustomMessageBox.MessageBox.Show("YesNo", "caption", CustomMessageBox.MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            System.Diagnostics.Debug.WriteLine(result);

            goto again;
        }
    }
}