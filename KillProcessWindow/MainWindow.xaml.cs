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
using MainLayer;
using System.Windows.Threading;
namespace KillProcessWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        event EventHandler ProcCountStarted;
        Processes proc = new Processes();
        public MainWindow()
        {
            InitializeComponent();
            this.dataGrid1.ItemsSource = proc.ProcessesItems;
            ProcCountStarted += InitProcCount;
            System.TimeSpan interval = new TimeSpan(0, 0, 0, 0, 500);

            DispatcherTimer tmr = new DispatcherTimer(interval, DispatcherPriority.Normal, OnTimerTick, Dispatcher.CurrentDispatcher);

            //InitProcCount(null, EventArgs.Empty);
            //processCountTextBox.Text
        }

        public void OnTimerTick(Object sender,EventArgs e)
        {
            if (ProcCountStarted != null)
                ProcCountStarted(sender, e);
        }
        private void InitProcCount(object sender,EventArgs e)
        {
           processCountTextBox.Text=proc.DoCountProcesses().ToString();
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            proc.KillChosenProcesses(ProcNameTBlock.Text);
        }

       

        
    }
}
