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
using RestSharp;
using Newtonsoft.Json;
using System.Configuration;

namespace MatrymonialOffice.Admin_forms
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
            BackColor = ColorTranslator.FromHtml("#FAE3D9");
        }

        private async Task<User> AddUser(User newUser)
        {
            var dbContext = new MatrymonialOfficeDbContext();

            dbContext.Users.Add(newUser);
            await dbContext.SaveChangesAsync();
            return newUser;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var location = (Location)((ComboboxItem)comboBox12.SelectedItem).Value;
            User newUser = new User()
            {
                Age = (int)numericUpDown1.Value,
                Attractiveness = (int)numericUpDown2.Value,
                CarrerImportance = ComboBoxToImportance(comboBox6.Text),
                Earnings = (int)numericUpDown4.Value,
                Education = ComboBoxToEducation(comboBox2.Text),
                FamilyImportance = ComboBoxToImportance(comboBox5.Text),
                Gender = comboBox1.Text == "Mężczyzna" ? Gender.Male : Gender.Female,
                Height = (int)numericUpDown3.Value,
                HobbyImportance = ComboBoxToImportance(comboBox6.Text),
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Name = textBox1.Text,
                PartyingImportance = ComboBoxToImportance(comboBox10.Text),
                Profession = ComboBoxToProfession(comboBox3.Text),
                Religion = ComboBoxToReligion(comboBox4.Text),
                SelfImprovementImportance = ComboBoxToImportance(comboBox11.Text),
                SpiritualityImportance = ComboBoxToImportance(comboBox9.Text),
                TravellingImportance = ComboBoxToImportance(comboBox8.Text),
            };
            await AddUser(newUser);
            MessageBox.Show($"Dodano użytkownika {newUser.Name}.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var cbs = GetAllControlsRecusrvive<ComboBox>(this);
            foreach (var cb in cbs)
            {
                if (string.IsNullOrEmpty(cb.Text)) 
                {
                    button1.Enabled = false;
                    return;
                }
            }
            if (textBox1.Text.Length < 1) return;
            button1.Enabled = true;
        }

        public static IList<T> GetAllControlsRecusrvive<T>(Control control) where T : Control
        {
            var rtn = new List<T>();
            foreach (Control item in control.Controls)
            {
                var ctr = item as T;
                if (ctr != null)
                {
                    rtn.Add(ctr);
                }
                else
                {
                    rtn.AddRange(GetAllControlsRecusrvive<T>(item));
                }

            }
            return rtn;
        }

        private int ComboBoxToImportance(string value)
        {
            return value switch
            {
                "Nieważne" => 0,
                "Bardzo małe" => 1,
                "Małe" => 2,
                "Średnie" => 3,
                "Duże" => 4,
                "Bardzo duże" => 5,
                _ => throw new InvalidOperationException()
            };
        }

        private Education ComboBoxToEducation(string value)
        {
            return value switch
            {
                "Podstawowe" => Education.Primary,
                "Średnie" => Education.Secondary,
                "Wyższe" => Education.Higher,
                _ => throw new InvalidOperationException()
            };
        }

        private Profession ComboBoxToProfession(string value)
        {
            return value switch
            {
                 "Aktor" => Profession.Actor,
                 "Twórca" => Profession.Constructor,
                 "Kucharz" => Profession.Cook,
                 "Inżynier" => Profession.Engineer,
                 "Urzędnik" => Profession.Official,
                 "Żołnierz" => Profession.Soldier,
                 "Nauczyciel" => Profession.Teacher,
                 "Kierowca" => Profession.Driver,
                 "Inny" => Profession.Other,
                 _ => throw new InvalidOperationException()
            };
        }

        private Religion ComboBoxToReligion(string value)
        {
            return value switch
            {
                 "Buddyzm" => Religion.Buddism,
                 "Katolicyzm" => Religion.Catholic,
                 "Prawosławie" => Religion.Orthodox,
                 "Judaizm" => Religion.Judaism,
                 "Islam" => Religion.Islam,
                 "Żadne" => Religion.None,
                 _ => throw new InvalidOperationException()
            };
        }

        private async void comboBox12_TextChanged(object sender, EventArgs e)
        {
            if (comboBox12.SelectedIndex == -1)
            {
                comboBox12.SafeClearItems();

                if (comboBox12.Text.Length >= 3)
                {
                    var apiKey = ConfigurationManager.AppSettings["apikey"];

                    var options = new RestClientOptions("http://api.positionstack.com/v1/forward")
                    {
                        ThrowOnAnyError = true,
                        Timeout = 1000
                    };

                    var client = new RestClient(options);

                    var request = new RestRequest()
                        .AddQueryParameter("access_key", apiKey)
                        .AddQueryParameter("query", comboBox12.Text)
                        .AddQueryParameter("limit", "10")
                        .AddQueryParameter("output", "json")
                        .AddQueryParameter("country", "PL");

                    try
                    {
                        dynamic response = await client.GetAsync(request);
                        dynamic json = JsonConvert.DeserializeObject(response.Content);

                        foreach (var item in json.data)
                        {
                            ComboboxItem comboBoxItem = new();
                            comboBoxItem.Text = item.name;
                            if (item.administrative_area != null)
                            {
                                comboBoxItem.Text += ", " + item.administrative_area;
                            }

                            comboBoxItem.Value = new Location
                            {
                                Longitude = item.longitude,
                                Latitude = item.latitude,
                            };

                            comboBox12.Items.Add(comboBoxItem);
                        }
                        comboBox12.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.heart_icon;
        }
    }
}
