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
        string[] hairArray = { "hair1.png", "hair2.png", "hair3.png", "hair4.png", "hair5.png", "hair6.png", "hair7.png", "hair8.png" };
        string[] eyesArray = { "eyes1.png", "eyes2.png", "eyes3.png", "eyes4.png", "eyes5.png", "eyes6.png", "eyes7.png", "eyes8.png" };
        string[] noseArray = { "nose1.png", "nose2.png", "nose3.png", "nose4.png", "nose5.png", "nose6.png", "nose7.png" };
        string[] mouthArray = { "mouth1.png", "mouth2.png", "mouth3.png", "mouth4.png", "mouth5.png", "mouth6.png", "mouth7.png" };
        int hairArrayIndex = 0;
        int eyesArrayIndex = 0;
        int noseArrayIndex = 0;
        int mouthArrayIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Hair_Button_Back(object sender, RoutedEventArgs e)
        {
            Previous_Image(Hair, hairArray, ref hairArrayIndex);
        }

        private void Hair_Button_Forward(object sender, RoutedEventArgs e)
        {
            Next_Image(Hair, hairArray, ref hairArrayIndex);
        }

        private void Eyes_Button_Back(object sender, RoutedEventArgs e)
        {
            Previous_Image(Eyes, eyesArray, ref eyesArrayIndex);
        }

        private void Eyes_Button_Forward(object sender, RoutedEventArgs e)
        {
            Next_Image(Eyes, eyesArray, ref eyesArrayIndex);

        }

        private void Nose_Button_Back(object sender, RoutedEventArgs e)
        {
            Previous_Image(Nose, noseArray, ref noseArrayIndex);

        }

        private void Nose_Button_Forward(object sender, RoutedEventArgs e)
        {
            Next_Image(Nose, noseArray, ref noseArrayIndex);

        }

        private void Mouth_Button_Back(object sender, RoutedEventArgs e)
        {
            Previous_Image(Mouth, mouthArray, ref mouthArrayIndex);
        }

        private void Mouth_Button_Forward(object sender, RoutedEventArgs e)
        {
            Next_Image(Mouth, mouthArray, ref mouthArrayIndex);

        }

        private static void Previous_Image(Image image, string[] array, ref int index)
        {
            index--;
            if (index < 0)
            {
                index = array.Length - 1;
            }

            string source = "C:\\Users\\Brandon\\Desktop\\ITProgramming\\Semester 4\\PROG2500\\Assignments\\Assignment2\\face_maker\\images\\" + array[index];
            image.Source = new BitmapImage(new Uri(source, UriKind.Absolute));
        }

        private static void Next_Image(Image image, string[] array, ref int index)
        {
            index++;
            if (index > array.Length -1)
            {
                index = 0;
            }

            string source = "C:\\Users\\Brandon\\Desktop\\ITProgramming\\Semester 4\\PROG2500\\Assignments\\Assignment2\\face_maker\\images\\" + array[index];
            image.Source = new BitmapImage(new Uri(source, UriKind.Absolute));
        }
    }

}
