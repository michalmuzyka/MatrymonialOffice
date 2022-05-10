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

namespace MatrymonialOffice.Admin_forms
{
    public partial class UserDetailsForm : Form
    {
        public UserDetailsForm(User user)
        {
            InitializeComponent();
            Text = user.Name;
            nameControl.Text = user.Name;
            ageControl.Text = user.Age.ToString();
            attractivnessControl.Text = user.Attractiveness.ToString();
            heightControl.Text = user.Height.ToString();
            earningsControl.Text = user.Earnings.ToString();
            genderControl.Text = user.Gender == Gender.Male ? "Mężczyzna" : "Kobieta";
            educationControl.Text = user.Education switch
            {
                Education.Primary => "Podstawowe",
                Education.Secondary => "Średnie",
                Education.Higher => "Wyższe"
            };
            professionControl.Text = user.Profession switch
            {
                Profession.Actor => "Aktor",
                Profession.Constructor => "Twórca",
                Profession.Cook=> "Kucharz",
                Profession.Engineer => "Inżynier",
                Profession.Official => "Urzędnik",
                Profession.Soldier => "Żołnierz",
                Profession.Teacher => "Nauczyciel",
                Profession.Driver => "Kierowca",
                Profession.Other => "Inny",
            };
            religionControl.Text = user.Religion switch
            {
                Religion.Buddism => "Buddyzm",
                Religion.Catholic => "Katolicyzm",
                Religion.Orthodox => "Prawosławie",
                Religion.Judaism => "Judaizm",
                Religion.Islam => "Islam",
                Religion.None => "Żadna"
            };
            longitudeControl.Text = user.Longitude.ToString();
            latitudeControl.Text = user.Latitude.ToString();
            familyImpControl.Text = user.FamilyImportance switch
            {
                0 => "Nieistotna",
                1 => "Trochę ważna",
                2 => "Mało ważna",
                3 => "Ważna",
                4 => "Bardzo ważna",
                5 => "Niezwykle ważna",
                _ => throw new NotImplementedException()
            };
            careerImpControl.Text = user.FamilyImportance switch
            {
                0 => "Nieistotna",
                1 => "Trochę ważna",
                2 => "Mało ważna",
                3 => "Ważna",
                4 => "Bardzo ważna",
                5 => "Niezwykle ważna",
                _ => throw new NotImplementedException()
            };
            hobbyImpControl.Text = user.HobbyImportance switch
            {
                0 => "Nieistotna",
                1 => "Trochę ważna",
                2 => "Mało ważna",
                3 => "Ważna",
                4 => "Bardzo ważna",
                5 => "Niezwykle ważna",
                _ => throw new NotImplementedException()
            };
            partyingImpControl.Text = user.PartyingImportance switch
            {
                0 => "Nieistotna",
                1 => "Trochę ważna",
                2 => "Mało ważna",
                3 => "Ważna",
                4 => "Bardzo ważna",
                5 => "Niezwykle ważna",
                _ => throw new NotImplementedException()
            };
            selfimprovementImpControl.Text = user.SelfImprovementImportance switch
            {
                0 => "Nieistotna",
                1 => "Trochę ważna",
                2 => "Mało ważna",
                3 => "Ważna",
                4 => "Bardzo ważna",
                5 => "Niezwykle ważna",
                _ => throw new NotImplementedException()
            };
            spiritualityImpControl.Text = user.SpiritualityImportance switch
            {
                0 => "Nieistotna",
                1 => "Trochę ważna",
                2 => "Mało ważna",
                3 => "Ważna",
                4 => "Bardzo ważna",
                5 => "Niezwykle ważna",
                _ => throw new NotImplementedException()
            };
            travellingImpControl.Text = user.TravellingImportance switch
            {
                0 => "Nieistotna",
                1 => "Trochę ważna",
                2 => "Mało ważna",
                3 => "Ważna",
                4 => "Bardzo ważna",
                5 => "Niezwykle ważna",
                _ => throw new NotImplementedException()
            };

            for (int i = 0; i < 18; i+=2)
            {
                tableLayoutPanel1.GetControlFromPosition(0, i).BackColor = ColorTranslator.FromHtml("#FAE3D9");
                tableLayoutPanel1.GetControlFromPosition(1, i).BackColor = ColorTranslator.FromHtml("#FAE3D9");
                tableLayoutPanel1.GetControlFromPosition(0, i+1).BackColor = ColorTranslator.FromHtml("#FFC0CB");
                tableLayoutPanel1.GetControlFromPosition(1, i+1).BackColor = ColorTranslator.FromHtml("#FFC0CB");
            }
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if(e.Row % 2 == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#FAE3D9")), e.CellBounds);
            }
            else e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#FFC0CB")), e.CellBounds);
        }

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.heart_icon;
        }
    }
}
