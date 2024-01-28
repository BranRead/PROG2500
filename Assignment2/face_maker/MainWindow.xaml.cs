using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        string[] hairArray = { "/images/hair1.png", "/images/hair2.png", "/images/hair3.png", "/images/hair4.png", "/images/hair5.png", "/images/hair6.png", "/images/hair7.png", "/images/hair8.png" };
        string[] eyesArray = { "/images/eyes1.png", "/images/eyes2.png", "/images/eyes3.png", "/images/eyes4.png", "/images/eyes5.png", "/images/eyes6.png", "/images/eyes7.png", "/images/eyes8.png" };
        string[] noseArray = { "/images/nose1.png", "/images/nose2.png", "/images/nose3.png", "/images/nose4.png", "/images/nose5.png", "/images/nose6.png", "/images/nose7.png" };
        string[] mouthArray = { "/images/mouth1.png", "/images/mouth2.png", "/images/mouth3.png", "/images/mouth4.png", "/images/mouth5.png", "/images/mouth6.png", "/images/mouth7.png" };
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

            image.Source = new BitmapImage(new Uri(array[index], UriKind.Relative));
        }

        private static void Next_Image(Image image, string[] array, ref int index)
        {
            index++;
            if (index > array.Length -1)
            {
                index = 0;
            }

            image.Source = new BitmapImage(new Uri(array[index], UriKind.Relative));
        }

        private void Randomize_Click(object sender, RoutedEventArgs e)
        {
            Random rng = new Random();
            hairArrayIndex = rng.Next(hairArray.Length);
            eyesArrayIndex = rng.Next(eyesArray.Length);
            noseArrayIndex = rng.Next(noseArray.Length);
            mouthArrayIndex = rng.Next(mouthArray.Length);

            Hair.Source = new BitmapImage(new Uri(hairArray[hairArrayIndex], UriKind.Relative));
            Eyes.Source = new BitmapImage(new Uri(eyesArray[eyesArrayIndex], UriKind.Relative));
            Nose.Source = new BitmapImage(new Uri(noseArray[noseArrayIndex], UriKind.Relative));
            Mouth.Source = new BitmapImage(new Uri(mouthArray[mouthArrayIndex], UriKind.Relative));
        }
    }

}
