using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatrymonialOffice.Data;
using MatrymonialOffice.Admin_forms;

namespace MatrymonialOffice
{
    public partial class ViewUsersForm : Form
    {
        List<User> users;
        public ViewUsersForm()
        {
            InitializeComponent();
            var dbContext = new MatrymonialOfficeDbContext();
            users = dbContext.Users.ToList<User>();
            var bindingList = new BindingList<User>(users);
            var source = new BindingSource(bindingList, null);
            userTable.DataSource = source;
            DataGridViewButtonColumn detailsButtonColumn = new DataGridViewButtonColumn();
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            detailsButtonColumn.Name = "Details";
            detailsButtonColumn.Text = "Details";
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.Text = "Delete";
            detailsButtonColumn.HeaderText = "Szczegóły";
            deleteButtonColumn.HeaderText = "Usuń";
            int columnIndex = 9;
            if (userTable.Columns["Details"] == null)
            {
                userTable.Columns.Insert(columnIndex, detailsButtonColumn);
            }
            if (userTable.Columns["Delete"] == null)
            {
                userTable.Columns.Insert(columnIndex, deleteButtonColumn);
            }
            userTable.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            userTable.Columns["Name"].HeaderText = "Imię i naziwsko";
            userTable.Columns["Age"].HeaderText = "Wiek";
            userTable.Columns["Attractiveness"].HeaderText = "Atrakcyjność";
            userTable.ReadOnly = true;
            userTable.Columns["Gender"].HeaderText = "Płeć";
            userTable.Columns["Education"].Visible = false;
            userTable.Columns["Profession"].Visible = false;
            userTable.Columns["Religion"].Visible = false;
            userTable.Columns["Longitude"].Visible = false;
            userTable.Columns["Latitude"].Visible = false;
            userTable.Columns["FamilyImportance"].Visible = false;
            userTable.Columns["HobbyImportance"].Visible = false;
            userTable.Columns["TravellingImportance"].Visible = false;
            userTable.Columns["SpiritualityImportance"].Visible = false;
            userTable.Columns["PartyingImportance"].Visible = false;
            userTable.Columns["SelfimprovementImportance"].Visible = false;
            userTable.Columns["CarrerImportance"].Visible = false;
            userTable.Columns["Height"].Visible = false;
            userTable.Columns["Earnings"].Visible = false;
        }

        private void ViewUsersForm_Load(object sender, EventArgs e)
        {

        }

        private void userTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == userTable.Columns["Details"].Index)
            {
                var userDetailsForm = new UserDetailsForm(users[e.RowIndex]);
                userDetailsForm.Show();
            }
            else if (e.ColumnIndex == userTable.Columns["Delete"].Index)
            {
                var dbContext = new MatrymonialOfficeDbContext();
                var deleted = users[e.RowIndex];
                dbContext.Remove(deleted);
                dbContext.SaveChanges();
                MessageBox.Show($"Usunięto użytkownika {deleted.Name}.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                users = dbContext.Users.ToList<User>();
                var bindingList = new BindingList<User>(users);
                var source = new BindingSource(bindingList, null);
                userTable.DataSource = source;
                userTable.Invalidate();
                userTable.EndEdit();
            }
        }
    }
}
