using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MatrymonialOffice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#FAE3D9");
            this.Icon = Properties.Resources.heart_icon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var prefererencesForm = new PreferencesForm();
            prefererencesForm.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void wyświetlUżytkownikówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewUsersForm = new ViewUsersForm();
            viewUsersForm.Show();
        }

        private void dodajUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addUserForm = new Admin_forms.AddUserForm();
            addUserForm.Show();
        }
    }
}
