using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotesApp;

namespace NotesAppUI
{
    public partial class CreateDialog : Form
    {
        private string _text;
        private ListBox _noteList;

        public CreateDialog(string text, ListBox noteList)
        {
            InitializeComponent();
            _text = text;
            _noteList = noteList;

        }

        private void CreateDialog_Load(object sender, EventArgs e)
        {
            Text = _text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;

            bool result = Notes.createNote(Program.FOLDER_PATH, textBox1.Text);

            if (result)
            {
                Close();
                Program.LoadList(_noteList);
            }
            else
            {
                label2.Text = "Note already exists";
                label2.ForeColor = Color.Red;
            }
        }
    }
}
