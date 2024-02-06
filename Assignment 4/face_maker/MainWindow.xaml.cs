using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
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
        int hairPicInt = 1;
        int hairNumOfPhotos = 8;
        
        int eyesPicInt = 1;
        int eyesNumOfPhotos = 8;

        int nosePicInt = 1;
        int noseNumOfPhotos = 7;

        int mouthPicInt = 1;
        int mouthNumOfPhotos = 7;

        HotKey BackHair = new(() => Change_Body_Part("Hair", false), true);
        HotKey ForwardHair = new(() => Change_Body_Part("Hair", true), true);
        HotKey BackEyes = new(() => Change_Body_Part("Eyes", false), true);
        HotKey ForwardEyes = new(() => Change_Body_Part("Eyes", true), true);
        HotKey BackNose = new(() => Change_Body_Part("Nose", false), true);
        HotKey ForwardNose = new(() => Change_Body_Part("Nose", true), true);
        HotKey BackMouth = new(() => Change_Body_Part("Mouth", false), true);
        HotKey ForwardMouth = new(() => Change_Body_Part("Mouth", true), true);
        HotKey Randomize = new(Randomize_Face, true);
        HotKey NewDarkSkin = new(() => New_Skin_Tone("dark"), true);
        HotKey NewLightSkin = new(() => New_Skin_Tone("light"), true);
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

        public static void Change_Body_Part(string part, bool isForward)
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;

            if (part == "Hair")
            {
                Image HairImage = thisWindow.Hair;
                if (!isForward) 
                {
                    thisEditer.Previous_Image(HairImage, part.ToLower(), ref thisWindow.hairPicInt, thisWindow.hairNumOfPhotos);
                }
                else
                {
                    thisEditer.Next_Image(HairImage, part.ToLower(), ref thisWindow.hairPicInt, thisWindow.hairNumOfPhotos);
                }
                Update_Label(part, thisWindow.HairLabel, thisWindow.hairPicInt);
            }

            if(part == "Eyes")
            {
                Image EyesImage = thisWindow.Eyes;
                if (!isForward)
                {
                    thisEditer.Previous_Image(EyesImage, part.ToLower(), ref thisWindow.eyesPicInt, thisWindow.eyesNumOfPhotos);
                }
                else
                {
                    thisEditer.Next_Image(EyesImage, part.ToLower(), ref thisWindow.eyesPicInt, thisWindow.eyesNumOfPhotos);
                }
                Update_Label(part, thisWindow.EyesLabel, thisWindow.eyesPicInt);
            }
            
            if(part == "Nose")
            {
                Image NoseImage = thisWindow.Nose;
                if (!isForward)
                {
                    thisEditer.Previous_Image(NoseImage, part.ToLower(), ref thisWindow.nosePicInt, thisWindow.noseNumOfPhotos);
                } else
                {
                    thisEditer.Next_Image(NoseImage, part.ToLower(), ref thisWindow.nosePicInt, thisWindow.noseNumOfPhotos);
                }
                Update_Label(part, thisWindow.NoseLabel, thisWindow.nosePicInt);
            }
           
            if (part == "Mouth")
            {
                Image MouthImage = thisWindow.Mouth;
                if (!isForward)
                {
                    thisEditer.Previous_Image(MouthImage, part.ToLower(), ref thisWindow.mouthPicInt, thisWindow.mouthNumOfPhotos);
                } else
                {
                    thisEditer.Next_Image(MouthImage, part.ToLower(), ref thisWindow.mouthPicInt, thisWindow.mouthNumOfPhotos);
                }
                Update_Label("Mouth", thisWindow.MouthLabel, thisWindow.mouthPicInt);
            }
        }

        // Left this in for assignment purposes
        //public static void Backward_Mouth()
        //{
        //    MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
        //    Editer thisEditer = thisWindow.editer;
        //    Image MouthImage = thisWindow.Mouth;
        //    thisEditer.Previous_Image(MouthImage, thisWindow.mouthArray, ref thisWindow.mouthArrayIndex);

        //   Update_Label("Mouth", thisWindow.MouthLabel, thisWindow.mouthArrayIndex);
        //}

        //public static void Forward_Mouth()
        //{
        //    MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
        //    Editer thisEditer = thisWindow.editer;
        //    Image MouthImage = thisWindow.Mouth;
        //    thisEditer.Next_Image(MouthImage, thisWindow.mouthArray, ref thisWindow.mouthArrayIndex);

        //    Update_Label("Mouth", thisWindow.MouthLabel, thisWindow.mouthArrayIndex);
        //}

        public static void Randomize_Face()
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;

            if(thisWindow.HairCheckbox.IsChecked == true)
            {
                thisEditer.Random_Image(thisWindow.Hair, "hair", ref thisWindow.hairPicInt, thisWindow.hairNumOfPhotos);
                Update_Label("Hair", thisWindow.HairLabel, thisWindow.hairPicInt);
            }
            if (thisWindow.EyesCheckbox.IsChecked == true)
            {
                thisEditer.Random_Image(thisWindow.Eyes, "eyes", ref thisWindow.eyesPicInt, thisWindow.eyesNumOfPhotos);
                Update_Label("Eyes", thisWindow.EyesLabel, thisWindow.eyesPicInt);

            }
            if (thisWindow.NoseCheckbox.IsChecked == true)
            {
                thisEditer.Random_Image(thisWindow.Nose, "nose", ref thisWindow.nosePicInt, thisWindow.noseNumOfPhotos);
                Update_Label("Nose", thisWindow.NoseLabel, thisWindow.nosePicInt);
            }
            if(thisWindow.MouthCheckbox.IsChecked == true)
            {
                thisEditer.Random_Image(thisWindow.Mouth, "mouth", ref thisWindow.mouthPicInt, thisWindow.mouthNumOfPhotos);
                Update_Label("Mouth", thisWindow.MouthLabel, thisWindow.mouthPicInt);
            }
        }

        public static void Update_Label(string part, TextBlock label, int index)
        {
            label.Text = part + " " + (index);
        } 

        public static void New_Skin_Tone(string tone)
        {
            MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;
            thisEditer.Set_Base_Face(tone, thisWindow.BaseFace);
        }

        //public static void New_Light_Skin()
        //{
        //    MainWindow thisWindow = ((MainWindow)Application.Current.MainWindow);
        //    Editer thisEditer = thisWindow.editer;
        //    thisEditer.Set_Base_Face("/images/base_face_light.png", thisWindow.BaseFace);
        //}

        public static void Exit_App()
        {
            ((MainWindow)Application.Current.MainWindow).Close();
        }
    }

}
