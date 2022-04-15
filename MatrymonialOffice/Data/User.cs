
namespace MatrymonialOffice.Data
{
    public enum Gender
    {
        Male,
        Female
    }
    public enum Profession
    {
        Engineer,
        Official,
        Teacher,
        Driver,
        Cook,
        Actor,
        Soldier,
        Constructor,
        Other
    }
    public enum Education
    {
        Primary,
        Secondary,
        Higher,
    }
    public enum Religion
    {
        None,
        Catholic,
        Orthodox,
        Judaism,
        Islam,
        Buddism
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Attractiveness { get; set; }
        public int Height { get; set; }
        public int Earnings { get; set; }
        public Gender Gender { get; set; }
        public Education Education { get; set; }
        public Profession Profession { get; set; }
        public Religion Religion { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int FamilyImportance { get; set; }
        public int CarrerImportance { get; set; }
        public int HobbyImportance { get; set; }
        public int TravellingImportance { get; set; }
        public int SpiritualityImportance { get; set; }
        public int PartyingImportance { get; set; }
        public int SelfImprovementImportance { get; set; }
    }
}
