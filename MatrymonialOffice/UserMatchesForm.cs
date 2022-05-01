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
    public class UserMatch
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Attractiveness { get; set; }
        public int Height { get; set; }
        public int Earnings { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public string Profession { get; set; }
        public string Religion { get; set; }
        public int FamilyImportance { get; set; }
        public int CarrerImportance { get; set; }
        public int HobbyImportance { get; set; }
        public int TravellingImportance { get; set; }
        public int SpiritualityImportance { get; set; }
        public int PartyingImportance { get; set; }
        public int SelfImprovementImportance { get; set; }

        public double MatchRatio { get; set; }
        public double Distance { get; set; }

        public UserMatch(User user, double matchRatio, double distance)
        {
            Name = user.Name;
            Age = user.Age;
            Attractiveness = user.Attractiveness;
            Height = user.Height;
            Earnings = user.Earnings;
            Gender = user.Gender.AsDisplayString();
            Education = user.Education.AsDisplayString();
            Profession = user.Profession.AsDisplayString();
            Religion = user.Religion.AsDisplayString();
            FamilyImportance = user.FamilyImportance;
            CarrerImportance = user.CarrerImportance;
            HobbyImportance = user.HobbyImportance;
            TravellingImportance = user.TravellingImportance;
            SpiritualityImportance = user.SpiritualityImportance;
            PartyingImportance = user.PartyingImportance;
            SelfImprovementImportance = user.SelfImprovementImportance;

            MatchRatio = matchRatio;
            Distance = distance;
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

            SetUpDataGrid();
        }

        private void SetUpDataGrid()
        #region DataGridSetUp...
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = string.Format("{0}", i + 1);
            }

            dataGridView1.RowHeadersWidth = (int)(dataGridView1.RowHeadersWidth * 1.5);

            dataGridView1.Columns["MatchRatio"].HeaderText = "Współczynnik dopasowania";
            dataGridView1.Columns["Name"].HeaderText = "Imię i Nazwisko";
            dataGridView1.Columns["Age"].HeaderText = "Wiek";
            dataGridView1.Columns["Attractiveness"].HeaderText = "Atrakcyjność";
            dataGridView1.Columns["Height"].HeaderText = "Wzrost";
            dataGridView1.Columns["Earnings"].HeaderText = "Miesięczne zarobki";
            dataGridView1.Columns["Gender"].HeaderText = "Płeć";
            dataGridView1.Columns["Education"].HeaderText = "Edukacja";
            dataGridView1.Columns["Profession"].HeaderText = "Zawód";
            dataGridView1.Columns["Religion"].HeaderText = "Religia";
            dataGridView1.Columns["FamilyImportance"].HeaderText = "Znaczenie rodziny";
            dataGridView1.Columns["CarrerImportance"].HeaderText = "Znaczenie pracy";
            dataGridView1.Columns["HobbyImportance"].HeaderText = "Znaczenie hobby";
            dataGridView1.Columns["TravellingImportance"].HeaderText = "Znaczenie podróźy";
            dataGridView1.Columns["SpiritualityImportance"].HeaderText = "Znaczenie duchowości";
            dataGridView1.Columns["PartyingImportance"].HeaderText = "Znaczenie imprez";
            dataGridView1.Columns["SelfImprovementImportance"].HeaderText = "Znaczenie samorozwoju";
            dataGridView1.Columns["Distance"].HeaderText = "Odległość (km)";

            dataGridView1.Columns["MatchRatio"].DisplayIndex = 0;
            dataGridView1.Columns["Name"].DisplayIndex = 1;
            dataGridView1.Columns["Distance"].DisplayIndex = 2;
        }
        #endregion

        private List<UserMatch> CalculateMatchRatio(List<User> users)
        {
            var matchedUsers = new List<UserMatch>();

            foreach (var user in users)
            {
                var ratio = Match.MatchingFactor(user, requirements);
                var distance = Coordinates.Distance((user.Latitude, user.Longitude), (requirements.Latitude, requirements.Longitude));
                matchedUsers.Add(new UserMatch(user, ratio, Math.Round(distance, 2)));
            }

            return matchedUsers.OrderByDescending(u => u.MatchRatio).Take(20).ToList();
        }
    }
}
