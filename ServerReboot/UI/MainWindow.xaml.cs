using ServerReboot.EventLogging;
using System;
using System.Windows;

namespace ServerReboot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EventLogger events = new EventLogger("Server-Reboot", "Application");
        private string currentUser = Environment.UserDomainName + "\\" + Environment.UserName;
        
        /// <summary>
        ///  Event Log IDS
        ///
        ///  Event Log Ids
        ///     2000 - Mode Selection
        ///     2001 - RFC Checked
        ///     2002 - Manager Checked
        ///     2003 - Peer Approval Checked
        ///     2004 - Disconnected Remote Sessions
        ///     2005 - Verify Server rebooting
        ///     2006 - All Requirements Met
        ///     2007 -
        ///     2008 -
        ///     2009 -
        ///     2010 -
        ///     2011 -
        ///     2012 -
        ///     2013 - Reboot Button Clicked
        ///     2014 - Reboot No Button Clicked
        ///     2015 - Reboot Yes Button Clicked
        ///     
        /// </summary>

        int elModeSelection = 2000;
        int elRFCChecked = 2001;
        int elManagerApproval = 2002;
        int elPeerApproval = 2003;
        int elRemoteSessionDisconnect = 2004;
        int elServerVerification = 2005;
        int elAllRequirementsMet = 2006;
        int elRebootButtton = 2013;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new View();
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region Selection

        /// <summary>
        /// Handles the Checked event of the AfterHours control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AfterHours_Checked(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("After Hours mode selected on " + DateTime.Now.ToString() + " by " + currentUser, "info", elModeSelection);
        }

        /// <summary>
        /// Handles the Checked event of the CausingOutage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CausingOutage_Checked(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Causing Outage mode selected on " + DateTime.Now.ToString() + " by " + currentUser, "info", elModeSelection);
        }

        /// <summary>
        /// Handles the Checked event of the NormalOperation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void NormalOperation_Checked(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Normal Operation mode selected on " + DateTime.Now.ToString() + " by " + currentUser, "info", elModeSelection);
        }
        #endregion

        #region After Hours
        /// <summary>
        /// Handles the Checked event of the cbAHEmergencyRFC control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAHEmergencyRFC_Checked(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Emergency RFC was checked on " + DateTime.Now.ToString() + " by " + currentUser, "info", elRFCChecked);
            events.WriteToEventLog("RFC Number : " + tbAHEmergencyRFC.Text + " on " + DateTime.Now.ToString() + " by " + currentUser, "info", elRFCChecked);
        }

        /// <summary>
        /// Handles the Checked event of the cbAHMangerApproval control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAHMangerApproval_Checked(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Manager Approval was checked on " + DateTime.Now.ToString() + " by " + currentUser, "info", elManagerApproval);
            events.WriteToEventLog("Manager Name : " + tbAHManagerApproval.Text + " on " + DateTime.Now.ToString() + " by " + currentUser, "info", elManagerApproval);
        }

        /// <summary>
        /// Handles the Checked event of the cbAHDisconnectRemoteSessions control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAHDisconnectRemoteSessions_Checked(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Disconnected from all remote sessions was checked on " + DateTime.Now.ToString() + " by " + currentUser, "info", elRemoteSessionDisconnect);
        }

        /// <summary>
        /// Handles the Checked event of the cbAHVerifyServer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAHVerifyServer_Checked(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Server Verification was checked on " + DateTime.Now.ToString() + " by " + currentUser, "info", elServerVerification);
        }

        /// <summary>
        /// Handles the Checked event of the cbAHRequirementsMet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAHRequirementsMet_Checked(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Requirements Met was checked on " + DateTime.Now.ToString() + " by " + currentUser, "info", elAllRequirementsMet);
        }

        /// <summary>
        /// Handles the Click event of the btnAHReboot control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAHReboot_Click(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Reboot button clicked on " + DateTime.Now.ToString() + " by " + currentUser + " redirecting to reboot confirmation", "warn", elRebootButtton);
            UI.RebootConfirmation rc = new UI.RebootConfirmation();
            Application.Current.MainWindow.Close();
            rc.Show();
        }
        #endregion

        #region Causing Outage
        /// <summary>
        /// Handles the Checked event of the cbCOEmergencyRFC control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbCOEmergencyRFC_Checked(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Emergency RFC was checked on " + DateTime.Now.ToString() + " by " + currentUser, "info", elRFCChecked);
            events.WriteToEventLog("RFC Number : " + tbAHEmergencyRFC.Text + " on " + DateTime.Now.ToString() + " by " + currentUser, "info", elRFCChecked);
        }

        /// <summary>
        /// Handles the Checked event of the cbCOPeerApproval control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbCOPeerApproval_Checked(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Peer Approval was checked on " + DateTime.Now.ToString() + " by " + currentUser, "info", elPeerApproval);
            events.WriteToEventLog("Peer Name : " + tbCOPeerApproval.Text + " on " + DateTime.Now.ToString() + " by " + currentUser, "info", elPeerApproval);
        }

        /// <summary>
        /// Handles the Checked event of the cbCOMangerApproval control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbCOMangerApproval_Checked(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Manager Approval was checked on " + DateTime.Now.ToString() + " by " + currentUser, "info", elManagerApproval);
            events.WriteToEventLog("Manager Name : " + tbAHManagerApproval.Text + " on " + DateTime.Now.ToString() + " by " + currentUser, "info", elManagerApproval);
        }

        /// <summary>
        /// Handles the Click event of the btnCOReboot control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnCOReboot_Click(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Reboot button clicked on " + DateTime.Now.ToString() + " by " + currentUser + " redirecting to reboot confirmation", "warn", elRebootButtton);
            UI.RebootConfirmation rc = new UI.RebootConfirmation();
            Application.Current.MainWindow.Close();
            rc.Show();
        }

        #endregion
    }
}