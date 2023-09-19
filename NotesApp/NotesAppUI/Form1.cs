using NotesApp;

namespace NotesAppUI
{
    public partial class Form1 : Form
    {
        private string _selectedItem = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.LoadList(listBox1);
            if (listBox1.SelectedItems.Count <= 0)
            {
                editor.Enabled = false;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CreateDialog noteDialog = new("Create Note", listBox1);

            noteDialog.StartPosition = FormStartPosition.CenterParent;
            noteDialog.FormBorderStyle = FormBorderStyle.FixedSingle;

            noteDialog.ShowDialog();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count <= 0)
            {
                editor.Text = "";
                return;
            }

            _selectedItem = listBox1.SelectedItem.ToString();
            var noteContent = Notes.readContentFromNote(Path.Combine(Program.FOLDER_PATH, _selectedItem));

            editor.Enabled = true;
            editor.Text = noteContent;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Notes.updateNote(Path.Combine(Program.FOLDER_PATH, _selectedItem), editor.Text);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Notes.deleteNote(Path.Combine(Program.FOLDER_PATH, _selectedItem));
            editor.Text = "";
            editor.Enabled = false;
            Program.LoadList(listBox1);
        }
    }
}