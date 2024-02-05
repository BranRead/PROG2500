using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        HotKey BackHair = new(Backward_Hair, true);
        HotKey ForwardHair = new(Forward_Hair, true);
        HotKey BackEyes = new(Backward_Eyes, true);
        HotKey ForwardEyes = new(Forward_Eyes, true);
        HotKey BackNose = new(Backward_Nose, true);
        HotKey ForwardNose = new(Forward_Nose, true);
        HotKey BackMouth = new(Backward_Mouth, true);
        HotKey ForwardMouth = new(Forward_Mouth, true);
        HotKey Randomize = new(Randomize_Face, true);
        HotKey NewDarkSkin = new(New_Dark_Skin, true);
        HotKey NewLightSkin = new(New_Light_Skin, true);
        HotKey Exit = new(Exit_App, true);

        Editer editer = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new
            {
                backHair = BackHair,
                forwardHair = ForwardHair,
                backEyes = BackEyes,
                forwardEyes = ForwardEyes,
                backNose = BackNose,
                forwardNose = ForwardNose,
                backMouth = BackMouth,
                forwardMouth = ForwardMouth,
                randomize = Randomize,
                newDarkSkin = NewDarkSkin,
                newLightSkin = NewLightSkin,
                exit = Exit
            };

            InputBindings.Add(new KeyBinding(BackHair, new KeyGesture(Key.F1, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(ForwardHair, new KeyGesture(Key.F2, ModifierKeys.None)));

            InputBindings.Add(new KeyBinding(BackEyes, new KeyGesture(Key.F3, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(ForwardEyes, new KeyGesture(Key.F4, ModifierKeys.None)));
            
            InputBindings.Add(new KeyBinding(BackNose, new KeyGesture(Key.F5, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(ForwardNose, new KeyGesture(Key.F6, ModifierKeys.None)));
            
            InputBindings.Add(new KeyBinding(BackMouth, new KeyGesture(Key.F7, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(ForwardMouth, new KeyGesture(Key.F8, ModifierKeys.None)));

            InputBindings.Add(new KeyBinding(Randomize, new KeyGesture(Key.R, ModifierKeys.Control)));

            InputBindings.Add(new KeyBinding(NewDarkSkin, new KeyGesture(Key.D, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(NewLightSkin, new KeyGesture(Key.L, ModifierKeys.Control)));

            InputBindings.Add(new KeyBinding(Exit, new KeyGesture(Key.Q, ModifierKeys.Control)));
            
        }

        public static void Backward_Hair()
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;
            Image HairImage = thisWindow.Hair;
            thisEditer.Previous_Image(HairImage, thisWindow.hairArray, ref thisWindow.hairArrayIndex);

            Update_Label("Hair", thisWindow.HairLabel, thisWindow.hairArrayIndex);
        }

        public static void Forward_Hair()
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;
            Image HairImage = thisWindow.Hair;
            thisEditer.Next_Image(HairImage, thisWindow.hairArray, ref thisWindow.hairArrayIndex);

            Update_Label("Hair", thisWindow.HairLabel, thisWindow.hairArrayIndex);
        }

        public static void Backward_Eyes()
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;
            Image EyesImage = thisWindow.Eyes;
            thisEditer.Previous_Image(EyesImage, thisWindow.eyesArray, ref thisWindow.eyesArrayIndex);

            Update_Label("Eyes", thisWindow.EyesLabel, thisWindow.eyesArrayIndex);
        }

        public static void Forward_Eyes()
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;
            Image EyesImage = thisWindow.Eyes;
            thisEditer.Next_Image(EyesImage, thisWindow.eyesArray, ref thisWindow.eyesArrayIndex);

            Update_Label("Eyes", thisWindow.EyesLabel, thisWindow.eyesArrayIndex);
        }

        public static void Backward_Nose()
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;
            Image NoseImage = thisWindow.Nose;
            thisEditer.Previous_Image(NoseImage, thisWindow.noseArray, ref thisWindow.noseArrayIndex);

            Update_Label("Nose", thisWindow.NoseLabel, thisWindow.noseArrayIndex);
        }

        public static void Forward_Nose()
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;
            Image NoseImage = thisWindow.Nose;
            thisEditer.Next_Image(NoseImage, thisWindow.noseArray, ref thisWindow.noseArrayIndex);

            Update_Label("Nose", thisWindow.NoseLabel, thisWindow.noseArrayIndex);
        }

        public static void Backward_Mouth()
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;
            Image MouthImage = thisWindow.Mouth;
            thisEditer.Previous_Image(MouthImage, thisWindow.mouthArray, ref thisWindow.mouthArrayIndex);

            Update_Label("Mouth", thisWindow.MouthLabel, thisWindow.mouthArrayIndex);
        }

        public static void Forward_Mouth()
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;
            Image MouthImage = thisWindow.Mouth;
            thisEditer.Next_Image(MouthImage, thisWindow.mouthArray, ref thisWindow.mouthArrayIndex);

            Update_Label("Mouth", thisWindow.MouthLabel, thisWindow.mouthArrayIndex);
        }

        public static void Randomize_Face()
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;

            if(thisWindow.HairCheckbox.IsChecked == true)
            {
                thisEditer.Random_Image(thisWindow.Hair, thisWindow.hairArray, ref thisWindow.hairArrayIndex);
            }
            if (thisWindow.EyesCheckbox.IsChecked == true)
            {
                thisEditer.Random_Image(thisWindow.Eyes, thisWindow.eyesArray, ref thisWindow.eyesArrayIndex);
            }
            if(thisWindow.NoseCheckbox.IsChecked == true)
            {
                thisEditer.Random_Image(thisWindow.Nose, thisWindow.noseArray, ref thisWindow.noseArrayIndex);
            }
            if(thisWindow.MouthCheckbox.IsChecked == true)
            {
                thisEditer.Random_Image(thisWindow.Mouth, thisWindow.mouthArray, ref thisWindow.mouthArrayIndex);
            }
        }

        public static void Update_Label(string part, Label label, int index)
        {
            label.Content = part + " " + (index+=1);
        } 

        public static void New_Dark_Skin()
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;

            thisEditer.Set_Base_Face("/images/base_face_dark.png", thisWindow.BaseFace);
        }

        public static void New_Light_Skin()
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;

            thisEditer.Set_Base_Face("/images/base_face_light.png", thisWindow.BaseFace);
        }

        public static void Exit_App()
        {
            ((MainWindow)Application.Current.MainWindow).Close();
        }
    }

}
