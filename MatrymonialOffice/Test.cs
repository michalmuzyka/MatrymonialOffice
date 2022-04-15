using MatrymonialOffice.Data;
using MatrymonialOffice.Alghoritms;

namespace MatrymonialOffice
{
    public static class Test
    {
        static Person MichalMuzyka = new Person()
        {
            Name = "Michał Muzyka",
            Age = 23,
            Gender = Gender.Male,
            Height = 179,
            Residence = new Coordinates() { Latitude = 52.4044, Longitude = 20.9499 },
            Religion = Religion.Islam,
            Profession = Profession.Constructor,
            Education = Education.Primary,
            Earnings = 100,
            Attractiveness = 1,
            CarrerImportance = 0,
            FamilyImportance = 0,
            HobbyImportance = 0,
            PartyingImportance = 5,
            SelfImprovementImportance = 0,
            SpiritualityImportance = 5,
            TravellingImportance = 0
        };

        static PartnerRequirements alternatywkasReqiuerments = new PartnerRequirements()
        {
            Age = (18, 100),
            Gender = (Importance.Important, Gender.Male),
            Height = 180,
            Residence = new Coordinates() { Latitude = 52.2370, Longitude = 21.0175 },
            Religion = (Importance.Unimportant, null),
            Education = (Importance.Unimportant, null),
            Profession = (Importance.Unimportant, null),
            Earnings = (0, 100000),
            Attractiveness = 0,
            CarrerImportance = 0,
            FamilyImportance = 0,
            HobbyImportance = 0,
            PartyingImportance = 5,
            SelfImprovementImportance = 0,
            TravellingImportance = 0,
            SpiritualityImportance = 5,
        };

        public static void TestMatchingAlghorithm()
        {
            double factor = Match.MatchingFactor(MichalMuzyka, alternatywkasReqiuerments);

            System.Console.WriteLine($"Michal Muzyka and Alternatywka factor: {factor}");
        }


    }
}
