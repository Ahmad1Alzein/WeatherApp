using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private static LocationModel result;// fish 8yro bkil lapp fa 3miltoh static

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) //l2n shilna l shreet tb3 lclose whwdi, battal fina n7arrek lwindow, fa 3imil 2inno bas 3ala lborder lyamin 2itha kebes left click fini 2e3mal drag lal window
            {
                this.DragMove();
            }
        }

        private void textSearch_MouseDown(object sender, MouseButtonEventArgs e)  //2itha kbst 3l textSearch bye3mal focus 3l txtSearch lihiyi l textBox (jeyi t7tha lal textblock)
        {
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text.Length > 0)
            {
                textSearch.Visibility = Visibility.Collapsed; //be5fi ltextblock 2itha katabet bil textbox
            }
            else
            {
                textSearch.Visibility = Visibility.Visible;
            }
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }


        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {


        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                result = await LocationProcessor.GetFullLocation(); // lresult full
                placeName.Text = result.Village + ", " + result.Country_name + ", " + result.Continent_name;
                currentTime.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToShortTimeString();


                // Create and configure a DispatcherTimer
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1); // Update every 1 second
                timer.Tick += Timer_Tick;

                // Start the timer
                timer.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Second == 0)
            {
                currentTime.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToShortTimeString();
            }
        }


        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}
