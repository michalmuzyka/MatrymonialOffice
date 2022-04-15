
namespace MatrymonialOffice.Data
{
    public enum Importance
    {
        Important,
        Unimportant
    }

    public struct PartnerRequirements
    {
        public (int min, int max) Age { set; get; }
        public int Height { set; get; }
        public int Attractiveness { get; set; }
        public (int min, int max) Earnings { get; set; }
        public (Importance, Gender?) Gender { get; set; }
        public (Importance, Education?) Education { get; set; }
        public (Importance, Profession?) Profession { get; set; }
        public (Importance, Religion?) Religion { get; set; }
        public Coordinates Residence { get; set; }
        public int FamilyImportance { get; set; }
        public int CarrerImportance { get; set; }
        public int HobbyImportance { get; set; }
        public int TravellingImportance { get; set; }
        public int SpiritualityImportance { get; set; }
        public int PartyingImportance { get; set; }
        public int SelfImprovementImportance { get; set; }
    }
}
