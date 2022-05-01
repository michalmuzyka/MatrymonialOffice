using MatrymonialOffice.Data;
using MatrymonialOffice.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrymonialOffice
{
    public static class Extensions
    {
        public static void SafeClearItems(this ComboBox comboBox)
        {
            foreach (var item in new ArrayList(comboBox.Items))
            {
                comboBox.Items.Remove(item);
            }
        }

        public static string AsDisplayString(this Gender role)
        {
            switch (role)
            {
                case Gender.Male: return Resources.GenderMale;
                case Gender.Female: return Resources.GenderFemale;

                default: throw new ArgumentOutOfRangeException("gender");
            }
        }

        public static string AsDisplayString(this Profession profession)
        {
            switch (profession)
            {
                case Profession.Engineer: return Resources.ProfessionEngineer;
                case Profession.Other: return Resources.ProfessionOther;
                case Profession.Actor: return Resources.ProfessionActor;
                case Profession.Teacher: return Resources.ProfessionTeacher;
                case Profession.Constructor: return Resources.ProfessionConstructor;
                case Profession.Driver: return Resources.ProfessionDriver;
                case Profession.Official: return Resources.ProfessionOfficial;
                case Profession.Cook: return Resources.ProfessionCook;
                case Profession.Soldier: return Resources.ProfessionSoldier;

                default: throw new ArgumentOutOfRangeException("profession");
            }
        }

        public static string AsDisplayString(this Education education)
        {
            switch (education)
            {
                case Education.Primary: return Resources.EducationPrimary;
                case Education.Secondary: return Resources.EducationSecondary;
                case Education.Higher: return Resources.EducationHigher;

                default: throw new ArgumentOutOfRangeException("profession");
            }
        }

        public static string AsDisplayString(this Religion religion)
        {
            switch (religion)
            {
                case Religion.None: return Resources.ReligionNone;
                case Religion.Orthodox: return Resources.ReligionOrthodox;
                case Religion.Catholic: return Resources.ReligionCatholic;
                case Religion.Islam: return Resources.ReligionIslam;
                case Religion.Judaism: return Resources.ReligionJudaism;
                case Religion.Buddism: return Resources.ReligionBuddism;

                default: throw new ArgumentOutOfRangeException("religion");
            }
        }
    }
}
