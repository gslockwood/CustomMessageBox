namespace CustomMessageBox
{
    public enum MessageBoxButtons
    {
        OK = System.Windows.Forms.MessageBoxButtons.OK,
        OKCancel = System.Windows.Forms.MessageBoxButtons.OKCancel,
        AbortRetryIgnore = System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore,
        YesNoCancel = System.Windows.Forms.MessageBoxButtons.YesNoCancel,
        YesNo = System.Windows.Forms.MessageBoxButtons.YesNo,
        RetryCancel = System.Windows.Forms.MessageBoxButtons.RetryCancel,
        Custom1Button = 6,
        Custom2Buttons = 7,
        Custom3Buttons = 8
    }

    public enum DialogResult
    {
        //
        // Summary:
        //     Nothing is returned from the dialog box. This means that the modal dialog continues
        //     running.
        None = System.Windows.Forms.DialogResult.None,
        //
        // Summary:
        //     The dialog box return value is OK (usually sent from a button labeled OK).
        OK = System.Windows.Forms.DialogResult.OK,
        //
        // Summary:
        //     The dialog box return value is Cancel (usually sent from a button labeled Cancel).
        Cancel = System.Windows.Forms.DialogResult.Cancel,
        //
        // Summary:
        //     The dialog box return value is Abort (usually sent from a button labeled Abort).
        Abort = System.Windows.Forms.DialogResult.Abort,
        //
        // Summary:
        //     The dialog box return value is Retry (usually sent from a button labeled Retry).
        Retry = System.Windows.Forms.DialogResult.Retry,
        //
        // Summary:
        //     The dialog box return value is Ignore (usually sent from a button labeled Ignore).
        Ignore = System.Windows.Forms.DialogResult.Ignore,
        //
        // Summary:
        //     The dialog box return value is Yes (usually sent from a button labeled Yes).
        Yes = System.Windows.Forms.DialogResult.Yes,
        //
        // Summary:
        //     The dialog box return value is No (usually sent from a button labeled No).
        No = System.Windows.Forms.DialogResult.No,
        Custom1stOption,
        Custom2ndtOption,
        Custom3rdOption

    }
}

