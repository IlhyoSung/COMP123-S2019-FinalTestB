using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

/*
 Student Name: Ilhyo Sung
 Student ID: 301001793
 Description: This is the Character class used in character creation               
*/

namespace COMP123_S2019_FinalTestB.Views
{
    public partial class CharacterGeneratorForm : MasterForm
    {
        Random random = new Random();

        string[] FirstNameList;
        string[] LastNameList;
        string[] InventoryList;

        public CharacterGeneratorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is for loading names
        /// </summary>
        private void LoadNames()
        {
            FirstNameList = File.ReadAllLines("..\\..\\Data\\firstNames.txt");
            LastNameList = File.ReadAllLines("..\\..\\Data\\lastNames.txt");
        }

        /// <summary>
        /// This is for loading names
        /// </summary>
        private void GenerateNames()
        {
            Program.character.FirstName = FirstNameList[random.Next(FirstNameList.Length)];
            Program.character.LastName = LastNameList[random.Next(LastNameList.Length)];

            FirstNameDataLabel.Text = Program.character.FirstName;
            LastNameDataLabel.Text = Program.character.LastName;
        }

        /// <summary>
        /// This is for loading names
        /// </summary>
        private void LoadInventory()
        {
            InventoryList = File.ReadAllLines("..\\..\\Data\\inventory.txt");
        }

        /// <summary>
        /// This is for loading names
        /// </summary>
        private void GenerateRandomInventory()
        {
            try {
                Program.character.Inventory[0] = InventoryList[random.Next(InventoryList.Length)];
                Program.character.Inventory[1] = InventoryList[random.Next(InventoryList.Length)];
                Program.character.Inventory[2] = InventoryList[random.Next(InventoryList.Length)];
                Program.character.Inventory[3] = InventoryList[random.Next(InventoryList.Length)];

                FirstItemLabel.Text = Program.character.Inventory[0];
                SecondItemLabel.Text = Program.character.Inventory[1];
                ThirdItemLabel.Text = Program.character.Inventory[2];
                FourthItemLabel.Text = Program.character.Inventory[3];
            }
            catch (IOException exception)  
            {
                Debug.WriteLine("ERROR: " + exception.Message);
            }

            
        }
        private void GenerateInventoryButton_Click(object sender, EventArgs e)
        {
            GenerateRandomInventory();
        }

        /// <summary>
        /// This is the event handler for ther BackButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }

        /// <summary>
        /// This is the event handler for ther NextButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1)
            {
                MainTabControl.SelectedIndex++;
            }           
        }

        /// <summary>
        /// This is the event handler for the GenerateButtom Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            //string[] firstNames = File.ReadAllLines("..\\..\\Data\\firstNames.txt");

