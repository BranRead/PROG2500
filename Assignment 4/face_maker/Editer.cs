using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Diagnostics;

using System.Reflection;

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
    internal class Editer
    {
        public void Previous_Image(Image image, string[] array, ref int index)
        {
            index--;
            if (index < 0)
            {
                index = array.Length - 1;
            }

            image.Source = new BitmapImage(new Uri(array[index], UriKind.Relative));

        }

        public void Next_Image(Image image, string[] array, ref int index)
        {
            index++;
            if (index > array.Length - 1)
            {
              index = 0;
            }

            image.Source = new BitmapImage(new Uri(array[index], UriKind.Relative));
        }
    }
}
