using CustomMessageBox;

namespace DemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CustomMessageBox.MessageBox.PrimaryColor= Color.Red;
            CustomMessageBox.MessageBox.Show("Demo");

            CustomMessageBox.MessageBox.StartPosition= FormStartPosition.CenterScreen;
            CustomMessageBox.MessageBox.Show(this, "Demo2");


        }
    }
}