            //Program.character.FirstName = firstNames[random.Next(firstNames.Length)];
            //FirstNameDataLabel.Text = Program.character.FirstName;
            GenerateNames();
        }

        private void CharacterGeneratorForm_Load(object sender, EventArgs e)
        {
            LoadNames();
            GenerateNames();
            LoadInventory();
            GenerateRandomInventory();            
        }

        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {
            int strength = random.Next(3, 19);
            Program.character.Strength = strength.ToString();
            StrengthDataLabel.Text = Program.character.Strength;
            int dexterity = random.Next(3, 19);
            Program.character.Dexterity = dexterity.ToString();
            DexterityDataLabel.Text = Program.character.Dexterity;
            int constitution = random.Next(3, 19);
            Program.character.Constitution = constitution.ToString();
            ConstitutionDataLabel.Text = Program.character.Constitution;
            int intelligence = random.Next(3, 19);
            Program.character.Intelligence = intelligence.ToString();
            IntelligenceDataLabel.Text = Program.character.Intelligence;
            int wisdom = random.Next(3, 19);
            Program.character.Wisdom = wisdom.ToString();
            WisdomDataLabel.Text = Program.character.Wisdom;
            int charisma = random.Next(3, 19);
            Program.character.Charisma = charisma.ToString();
            CharismaDataLabel.Text = Program.character.Charisma;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // configure the file dialog
            CharaterSheetSaveFileDialog.FileName = "Character.txt";
            CharaterSheetSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharaterSheetSaveFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            // open the file dialog
            var result = CharaterSheetSaveFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                // open the stream for writing
                using (StreamWriter outputStream = new StreamWriter(
                    File.Open(CharaterSheetSaveFileDialog.FileName, FileMode.Create)))
                {
                    // write content - string type - to the file
                    outputStream.WriteLine(Program.character.FirstName);
                    outputStream.WriteLine(Program.character.LastName);
                    outputStream.WriteLine(Program.character.Strength);
                    outputStream.WriteLine(Program.character.Dexterity);
                    outputStream.WriteLine(Program.character.Constitution);
                    outputStream.WriteLine(Program.character.Intelligence);
                    outputStream.WriteLine(Program.character.Wisdom);
                    outputStream.WriteLine(Program.character.Charisma);
                    outputStream.WriteLine(Program.character.Inventory[0]);
                    outputStream.WriteLine(Program.character.Inventory[1]);
                    outputStream.WriteLine(Program.character.Inventory[2]);
                    outputStream.WriteLine(Program.character.Inventory[3]);
                                        
                    // cleanup
                    outputStream.Close();
                    outputStream.Dispose();

                    // give feedback to the user that the file has been saved
                    // this is a "modal" form
                    MessageBox.Show("File Saved...", "Saving File...",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // configure the file dialog
            CharaterSheetOpenFileDialog.FileName = "Character.txt";
            CharaterSheetOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharaterSheetOpenFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            // open the file dialog
            var result = CharaterSheetOpenFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                try
                {
                    // Open the  streawm for reading
                    using (StreamReader inputStream = new StreamReader(
                        File.Open(CharaterSheetOpenFileDialog.FileName, FileMode.Open)))
                    {
                        // read from the file
                        Program.character.FirstName = inputStream.ReadLine();
                        Program.character.LastName = inputStream.ReadLine();
                        Program.character.Strength = inputStream.ReadLine();
                        Program.character.Dexterity = inputStream.ReadLine();
                        Program.character.Constitution = inputStream.ReadLine();
                        Program.character.Intelligence = inputStream.ReadLine();
                        Program.character.Wisdom = inputStream.ReadLine();
                        Program.character.Charisma = inputStream.ReadLine();
                        Program.character.Inventory[0] = inputStream.ReadLine();
                        Program.character.Inventory[1] = inputStream.ReadLine();
                        Program.character.Inventory[2] = inputStream.ReadLine();
                        Program.character.Inventory[3] = inputStream.ReadLine();
                      
                        // cleanup
                        inputStream.Close();
                        inputStream.Dispose();


                    }

                    CharacterSheetFirstNameDataLabel.Text = Program.character.FirstName;
                    CharacterSheetLastNameDataLabel.Text = Program.character.LastName;
                    CharacterSheetStrengthDataLabel.Text = Program.character.Strength;
                    CharacterSheetDexerityDataLabel.Text = Program.character.Dexterity;
                    CharacterSheetConstitutionDataLabel.Text = Program.character.Constitution;
                    CharacterSheetIntelligenceDataLabel.Text = Program.character.Intelligence;
                    CharacterSheetWisdomDataLabel.Text = Program.character.Wisdom;
                    CharacterSheetCharismaDataLabel.Text = Program.character.Charisma;
                    CharacterSheetFirstItemDataLabel.Text = Program.character.Inventory[0];
                    CharacterSheetSecondItemDataLabel.Text = Program.character.Inventory[1];
                    CharacterSheetThirdItemDataLabel.Text = Program.character.Inventory[2];
                    CharacterSheetFourthItemDataLabel.Text = Program.character.Inventory[3];                    
                }
                catch (IOException exception)
                {

                    Debug.WriteLine("ERROR: " + exception.Message);

                    MessageBox.Show("ERROR: " + exception.Message, "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException exception)
                {
                    Debug.WriteLine("ERROR: " + exception.Message);

                    MessageBox.Show("ERROR: " + exception.Message + "\n\nPlease select the appropriate file type", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.aboutForm.ShowDialog();
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex == 3)
            {
                CharacterSheetFirstNameDataLabel.Text = Program.character.FirstName;
                CharacterSheetLastNameDataLabel.Text = Program.character.LastName;
                CharacterSheetStrengthDataLabel.Text = Program.character.Strength;
                CharacterSheetDexerityDataLabel.Text = Program.character.Dexterity;
                CharacterSheetConstitutionDataLabel.Text = Program.character.Constitution;
                CharacterSheetIntelligenceDataLabel.Text = Program.character.Intelligence;
                CharacterSheetWisdomDataLabel.Text = Program.character.Wisdom;
                CharacterSheetCharismaDataLabel.Text = Program.character.Charisma;
                CharacterSheetFirstItemDataLabel.Text = Program.character.Inventory[0];
                CharacterSheetSecondItemDataLabel.Text = Program.character.Inventory[1];
                CharacterSheetThirdItemDataLabel.Text = Program.character.Inventory[2];
                CharacterSheetFourthItemDataLabel.Text = Program.character.Inventory[3];
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
