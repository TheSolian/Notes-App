using NotesApp;

namespace NotesAppUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadList()
        {
            var files = Notes.getNotesFromFolder(Program.FOLDER_PATH);
            listView1.Items.Clear();

            foreach (var file in files)
            {
                listView1.Items.Add(file);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Notes.deleteNote(Path.Combine(Program.FOLDER_PATH, listView1.SelectedItems[0].Text));
            LoadList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string file = Path.Combine(Program.FOLDER_PATH, listView1.SelectedItems[0].Text);

            Notes.updateNote(file, text);
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            string text = Notes.readContentFromNote(Path.Combine(Program.FOLDER_PATH, listView1.SelectedItems[0].Text));
            textBox1.Text = text;
        }
    }
}