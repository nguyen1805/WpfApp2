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
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Thread th1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            th1 = new Thread(new ThreadStart(thread_funcs));
            th1.IsBackground = true;
            th1.Start();
        }
        private void thread_funcs()
        {
            UdpClient cl1 = new UdpClient(62205);
            IPEndPoint ep1 = new IPEndPoint(IPAddress.Any, 62205);
            
            while (true)
            {
                byte[] bytes = cl1.Receive(ref ep1);
                Console.WriteLine($"recv {bytes.Length}");
                Thread.Sleep(10);
            }
        }
    }
}
