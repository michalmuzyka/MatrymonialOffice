using MatrymonialOffice.Data;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrymonialOffice
{
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public class Location
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public partial class PreferencesForm : Form
    {
        public PreferencesForm()
        {
            InitializeComponent();
        }

        #region ControlsSetUp...
        private void PreferencesForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.heart_icon;
            this.BackColor = ColorTranslator.FromHtml("#FAE3D9");
            radioButton1.BackColor = Color.Transparent;
            radioButton2.BackColor = Color.Transparent;
            label20.ForeColor = Color.Red;
            label20.Hide();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label8.Text = trackBar1.Value.ToString();
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 27)
            {
                e.Graphics.FillRectangle(SystemBrushes.ControlLightLight, e.CellBounds);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                radioButton1.Enabled = false;
                radioButton1.Checked = false;
                radioButton2.Enabled = false;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Enabled = true;
                radioButton1.Checked = true;
                radioButton2.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                comboBox2.Enabled = false;
                comboBox2.SelectedItem = null;
            }
            else
            {
                comboBox2.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                comboBox3.Enabled = false;
                comboBox3.SelectedItem = null;
            }
            else
            {
                comboBox3.Enabled = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                comboBox4.Enabled = false;
                comboBox4.SelectedItem = null;
            }
            else
            {
                comboBox4.Enabled = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Minimum = numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = numericUpDown2.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown5.Minimum = numericUpDown4.Value;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown4.Maximum = numericUpDown5.Value;
        }
        #endregion

        private async void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                comboBox1.SafeClearItems();

                if (comboBox1.Text.Length >= 3)
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
                        .AddQueryParameter("query", comboBox1.Text)
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

                            comboBox1.Items.Add(comboBoxItem);
                        }
                        comboBox1.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidatePreferences())
            {
                var gender = GetGender();
                var education = GetEducation();
                var profession = GetProfession();
                var religion = GetReligion();
                var location = GetLocation();

                var partnerRequirements = new PartnerRequirements
                {
                    Age = ((int)numericUpDown1.Value, (int)numericUpDown2.Value),
                    Height = (int)numericUpDown3.Value,
                    Attractiveness = trackBar1.Value,
                    Earnings = ((int)numericUpDown4.Value, (int)numericUpDown5.Value),
                    Gender = gender,
                    Education = education,
                    Profession = profession,
                    Religion = religion,
                    Longitude = location.Longitude,
                    Latitude = location.Latitude,
                    FamilyImportance = comboBox5.SelectedIndex != -1 ? comboBox5.SelectedIndex : 0,
                    CarrerImportance = comboBox6.SelectedIndex != -1 ? comboBox6.SelectedIndex : 0,
                    HobbyImportance = comboBox7.SelectedIndex != -1 ? comboBox7.SelectedIndex : 0,
                    TravellingImportance = comboBox8.SelectedIndex != -1 ? comboBox8.SelectedIndex : 0,
                    SpiritualityImportance = comboBox9.SelectedIndex != -1 ? comboBox9.SelectedIndex : 0,
                    PartyingImportance = comboBox10.SelectedIndex != -1 ? comboBox10.SelectedIndex : 0,
                    SelfImprovementImportance = comboBox11.SelectedIndex != -1 ? comboBox11.SelectedIndex : 0,
                };

                this.Hide();
                UserMatchesForm form = new UserMatchesForm();
                form.requirements = partnerRequirements;
                form.Show();
            }
        }

        private (Importance, Gender?) GetGender()
        {
            (Importance importance, Gender? gender) gender;

            if (checkBox1.Checked)
            {
                gender = (Importance.Unimportant, null);
            }
            else
            {
                gender.importance = Importance.Important;

                if (radioButton1.Checked)
                {
                    gender.gender = Gender.Male;
                }
                else
                {
                    gender.gender = Gender.Female;
                }
            }

            return gender;
        }

        private (Importance, Education?) GetEducation()
        {
            (Importance importance, Education? education) education;

            if (checkBox2.Checked || comboBox2.SelectedIndex == -1)
            {
                education = (Importance.Unimportant, null);
            }
            else
            {
                education = (Importance.Important, (Education)comboBox2.SelectedIndex);
            }

            return education;
        }

        private (Importance, Profession?) GetProfession()
        {
            (Importance importance, Profession? profession) profession;

            if (checkBox3.Checked || comboBox3.SelectedIndex == -1)
            {
                profession = (Importance.Unimportant, null);
            }
            else
            {
                profession = (Importance.Important, (Profession)comboBox3.SelectedIndex);
            }

            return profession;
        }

        private (Importance, Religion?) GetReligion()
        {
            (Importance importance, Religion? religion) religion;

            if (checkBox4.Checked || comboBox4.SelectedIndex == -1)
            {
                religion = (Importance.Unimportant, null);
            }
            else
            {
                religion = (Importance.Important, (Religion)comboBox4.SelectedIndex);
            }

            return religion;
        }

        private Location GetLocation()
        {
            return (Location)((ComboboxItem)comboBox1.SelectedItem).Value;
        }


        private bool ValidatePreferences()
        {
            if (comboBox1.SelectedIndex == -1)
            {
                label20.Show();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
