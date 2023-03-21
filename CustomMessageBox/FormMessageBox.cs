using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomMessageBox
{
    internal partial class FormMessageBox : BaseForm
    {
        //Fields
        private int borderSize = 2;
        private MessageBoxButtons buttons;
        private string[] customButtonTextArray;

        //Properties
        public override Color PrimaryColor
        {
            get { return primaryColor; }
            set
            {
                primaryColor = value;
                this.BackColor = primaryColor;//Form Border Color
                this.panelTitleBar.BackColor = PrimaryColor;//Title Bar Back Color
            }
        }

        //public Color PrimaryColor
        //{
        //    get { return primaryColor; }
        //    set
        //    {
        //        primaryColor = value;
        //        this.BackColor = primaryColor;//Form Border Color
        //        this.panelTitleBar.BackColor = PrimaryColor;//Title Bar Back Color
        //    }
        //}

        //Constructors
        //public FormMessageBox()
        //{
        //    InitializeComponent();
        //}
        public FormMessageBox(string text)
        {
            InitializeComponent();
            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = "";
            SetFormSize();
            SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);//Set Default Buttons
        }
        public FormMessageBox(string text, string caption)
        {
            InitializeComponent();
            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = caption;
            SetFormSize();
            SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);//Set Default Buttons
        }
        public FormMessageBox(string text, string caption, MessageBoxButtons buttons)
        {
            InitializeComponent();

            this.buttons = buttons;
            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, MessageBoxDefaultButton.Button1);//Set [Default Button 1]
        }


        public FormMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            InitializeComponent();

            this.buttons = buttons;

            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, MessageBoxDefaultButton.Button1);//Set [Default Button 1]
            SetIcon(icon);
        }
        public FormMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            InitializeComponent();

            this.buttons = buttons;

            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = caption;
            //SetFormSize();
            SetButtons(buttons, defaultButton);
            SetIcon(icon);
        }



        public FormMessageBox(string text, string caption, MessageBoxButtons buttons, string[] customButtonTextArray)
        {
            InitializeComponent();

            this.buttons = buttons;
            this.customButtonTextArray = customButtonTextArray;

            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, MessageBoxDefaultButton.Button1);//Set [Default Button 1]
        }
        public FormMessageBox(string text, string caption, MessageBoxButtons buttons, string[] customButtonTextArray, MessageBoxIcon icon)
        {
            InitializeComponent();

            this.buttons = buttons;
            this.customButtonTextArray = customButtonTextArray;

            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, MessageBoxDefaultButton.Button1);//Set [Default Button 1]
            SetIcon(icon);
        }

        public FormMessageBox(string text, string caption, MessageBoxButtons buttons, string[] customButtonTextArray, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            InitializeComponent();

            this.buttons = buttons;
            this.customButtonTextArray = customButtonTextArray;

            InitializeItems();
            this.PrimaryColor = primaryColor;
            this.labelMessage.Text = text;
            this.labelCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, defaultButton);
            SetIcon(icon);
        }




        //-> Private Methods
        private void InitializeItems()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);//Set border size
            this.labelMessage.MaximumSize = new Size(550, 0);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
        }
        private void SetFormSize()
        {
            int widht = this.labelMessage.Width + this.pictureBoxIcon.Width + this.panelBody.Padding.Left;
            int height = this.panelTitleBar.Height + this.labelMessage.Height + this.panelButtons.Height + this.panelBody.Padding.Top;
            this.Size = new Size(widht, height);
        }

        private void SetButtons(MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            this.panelButtons.Controls.Clear();

            if ((buttons == MessageBoxButtons.Custom1Button) || (buttons == MessageBoxButtons.Custom2Buttons) || (buttons == MessageBoxButtons.Custom3Buttons))
            {
                if (customButtonTextArray == null) return;

                for (int i = customButtonTextArray.Length - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        button3.Visible = true;
                        button3.DialogResult = System.Windows.Forms.DialogResult.Yes;
                        button3.Text = customButtonTextArray[i];
                        panelButtons.Controls.Add(button3);
                    }
                    else if (i == 1)
                    {
                        button2.Visible = true;
                        button2.DialogResult = System.Windows.Forms.DialogResult.No;
                        button2.Text = customButtonTextArray[i];
                        panelButtons.Controls.Add(button2);
                    }
                    else if (i == 2)
                    {
                        button1.Visible = true;
                        button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        button1.Text = customButtonTextArray[i];
                        panelButtons.Controls.Add(button1);

                    }
                }

            }
            else
            {
                switch (buttons)
                {
                    case MessageBoxButtons.OK:
                        //OK Button
                        button1.Visible = true;
                        //button1.Location = new Point(xCenter, yCenter);
                        button1.Text = "Ok";
                        button1.DialogResult = System.Windows.Forms.DialogResult.OK;//Set DialogResult

                        this.panelButtons.Controls.Add(button1);

                        //Set Default Button
                        SetDefaultButton(defaultButton);
                        break;
                    case MessageBoxButtons.OKCancel:
                        //OK Button
                        button1.Visible = true;
                        //button1.Location = new Point(xCenter - (button1.Width / 2) - 5, yCenter);
                        button1.Text = "Ok";
                        button1.DialogResult = System.Windows.Forms.DialogResult.OK;//Set DialogResult

                        //Cancel Button
                        button2.Visible = true;
                        //button2.Location = new Point(xCenter + (button2.Width / 2) + 5, yCenter);
                        button2.Text = "Cancel";
                        button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;//Set DialogResult
                                                                   //button2.BackColor = Color.DimGray;

                        this.panelButtons.Controls.Add(button2);
                        this.panelButtons.Controls.Add(button1);


                        //Set Default Button
                        if (defaultButton != MessageBoxDefaultButton.Button3)//There are only 2 buttons, so the Default Button cannot be Button3
                            SetDefaultButton(defaultButton);
                        else SetDefaultButton(MessageBoxDefaultButton.Button1);
                        break;

                    case MessageBoxButtons.RetryCancel:
                        //Retry Button
                        button1.Visible = true;
                        //button1.Location = new Point(xCenter - (button1.Width / 2) - 5, yCenter);
                        button1.Text = "Retry";
                        button1.DialogResult = System.Windows.Forms.DialogResult.Retry;//Set DialogResult

                        //Cancel Button
                        button2.Visible = true;
                        //button2.Location = new Point(xCenter + (button2.Width / 2) + 5, yCenter);
                        button2.Text = "Cancel";
                        button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;//Set DialogResult
                                                                   //button2.BackColor = Color.DimGray;

                        this.panelButtons.Controls.Add(button2);
                        this.panelButtons.Controls.Add(button1);


                        //Set Default Button
                        if (defaultButton != MessageBoxDefaultButton.Button3)//There are only 2 buttons, so the Default Button cannot be Button3
                            SetDefaultButton(defaultButton);
                        else SetDefaultButton(MessageBoxDefaultButton.Button1);
                        break;

                    case MessageBoxButtons.YesNo:
                        //Yes Button
                        button1.Visible = true;
                        //button1.Location = new Point(xCenter - (button1.Width / 2) - 5, yCenter);
                        button1.Text = "Yes";
                        button1.DialogResult = System.Windows.Forms.DialogResult.Yes;//Set DialogResult

                        //No Button
                        button2.Visible = true;
                        //button2.Location = new Point(xCenter + (button2.Width / 2) + 5, yCenter);
                        button2.Text = "No";
                        button2.DialogResult = System.Windows.Forms.DialogResult.No;//Set DialogResult
                                                               //button2.BackColor = Color.IndianRed;

                        this.panelButtons.Controls.Add(button2);
                        this.panelButtons.Controls.Add(button1);

                        //Set Default Button
                        if (defaultButton != MessageBoxDefaultButton.Button3)//There are only 2 buttons, so the Default Button cannot be Button3
                            SetDefaultButton(defaultButton);
                        else SetDefaultButton(MessageBoxDefaultButton.Button1);
                        break;
                    case MessageBoxButtons.YesNoCancel:
                        //Yes Button
                        button1.Visible = true;
                        //button1.Location = new Point(xCenter - button1.Width - 5, yCenter);
                        button1.Text = "Yes";
                        button1.DialogResult = System.Windows.Forms.DialogResult.Yes;//Set DialogResult

                        //No Button
                        button2.Visible = true;
                        //button2.Location = new Point(xCenter, yCenter);
                        button2.Text = "No";
                        button2.DialogResult = System.Windows.Forms.DialogResult.No;//Set DialogResult
                                                               //button2.BackColor = Color.IndianRed;

                        //Cancel Button
                        button3.Visible = true;
                        //button3.Location = new Point(xCenter + button2.Width + 5, yCenter);
                        button3.Text = "Cancel";
                        button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;//Set DialogResult
                                                                   //button3.BackColor = Color.DimGray;

                        this.panelButtons.Controls.Add(button3);
                        this.panelButtons.Controls.Add(button2);
                        this.panelButtons.Controls.Add(button1);

                        //Set Default Button
                        SetDefaultButton(defaultButton);
                        break;

                    case MessageBoxButtons.AbortRetryIgnore:
                        //Abort Button
                        button1.Visible = true;
                        //button1.Location = new Point(xCenter - button1.Width - 5, yCenter);
                        button1.Text = "Abort";
                        button1.DialogResult = System.Windows.Forms.DialogResult.Abort;//Set DialogResult
                                                                  //button1.BackColor = Color.Goldenrod;

                        //Retry Button
                        button2.Visible = true;
                        //button2.Location = new Point(xCenter, yCenter);
                        button2.Text = "Retry";
                        button2.DialogResult = System.Windows.Forms.DialogResult.Retry;//Set DialogResult                    

                        //Ignore Button
                        button3.Visible = true;
                        //button3.Location = new Point(xCenter + button2.Width + 5, yCenter);
                        button3.Text = "Ignore";
                        button3.DialogResult = System.Windows.Forms.DialogResult.Ignore;//Set DialogResult
                                                                   //button3.BackColor = Color.IndianRed;

                        this.panelButtons.Controls.Add(button3);
                        this.panelButtons.Controls.Add(button2);
                        this.panelButtons.Controls.Add(button1);

                        //Set Default Button
                        SetDefaultButton(defaultButton);
                        break;

                        //case MessageBoxButtons.CustomTriple:
                        //    //Abort Button
                        //    button1.Visible = true;
                        //    //button1.Location = new Point(xCenter - button1.Width - 5, yCenter);
                        //    button1.Text = "Abort";
                        //    button1.DialogResult = DialogResult.Yes;//Set DialogResult
                        //                                              //button1.BackColor = Color.Goldenrod;

                        //    //Retry Button
                        //    button2.Visible = true;
                        //    //button2.Location = new Point(xCenter, yCenter);
                        //    button2.Text = "Retry";
                        //    button2.DialogResult = DialogResult.No;//Set DialogResult                    

                        //    //Ignore Button
                        //    button3.Visible = true;
                        //    //button3.Location = new Point(xCenter + button2.Width + 5, yCenter);
                        //    button3.Text = "Ignore";
                        //    button3.DialogResult = DialogResult.Cancel;//Set DialogResult
                        //                                               //button3.BackColor = Color.IndianRed;

                        //    this.panelButtons.Controls.Add(button3);
                        //    this.panelButtons.Controls.Add(button2);
                        //    this.panelButtons.Controls.Add(button1);

                        //    //Set Default Button
                        //    SetDefaultButton(defaultButton);
                        //    break;
                }
            }
            //
        }

        bool userClosing = false;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) { userClosing = true; }

            base.OnFormClosing(e);
        }

        //public DialogResult ShowDialog(IWin32Window owner)
        public new DialogResult ShowDialog(IWin32Window owner)
        {
            if (userClosing)
                return CustomMessageBox.DialogResult.Cancel;

            System.Windows.Forms.DialogResult dialogResult = base.ShowDialog( owner );
            int result = (int)dialogResult;

            if ((buttons == MessageBoxButtons.Custom1Button) || (buttons == MessageBoxButtons.Custom2Buttons) || (buttons == MessageBoxButtons.Custom3Buttons))
            {
                if (result == (int)CustomMessageBox.DialogResult.Yes)
                    return CustomMessageBox.DialogResult.Custom1stOption;
                else if (result == (int)CustomMessageBox.DialogResult.No)
                    return CustomMessageBox.DialogResult.Custom2ndtOption;
                else if (result == (int)CustomMessageBox.DialogResult.Cancel)
                    return CustomMessageBox.DialogResult.Custom3rdOption;
            }

            return (DialogResult)result;
        }

        public new DialogResult ShowDialog()
        {
            if (userClosing)
                return CustomMessageBox.DialogResult.Cancel;

            System.Windows.Forms.DialogResult dialogResult = base.ShowDialog();
            int result = (int)dialogResult;

            if ((buttons == MessageBoxButtons.Custom1Button) || (buttons == MessageBoxButtons.Custom2Buttons) || (buttons == MessageBoxButtons.Custom3Buttons))
            {
                if (result == (int)CustomMessageBox.DialogResult.Yes)
                    return CustomMessageBox.DialogResult.Custom1stOption;
                else if (result == (int)CustomMessageBox.DialogResult.No)
                    return CustomMessageBox.DialogResult.Custom2ndtOption;
                else if (result == (int)CustomMessageBox.DialogResult.Cancel)
                    return CustomMessageBox.DialogResult.Custom3rdOption;
            }

            return (DialogResult)result;
        }


        private void SetDefaultButton(MessageBoxDefaultButton defaultButton)
        {
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1://Focus button 1
                    button1.Select();
                    button1.Font = new Font(button1.Font, FontStyle.Underline);
                    break;
                case MessageBoxDefaultButton.Button2://Focus button 2
                    button2.Select();
                    button2.Font = new Font(button2.Font, FontStyle.Underline);
                    break;
                case MessageBoxDefaultButton.Button3://Focus button 3
                    button3.Select();
                    button3.Font = new Font(button3.Font, FontStyle.Underline);
                    break;
            }
        }
        private void SetIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error: //Error
                    this.pictureBoxIcon.Image = System.Drawing.SystemIcons.Error.ToBitmap();
                    //PrimaryColor = Color.FromArgb(224, 79, 95);
                    this.btnClose.FlatAppearance.MouseOverBackColor = Color.Crimson;
                    break;
                case MessageBoxIcon.Information: //Information
                    this.pictureBoxIcon.Image = System.Drawing.SystemIcons.Information.ToBitmap();
                    //PrimaryColor = Color.FromArgb(38, 191, 166);
                    break;
                case MessageBoxIcon.Question://Question
                    this.pictureBoxIcon.Image = System.Drawing.SystemIcons.Question.ToBitmap();
                    //this.pictureBoxIcon.Image = Properties.Resources.question;
                    //PrimaryColor = Color.FromArgb(10, 119, 232);
                    break;
                case MessageBoxIcon.Exclamation://Exclamation
                    this.pictureBoxIcon.Image = System.Drawing.SystemIcons.Exclamation.ToBitmap();
                    //PrimaryColor = Color.FromArgb(255, 140, 0);
                    break;
                //case MessageBoxIcon.Hand://Hand
                //    this.pictureBoxIcon.Image = System.Drawing.SystemIcons.Hand.ToBitmap();
                //    PrimaryColor = Color.FromArgb(255, 140, 0);
                //    break;
                //case MessageBoxIcon.Asterisk://Asterisk
                //    this.pictureBoxIcon.Image = System.Drawing.SystemIcons.Asterisk.ToBitmap();
                //    PrimaryColor = Color.FromArgb(255, 140, 0);
                //    break;
                case MessageBoxIcon.None: //None
                    this.pictureBoxIcon.Image = System.Drawing.SystemIcons.WinLogo.ToBitmap();
                    //PrimaryColor = Color.CornflowerBlue;
                    break;
            }
        }

        //-> Events Methods
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region -> Drag Form
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void FormMessageBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (buttons == MessageBoxButtons.RetryCancel || buttons == MessageBoxButtons.YesNoCancel || buttons == MessageBoxButtons.OKCancel)
                if (e.KeyCode == Keys.Escape)
                {
                    this.Dispose(true);
                }
        }

        private void FormMessageBox_Load(object sender, EventArgs e)
        {

        }
    }

    internal partial class BaseForm : Form
    {
        protected Color primaryColor = Color.CornflowerBlue;

        [Browsable(true), Description("PrimaryColor"), Category("Misc")]
        public virtual Color PrimaryColor
        {
            get { return primaryColor; }
            set
            {
                primaryColor = value;
                this.BackColor = primaryColor;//Form Border Color
                //this.panelTitleBar.BackColor = PrimaryColor;//Title Bar Back Color

            }
        }

        public BaseForm()
        {
            //this.panelTitleBar = new System.Windows.Forms.Panel();
        }
    }


}
