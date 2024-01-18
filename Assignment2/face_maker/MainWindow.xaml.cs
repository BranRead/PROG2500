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

namespace face_maker
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

        private void Hair_Button_Back(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hair back");
        }

        private void Hair_Button_Forward(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hair forward");
        }

        private void Eyes_Button_Back(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Eyes back");
        }

        private void Eyes_Button_Forward(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Eyes forward");
        }

        private void Nose_Button_Back(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nose back");
        }

        private void Nose_Button_Forward(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nose forward");
        }

        private void Mouth_Button_Back(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mouth back");
        }

        private void Mouth_Button_Forward(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mouth forward");
        }
    }
}
