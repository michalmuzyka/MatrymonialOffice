using MatrymonialOffice.Alghoritms;
using MatrymonialOffice.Data;
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
    public class UserWithRatio : User
    {
        public double MatchRatio { get; set; }

        public UserWithRatio(User user, double matchRatio)
        {
            foreach (var prop in user.GetType().GetProperties())
            {
                this.GetType().GetProperty(prop.Name)!.SetValue(this, prop.GetValue(user, null), null);
            }
            MatchRatio = matchRatio;
        }
    }

    public partial class UserMatchesForm : Form
    {
        MatrymonialOfficeDbContext dbContext;
        List<User> users;
        public PartnerRequirements requirements { get; set; }

        public UserMatchesForm()
        {
            InitializeComponent();
        }

        private void UserMatchesForm_Load(object sender, EventArgs e)
        {
            dbContext = new MatrymonialOfficeDbContext();
            users = dbContext.Users.ToList<User>();
            this.Icon = Properties.Resources.heart_icon;
            tableLayoutPanel1.BackColor = ColorTranslator.FromHtml("#FAE3D9");
            dataGridView1.DataSource = CalculateMatchRatio(users);
            dataGridView1.Columns.RemoveAt(1);
        }

        private List<UserWithRatio> CalculateMatchRatio(List<User> users)
        {
            var matchedUsers = new List<UserWithRatio>();

            foreach (var user in users)
            {
                var ratio = Match.MatchingFactor(user, requirements);
                matchedUsers.Add(new UserWithRatio(user, ratio));
            }

            return matchedUsers.OrderByDescending(u => u.MatchRatio).Take(10).ToList();
        }
    }
}
