using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

/*
 Student Name:
 Student ID:
 Description: This is the Character class used in character creation               
*/

namespace COMP123_S2019_FinalTestB.Views
{
    public partial class CharacterGeneratorForm : MasterForm
    {
        Random random = new Random();

        string[] FirstNameList;
        string[] LastNameList;

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
        private void LoadSkills()
        {
            SkillsList = File.ReadAllLines("..\\..\\Data\\skills.txt");
        }

        /// <summary>
        /// This is for loading names
        /// </summary>
        private void GenerateRandomSkills()
        {
            Program.character.Skills[0] = SkillsList[random.Next(SkillsList.Length)];
            Program.character.Skills[1] = SkillsList[random.Next(SkillsList.Length)];
            Program.character.Skills[2] = SkillsList[random.Next(SkillsList.Length)];
            Program.character.Skills[3] = SkillsList[random.Next(SkillsList.Length)];

            SkillFirstlabel.Text = Program.character.Skills[0];
            SkillSecondlabel.Text = Program.character.Skills[1];
            SkillThirdlabel.Text = Program.character.Skills[2];
            SkillFourthlabel.Text = Program.character.Skills[3];
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
    }
}
