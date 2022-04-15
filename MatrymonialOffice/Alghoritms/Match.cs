using MatrymonialOffice.Data;

namespace MatrymonialOffice.Alghoritms
{
    public static class Match
    {
        public static double MatchingFactor(Person potentialPartner, PartnerRequirements requirements)
        {
            double factor = 1.0;

            factor *= Affilations.Identity(potentialPartner.Gender, requirements.Gender);
            factor *= Affilations.Identity(potentialPartner.Education, requirements.Education);
            factor *= Affilations.Identity(potentialPartner.Profession, requirements.Profession);
            factor *= Affilations.Identity(potentialPartner.Religion, requirements.Religion);
            factor *= Affilations.Age(potentialPartner.Age, requirements.Age);
            factor *= Affilations.Residence(potentialPartner.Residence, requirements.Residence);
            factor *= Affilations.Height(potentialPartner.Height, requirements.Height);
            factor *= Affilations.Earnings(potentialPartner.Earnings, requirements.Earnings);
            factor *= Affilations.Attractiveness(potentialPartner.Attractiveness, requirements.Attractiveness);
            factor *= Affilations.ImportanceParameters(potentialPartner.FamilyImportance, requirements.FamilyImportance);
            factor *= Affilations.ImportanceParameters(potentialPartner.CarrerImportance, requirements.CarrerImportance);
            factor *= Affilations.ImportanceParameters(potentialPartner.HobbyImportance, requirements.HobbyImportance);
            factor *= Affilations.ImportanceParameters(potentialPartner.TravellingImportance, requirements.TravellingImportance);
            factor *= Affilations.ImportanceParameters(potentialPartner.SpiritualityImportance, requirements.SpiritualityImportance);
            factor *= Affilations.ImportanceParameters(potentialPartner.PartyingImportance, requirements.PartyingImportance);
            factor *= Affilations.ImportanceParameters(potentialPartner.SelfImprovementImportance, requirements.SelfImprovementImportance);

            return factor;
        }
    }
}
