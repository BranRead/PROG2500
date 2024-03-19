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
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using System.IO;
using Assignment5;
using System.Data;
using System.Data.SqlClient;

namespace Assignment9

{ 

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string connString = Utility.GetConnectionString();

        DataTable dt;

        int current_primary_key = 0;


        int hairPicOption = 1;
        int hairNumOfPhotos = 8;
        
        int eyesPicOption = 1;
        int eyesNumOfPhotos = 8;

        int nosePicOption = 1;
        int noseNumOfPhotos = 7;

        int mouthPicOption = 1;
        int mouthNumOfPhotos = 7;

        List<TabItem> pages = new List<TabItem>();

        string fNameUserEnter;

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
        HotKey Help = new(Help_Menu, true);

        Editer editer = new();

        public MainWindow()
        {
            

            InitializeComponent();
            
            FillDataGrid();

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
                help = Help,
                exit = Exit
            };

            pages.Add(basicInfo);
            pages.Add(faceChanger);
            pages.Add(finish);

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

            InputBindings.Add(new KeyBinding(Help, new KeyGesture(Key.I, ModifierKeys.Control)));

            InputBindings.Add(new KeyBinding(Exit, new KeyGesture(Key.Q, ModifierKeys.Control)));
            
        }

        private void FillDataGrid()
        {
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(connString))
            {
                CmdString = "SELECT person.fName, " +
                    "person.lName, " +
                    "person.address, " +
                    "face.baseFace, " +
                    "face.hair, " +
                    "face.eyes, " +
                    "face.nose, " +
                    "face.mouth " +
                    "FROM person " +
                    "INNER JOIN face " +
                    "[ ON (person.id = face.personId) ]";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable("dataReadOut");
                sda.Fill(dt);
                dataReadOut.ItemsSource = dt.DefaultView;
            }
        }

        // Add a person record with these attributes...SQL INSERT command
        private void addPerson(String fn, String ln, String address)
        {
            // Old school connection
            SqlConnection conn = new SqlConnection(connString);

            // old school insert statement...note Trace output should show format of SQL Insert command
            String cmd_Text_Details = "INSERT INTO person(fName, lName, city)  VALUES('" + fn + "', '" + ln + "', '" + address + "');";
            String cmd_Text_Face = "INSERT INTO face(fName, lName, city)  VALUES('" + fn + "', '" + ln + "', '" + address + "');";
            Trace.Write(cmd_Text);

            // DB insert in try-catch
            try
            {
                // Example of C# named parameters...a good idea for important library calls
                SqlCommand command = new SqlCommand(cmdText: cmd_Text, connection: conn);
                command.Connection.Open();
                command.ExecuteNonQuery();  //does the actual insert statement
            }
            catch { System.Windows.MessageBox.Show("DB Add Exception"); }
            finally { conn.Close(); }

        }

        public static void Change_Body_Part(string part, bool isForward)
        {
            MainWindow thisWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;

            if (part == "Hair")
            {
                Image HairImage = thisWindow.Hair;
                if (!isForward) 
                {
                    thisEditer.Previous_Image(HairImage, part.ToLower(), ref thisWindow.hairPicOption, thisWindow.hairNumOfPhotos);
                }
                else
                {
                    thisEditer.Next_Image(HairImage, part.ToLower(), ref thisWindow.hairPicOption, thisWindow.hairNumOfPhotos);
                }
                Update_Label(part, thisWindow.HairLabel, thisWindow.hairPicOption);
            }

            if(part == "Eyes")
            {
                Image EyesImage = thisWindow.Eyes;
                if (!isForward)
                {
                    thisEditer.Previous_Image(EyesImage, part.ToLower(), ref thisWindow.eyesPicOption, thisWindow.eyesNumOfPhotos);
                }
                else
                {
                    thisEditer.Next_Image(EyesImage, part.ToLower(), ref thisWindow.eyesPicOption, thisWindow.eyesNumOfPhotos);
                }
                Update_Label(part, thisWindow.EyesLabel, thisWindow.eyesPicOption);
            }
            
            if(part == "Nose")
            {
                Image NoseImage = thisWindow.Nose;
                if (!isForward)
                {
                    thisEditer.Previous_Image(NoseImage, part.ToLower(), ref thisWindow.nosePicOption, thisWindow.noseNumOfPhotos);
                } else
                {
                    thisEditer.Next_Image(NoseImage, part.ToLower(), ref thisWindow.nosePicOption, thisWindow.noseNumOfPhotos);
                }
                Update_Label(part, thisWindow.NoseLabel, thisWindow.nosePicOption);
            }
           
            if (part == "Mouth")
            {
                Image MouthImage = thisWindow.Mouth;
                if (!isForward)
                {
                    thisEditer.Previous_Image(MouthImage, part.ToLower(), ref thisWindow.mouthPicOption, thisWindow.mouthNumOfPhotos);
                } else
                {
                    thisEditer.Next_Image(MouthImage, part.ToLower(), ref thisWindow.mouthPicOption, thisWindow.mouthNumOfPhotos);
                }
                Update_Label("Mouth", thisWindow.MouthLabel, thisWindow.mouthPicOption);
            }
        }

        public static void Randomize_Face()
        {
            MainWindow thisWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;

            if(thisWindow.HairCheckbox.IsChecked == true)
            {
                thisEditer.Random_Image(thisWindow.Hair, "hair", ref thisWindow.hairPicOption, thisWindow.hairNumOfPhotos);
                Update_Label("Hair", thisWindow.HairLabel, thisWindow.hairPicOption);
            }
            if (thisWindow.EyesCheckbox.IsChecked == true)
            {
                thisEditer.Random_Image(thisWindow.Eyes, "eyes", ref thisWindow.eyesPicOption, thisWindow.eyesNumOfPhotos);
                Update_Label("Eyes", thisWindow.EyesLabel, thisWindow.eyesPicOption);
            }
            if (thisWindow.NoseCheckbox.IsChecked == true)
            {
                thisEditer.Random_Image(thisWindow.Nose, "nose", ref thisWindow.nosePicOption, thisWindow.noseNumOfPhotos);
                Update_Label("Nose", thisWindow.NoseLabel, thisWindow.nosePicOption);
            }
            if(thisWindow.MouthCheckbox.IsChecked == true)
            {
                thisEditer.Random_Image(thisWindow.Mouth, "mouth", ref thisWindow.mouthPicOption, thisWindow.mouthNumOfPhotos);
                Update_Label("Mouth", thisWindow.MouthLabel, thisWindow.mouthPicOption);
            }
        }

        public static void Update_Label(string part, TextBlock label, int index)
        {
            label.Text = part + " " + (index);
        } 

        public static void New_Skin_Tone(string tone)
        {
            MainWindow thisWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
            Editer thisEditer = thisWindow.editer;
            thisEditer.Set_Base_Face(tone, thisWindow.BaseFace);
        }

        public static void Help_Menu()
        {
            HelpNavigator Nav_by_Topic = HelpNavigator.Topic;
            System.Windows.Forms.Help.ShowHelp(null, "FaceChanger.chm", Nav_by_Topic, "About.htm");
        }

        public static void Exit_App()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HelpNavigator Nav_by_Topic = HelpNavigator.Topic;
            System.Windows.Forms.Help.ShowHelp(null, "FaceChanger.chm", Nav_by_Topic, "About.htm");
        }

        private void Tab(object sender, RoutedEventArgs e)
        {
            Update_Output();
        }

        private void Update_Output()
        {
            fNameUserEnter = fNameInput.Text;
            if (fNameUserEnter == null || fNameUserEnter == "")
            {
                fNameUserEnter = "--Enter First Name--";
            }

            string lNameUserEnter = lNameInput.Text;
            if (lNameUserEnter == null || lNameUserEnter == "")
            {
                lNameUserEnter = "--Enter Last Name--";
            }

            string addressUserEnter = addressInput.Text;
            if (addressUserEnter == null || addressUserEnter == "")
            {
                addressUserEnter = "--Enter Address--";
            }

            

            fName.Text = "First name: " + fNameUserEnter;
            lName.Text = "Last name: " + lNameUserEnter;
            address.Text = "Address: " + addressUserEnter;
            

            editer.Update_Face("hair", HairResult, hairPicOption);
            editer.Update_Face("eyes", EyesResult, eyesPicOption);
            editer.Update_Face("Nose", NoseResult, nosePicOption);
            editer.Update_Face("Mouth", MouthResult, mouthPicOption);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            String fn = fNameInput.Text;
            String ln = lNameInput.Text;
            String a = addressInput.Text;

            // Add this record if values not empty
            if (fn != "" && ln != "" && a != "")
            {
                this.addPerson(fn, ln, a);  // old school SQL-over-the-connection
                //this.addPerson1(fn, ln, city);  // Stored procedure
            }
            else
            {
                System.Windows.MessageBox.Show("A field is empty...enter all fields");
            }

            // Update changes to the grid
            FillDataGrid();
        }

        private void Previous_Page(object sender, RoutedEventArgs e)
        {
            int newActivePageIndex = Page_isSelected() - 1;
            if(newActivePageIndex < 0)
            {
                newActivePageIndex = 0;
            }

            pages[newActivePageIndex].IsSelected = true;
        }

        private void Next_Page(object sender, RoutedEventArgs e)
        {
            int newActivePageIndex = Page_isSelected() + 1;
            if (newActivePageIndex >= pages.Count)
            {
                newActivePageIndex = pages.Count - 1;
            }

            if(newActivePageIndex == pages.Count - 1)
            {
                Update_Output();
            }

            pages[newActivePageIndex].IsSelected = true;
        }

       
        private int Page_isSelected()
        {
            int index = 0;

            foreach(TabItem page in pages)
            {
                if (page.IsSelected)
                {
                    return index;
                }
                index++;
            }

            return 0;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "character.txt")))
            {
                File.Delete(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "character.txt"));
                fNameInput.Clear();
                lNameInput.Clear();
                addressInput.Clear();
                hairPicOption = 1;
                eyesPicOption = 1;
                nosePicOption = 1;
                mouthPicOption = 1;
                editer.Update_Face("hair", Hair, hairPicOption);
                Update_Label("Hair", HairLabel, hairPicOption);

                editer.Update_Face("eyes", Eyes, eyesPicOption);
                Update_Label("Eyes", EyesLabel, eyesPicOption);

                editer.Update_Face("nose", Nose, nosePicOption);
                Update_Label("Nose", NoseLabel, nosePicOption);

                editer.Update_Face("mouth", Mouth, mouthPicOption);
                Update_Label("Mouth", MouthLabel, mouthPicOption);
                pages[0].IsSelected = true;
            }
        }
    }
}
