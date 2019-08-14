using COMP123_S2019_FinalTestB.Objects;
using COMP123_S2019_FinalTestB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 Student Name: Ilhyo Sung
 Student ID: 301001793 
 Description: This is the Program.cs
 */ 

namespace COMP123_S2019_FinalTestB
{
    static class Program
    {
        public static CharacterGeneratorForm characterForm;
        public static Form aboutForm;
        public static Character character;

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            character = new Character();
            characterForm = new CharacterGeneratorForm();
            aboutForm = new Form();

            Application.Run(characterForm);            
        }
    }
}
