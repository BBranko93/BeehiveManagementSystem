using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BeehiveManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Queen queen = new Queen();
        private DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            // The code-behind updates that status report TextBox
            // in the constructor after the buttons are clicked to
            // make sure the latest report is always displayed.
            statusReport.Text = queen.StatusReport;
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1.5);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            WorkShift_Click(this, new RoutedEventArgs());
        }

        private void WorkShift_Click(object sender, RoutedEventArgs e)
        {
            queen.WorkTheNextShift();
            statusReport.Text = queen.StatusReport;
        }

        private void AssignJob_Click(object sender, RoutedEventArgs e)
        {
            // The "assign job" button passes the text from the selected
            // ComboBox item directly to Queen.AssignBee, so it's really
            // important that the cases in the switch statement
            // match the ComboBox items exactly.

            queen.AssignBee(jobSelector.Text);
            statusReport.Text = queen.StatusReport;
        }
    }   
}
