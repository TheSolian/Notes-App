using NotesApp;
using System.Windows.Forms;

namespace NotesAppUI
{
    internal static class Program
    {
        public static string FOLDER_NAME = "NotesFolder";
        public static string FOLDER_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), Program.FOLDER_NAME);

        public static void LoadList(ListBox list)
        {
            var files = Notes.getNotesFromFolder(FOLDER_PATH);
            list.Items.Clear();

            foreach (var file in files)
            {
                list.Items.Add(file);
            }
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Notes.initFolder(FOLDER_NAME);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}