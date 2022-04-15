using Microsoft.EntityFrameworkCore.Migrations;

namespace MatrymonialOffice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Attractiveness = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Earnings = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Education = table.Column<int>(type: "int", nullable: false),
                    Profession = table.Column<int>(type: "int", nullable: false),
                    Religion = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    FamilyImportance = table.Column<int>(type: "int", nullable: false),
                    CarrerImportance = table.Column<int>(type: "int", nullable: false),
                    HobbyImportance = table.Column<int>(type: "int", nullable: false),
                    TravellingImportance = table.Column<int>(type: "int", nullable: false),
                    SpiritualityImportance = table.Column<int>(type: "int", nullable: false),
                    PartyingImportance = table.Column<int>(type: "int", nullable: false),
                    SelfImprovementImportance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Attractiveness", "CarrerImportance", "Earnings", "Education", "FamilyImportance", "Gender", "Height", "HobbyImportance", "Latitude", "Longitude", "Name", "PartyingImportance", "Profession", "Religion", "SelfImprovementImportance", "SpiritualityImportance", "TravellingImportance" },
                values: new object[,]
                {
                    { 1, 67, 6, 3, 33326, 1, 4, 0, 217, 4, 16.0, 142.0, "Beatrice Hansen", 5, 5, 4, 3, 3, 2 },
                    { 73, 56, 3, 3, 73658, 1, 5, 1, 138, 1, -66.0, 154.0, "Matt Littel", 3, 7, 2, 1, 2, 5 },
                    { 72, 95, 6, 4, 20512, 0, 1, 0, 139, 5, -80.0, -159.0, "Chad Strosin", 1, 7, 4, 0, 4, 0 },
                    { 71, 63, 2, 5, 13276, 2, 4, 1, 204, 3, -77.0, -111.0, "Carrie Schultz", 2, 5, 2, 0, 0, 1 },
                    { 70, 21, 9, 1, 50466, 0, 2, 0, 141, 1, 21.0, 5.0, "Lorraine Prohaska", 0, 0, 5, 1, 5, 2 },
                    { 69, 67, 9, 2, 42051, 0, 2, 0, 140, 5, -17.0, 88.0, "Rosemarie Bradtke", 1, 6, 2, 2, 0, 0 },
                    { 68, 66, 3, 5, 20105, 1, 3, 1, 161, 5, 65.0, -168.0, "Colin Ferry", 2, 5, 0, 2, 2, 2 },
                    { 67, 97, 0, 2, 2912, 1, 1, 0, 175, 3, -35.0, -13.0, "Minnie Kessler", 3, 1, 5, 2, 2, 4 },
                    { 66, 42, 9, 3, 27346, 1, 3, 1, 202, 1, 33.0, -26.0, "Jeannie Mueller", 3, 6, 4, 3, 5, 1 },
                    { 65, 50, 10, 0, 83510, 0, 3, 1, 189, 4, -25.0, 170.0, "Jared Padberg", 2, 6, 3, 3, 4, 5 },
                    { 64, 19, 2, 3, 83749, 2, 4, 0, 225, 1, -2.0, 37.0, "Mae Quitzon", 3, 8, 2, 4, 2, 5 },
                    { 63, 85, 10, 1, 25295, 2, 0, 1, 154, 2, 66.0, 43.0, "Hope West", 5, 7, 2, 0, 4, 1 },
                    { 62, 30, 2, 5, 13309, 1, 1, 1, 153, 4, -44.0, -56.0, "Israel Stracke", 4, 4, 5, 3, 1, 3 },
                    { 61, 53, 6, 5, 54243, 1, 0, 1, 156, 4, -80.0, -167.0, "Nicole MacGyver", 1, 8, 2, 1, 4, 0 },
                    { 60, 86, 4, 5, 44446, 1, 1, 0, 162, 0, -53.0, -93.0, "Everett Mueller", 5, 0, 4, 5, 4, 3 },
                    { 59, 84, 9, 1, 42838, 0, 4, 1, 173, 1, 54.0, -50.0, "Ken Hirthe", 3, 8, 0, 3, 5, 1 },
                    { 58, 79, 0, 1, 85023, 2, 4, 0, 148, 3, 28.0, 175.0, "Elvira Halvorson", 0, 5, 4, 3, 0, 2 },
                    { 57, 66, 2, 5, 82519, 1, 3, 1, 171, 3, -71.0, 105.0, "Ronald Gerhold", 5, 3, 1, 4, 2, 4 },
                    { 56, 82, 9, 1, 55062, 2, 0, 0, 196, 2, 17.0, 112.0, "Curtis Paucek", 0, 4, 4, 2, 3, 3 },
                    { 55, 30, 7, 2, 58929, 2, 2, 1, 223, 3, 83.0, 156.0, "Alfredo Jast", 4, 7, 4, 2, 3, 4 },
                    { 54, 92, 6, 3, 27676, 2, 0, 1, 209, 2, 78.0, -177.0, "Wilson Kreiger", 4, 4, 3, 3, 3, 4 },
                    { 53, 64, 10, 5, 87850, 0, 1, 1, 213, 0, 68.0, 32.0, "Arlene Anderson", 1, 1, 4, 3, 3, 1 },
                    { 74, 84, 2, 0, 17676, 0, 2, 0, 222, 0, -42.0, -50.0, "Randy Rowe", 1, 5, 1, 0, 3, 1 },
                    { 52, 70, 2, 2, 4921, 1, 1, 0, 139, 3, -14.0, -164.0, "Marvin Kub", 0, 3, 2, 3, 3, 3 },
                    { 75, 44, 2, 5, 7228, 2, 1, 1, 135, 1, 7.0, 32.0, "Marshall Fahey", 5, 5, 3, 4, 4, 3 },
                    { 77, 80, 0, 3, 67357, 2, 2, 1, 196, 2, -57.0, -20.0, "Melinda Mante", 3, 5, 4, 2, 3, 3 },
                    { 98, 73, 0, 5, 79644, 2, 3, 0, 226, 5, -70.0, 22.0, "Della Medhurst", 0, 8, 1, 1, 3, 0 },
                    { 97, 45, 7, 5, 41504, 1, 1, 1, 149, 4, -27.0, 27.0, "Conrad Brown", 3, 4, 2, 0, 2, 4 },
                    { 96, 91, 6, 5, 4048, 0, 2, 0, 151, 5, 63.0, 70.0, "Noah Gutmann", 2, 6, 3, 0, 5, 2 },
                    { 95, 26, 7, 2, 41733, 1, 1, 1, 191, 0, -42.0, -55.0, "Audrey Hahn", 3, 2, 0, 4, 3, 4 },
                    { 94, 44, 6, 3, 95508, 2, 5, 1, 210, 2, -47.0, 6.0, "Dustin Haley", 5, 0, 0, 4, 5, 3 },
                    { 93, 87, 1, 1, 92382, 2, 0, 1, 181, 3, -30.0, 31.0, "Nick Kub", 4, 5, 5, 0, 2, 5 },
                    { 92, 91, 0, 2, 50622, 0, 5, 1, 178, 1, 89.0, -154.0, "Luis Stanton", 4, 6, 2, 1, 1, 0 },
                    { 91, 90, 6, 2, 95050, 0, 3, 0, 189, 4, 43.0, 54.0, "Velma Nienow", 2, 0, 3, 5, 5, 1 },
                    { 90, 49, 2, 4, 68346, 0, 3, 1, 183, 4, 73.0, 52.0, "Ervin Kunze", 1, 0, 3, 1, 3, 5 },
                    { 89, 66, 5, 3, 49799, 0, 1, 0, 208, 4, 27.0, -63.0, "Ismael Champlin", 2, 1, 5, 2, 2, 5 },
                    { 88, 53, 10, 3, 68806, 0, 3, 1, 222, 3, 64.0, -73.0, "Jorge Grady", 2, 1, 4, 5, 4, 1 },
                    { 87, 66, 3, 1, 97924, 1, 5, 0, 185, 5, -75.0, -24.0, "Sue O'Keefe", 2, 8, 0, 4, 0, 4 },
                    { 86, 34, 6, 3, 50968, 0, 4, 1, 142, 3, 14.0, 45.0, "Gwen Walter", 4, 0, 2, 3, 5, 3 },
                    { 85, 38, 9, 2, 18963, 1, 3, 1, 175, 2, -36.0, 68.0, "Kurt Goldner", 2, 3, 5, 1, 5, 5 },
                    { 84, 24, 10, 5, 59199, 0, 0, 1, 180, 5, -26.0, 156.0, "Marjorie Jacobson", 1, 3, 3, 1, 4, 3 },
                    { 83, 43, 3, 0, 38398, 2, 0, 0, 219, 3, -70.0, -46.0, "Gabriel Hermann", 5, 7, 2, 3, 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Attractiveness", "CarrerImportance", "Earnings", "Education", "FamilyImportance", "Gender", "Height", "HobbyImportance", "Latitude", "Longitude", "Name", "PartyingImportance", "Profession", "Religion", "SelfImprovementImportance", "SpiritualityImportance", "TravellingImportance" },
                values: new object[,]
                {
                    { 82, 42, 2, 3, 86538, 0, 1, 0, 204, 3, 3.0, -80.0, "Gail Hackett", 2, 8, 3, 5, 2, 0 },
                    { 81, 88, 1, 0, 86636, 0, 1, 1, 189, 0, 52.0, -2.0, "Wilma Okuneva", 2, 7, 5, 3, 0, 3 },
                    { 80, 21, 0, 5, 68153, 2, 1, 0, 187, 2, -12.0, 100.0, "Winston Beatty", 4, 8, 4, 5, 0, 0 },
                    { 79, 40, 1, 0, 49823, 0, 0, 0, 223, 0, 29.0, 167.0, "Amelia Hand", 5, 0, 1, 1, 5, 2 },
                    { 78, 20, 6, 3, 6021, 2, 0, 1, 225, 0, 45.0, -169.0, "Danny Crooks", 2, 1, 2, 0, 2, 4 },
                    { 76, 35, 1, 3, 46506, 0, 2, 1, 165, 3, -5.0, -108.0, "Glen Sipes", 5, 8, 0, 3, 2, 5 },
                    { 51, 80, 1, 4, 43401, 0, 3, 1, 130, 3, 12.0, -41.0, "Leon Grimes", 3, 2, 5, 4, 4, 4 },
                    { 50, 91, 2, 0, 45580, 2, 4, 1, 205, 5, 2.0, -51.0, "Ron Brekke", 5, 8, 3, 1, 5, 0 },
                    { 49, 23, 4, 3, 62664, 2, 0, 1, 171, 1, 49.0, -63.0, "Jerald Kuphal", 3, 1, 1, 2, 0, 1 },
                    { 22, 52, 1, 1, 53753, 2, 0, 0, 137, 1, 45.0, -143.0, "Miriam Erdman", 3, 7, 4, 1, 4, 1 },
                    { 21, 93, 5, 3, 66185, 2, 0, 0, 159, 3, 31.0, -175.0, "Jeremiah Osinski", 2, 0, 0, 5, 4, 3 },
                    { 20, 44, 8, 3, 24242, 2, 5, 1, 175, 4, -51.0, 110.0, "Scott Casper", 2, 1, 2, 5, 4, 5 },
                    { 19, 82, 6, 4, 62353, 1, 2, 0, 195, 2, -10.0, 113.0, "Bethany Russel", 4, 3, 2, 4, 0, 5 },
                    { 18, 44, 2, 4, 82600, 0, 2, 1, 228, 5, 12.0, -106.0, "Loretta Fay", 0, 6, 5, 0, 0, 3 },
                    { 17, 31, 0, 3, 13966, 1, 2, 0, 170, 0, -80.0, 135.0, "Erma Koch", 0, 0, 0, 5, 2, 4 },
                    { 16, 35, 1, 4, 8538, 2, 3, 0, 175, 0, 61.0, 10.0, "Terrell Wiegand", 1, 1, 4, 1, 1, 0 },
                    { 15, 38, 8, 1, 59254, 2, 0, 0, 148, 2, -54.0, -62.0, "Shelly Gaylord", 0, 0, 0, 3, 5, 4 },
                    { 14, 72, 1, 2, 59427, 1, 5, 0, 191, 0, 71.0, -167.0, "Lula Kilback", 5, 5, 0, 2, 1, 2 },
                    { 13, 69, 1, 4, 14643, 0, 3, 1, 202, 1, 17.0, -70.0, "Heidi Hammes", 5, 0, 3, 2, 5, 2 },
                    { 12, 68, 10, 0, 35291, 0, 1, 1, 169, 5, -54.0, 70.0, "Tricia Runolfsson", 0, 8, 3, 5, 0, 2 },
                    { 11, 88, 2, 2, 37033, 0, 3, 1, 200, 3, -79.0, 159.0, "Shaun Kihn", 3, 1, 1, 5, 5, 1 },
                    { 10, 43, 5, 1, 50678, 1, 1, 1, 157, 4, -45.0, 69.0, "Katherine Boehm", 2, 3, 2, 1, 5, 2 },
                    { 9, 39, 5, 1, 72305, 0, 1, 0, 135, 2, -25.0, 132.0, "Gabriel Legros", 1, 6, 1, 0, 0, 3 },
                    { 8, 54, 10, 3, 70927, 0, 0, 1, 156, 0, -80.0, 64.0, "Rochelle Emmerich", 5, 1, 5, 0, 1, 2 },
                    { 7, 86, 1, 0, 67620, 0, 0, 0, 216, 1, 49.0, 142.0, "Evan Schaden", 2, 5, 3, 2, 0, 0 },
                    { 6, 95, 6, 3, 67975, 0, 4, 1, 220, 0, 26.0, -1.0, "Nellie Davis", 5, 3, 0, 4, 5, 5 },
                    { 5, 32, 7, 2, 882, 0, 2, 1, 187, 4, 70.0, -77.0, "Eileen Schumm", 5, 3, 1, 4, 0, 0 },
                    { 4, 65, 3, 0, 52806, 1, 1, 1, 183, 2, -63.0, -100.0, "Joyce Waters", 4, 2, 0, 0, 0, 4 },
                    { 3, 98, 1, 2, 55579, 1, 2, 1, 174, 5, 89.0, 57.0, "Archie Schimmel", 1, 7, 5, 5, 0, 4 },
                    { 2, 50, 6, 0, 46573, 1, 3, 0, 138, 3, -52.0, 125.0, "Maxine Toy", 0, 1, 3, 3, 0, 4 },
                    { 23, 94, 9, 4, 8895, 1, 2, 1, 157, 4, -31.0, -87.0, "Alton Buckridge", 0, 4, 0, 5, 5, 2 },
                    { 24, 69, 3, 1, 22009, 0, 3, 1, 178, 0, -48.0, 122.0, "Karen Beatty", 4, 5, 0, 1, 0, 0 },
                    { 25, 85, 7, 3, 21512, 0, 3, 1, 145, 4, 22.0, -42.0, "Herbert Lowe", 4, 2, 3, 0, 2, 2 },
                    { 26, 94, 8, 5, 49527, 2, 3, 0, 160, 2, 64.0, -34.0, "Benjamin Dickens", 3, 3, 1, 5, 4, 3 },
                    { 48, 77, 1, 5, 56656, 0, 4, 1, 151, 3, 44.0, -170.0, "Emilio Renner", 4, 2, 0, 5, 1, 1 },
                    { 47, 67, 10, 2, 46331, 1, 5, 1, 184, 2, 82.0, -113.0, "Hugo Kemmer", 3, 5, 0, 0, 5, 2 },
                    { 46, 29, 2, 4, 99771, 2, 0, 0, 133, 4, -49.0, 82.0, "Randy Walker", 2, 7, 3, 5, 1, 4 },
                    { 45, 37, 3, 1, 94966, 1, 2, 1, 219, 4, 49.0, 92.0, "Otis Hartmann", 5, 5, 3, 4, 3, 2 },
                    { 44, 84, 1, 1, 41224, 2, 0, 1, 166, 1, 53.0, 24.0, "Ethel Smith", 1, 2, 5, 2, 3, 4 },
                    { 43, 98, 6, 4, 82739, 1, 5, 1, 228, 1, 29.0, 26.0, "Doyle Fahey", 3, 6, 5, 3, 0, 1 },
                    { 42, 88, 9, 5, 36028, 0, 2, 0, 156, 5, -10.0, 85.0, "Adam Green", 4, 2, 4, 5, 0, 4 },
                    { 41, 55, 5, 4, 65469, 2, 2, 0, 176, 0, -37.0, -26.0, "Kristopher Wyman", 5, 7, 3, 0, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Attractiveness", "CarrerImportance", "Earnings", "Education", "FamilyImportance", "Gender", "Height", "HobbyImportance", "Latitude", "Longitude", "Name", "PartyingImportance", "Profession", "Religion", "SelfImprovementImportance", "SpiritualityImportance", "TravellingImportance" },
                values: new object[,]
                {
                    { 40, 52, 6, 4, 96255, 1, 0, 0, 162, 2, 26.0, 88.0, "Patty MacGyver", 2, 1, 2, 5, 0, 2 },
                    { 39, 49, 1, 1, 37588, 0, 0, 1, 172, 4, 28.0, 73.0, "Colin Bradtke", 3, 4, 4, 5, 2, 5 },
                    { 99, 21, 5, 1, 9755, 2, 2, 1, 185, 4, -80.0, -86.0, "Elias Mraz", 5, 1, 5, 0, 4, 4 },
                    { 38, 52, 6, 3, 24611, 2, 4, 0, 228, 3, -59.0, -4.0, "Rachel Bins", 4, 7, 3, 4, 1, 2 },
                    { 36, 76, 0, 3, 22018, 0, 5, 1, 215, 5, -73.0, 48.0, "Vernon Mayert", 3, 0, 3, 5, 1, 0 },
                    { 35, 39, 0, 3, 38628, 2, 1, 0, 194, 4, 43.0, -5.0, "Catherine Volkman", 1, 1, 5, 4, 0, 0 },
                    { 34, 39, 3, 2, 22107, 1, 1, 1, 190, 2, 6.0, -5.0, "Marion Spencer", 2, 3, 3, 3, 4, 0 },
                    { 33, 97, 4, 1, 12506, 2, 2, 1, 202, 0, -13.0, 122.0, "Darrin Wolff", 2, 5, 2, 1, 5, 3 },
                    { 32, 31, 6, 3, 11211, 1, 4, 1, 172, 3, 84.0, 4.0, "Guy Rempel", 1, 1, 5, 0, 4, 2 },
                    { 31, 72, 10, 5, 54181, 2, 5, 1, 138, 1, -54.0, -99.0, "Paul Feil", 1, 1, 1, 2, 3, 5 },
                    { 30, 81, 6, 0, 77639, 1, 2, 1, 190, 4, -74.0, 93.0, "Taylor Johnston", 1, 3, 2, 1, 3, 5 },
                    { 29, 82, 6, 0, 64901, 1, 1, 0, 207, 2, 38.0, -103.0, "Justin Wyman", 2, 3, 1, 2, 4, 4 },
                    { 28, 100, 5, 0, 31125, 2, 0, 1, 218, 3, 86.0, -13.0, "Jenna Hahn", 2, 5, 1, 1, 0, 0 },
                    { 27, 30, 3, 4, 49652, 1, 0, 1, 145, 5, 75.0, -100.0, "Christine Leffler", 1, 0, 4, 4, 2, 1 },
                    { 37, 27, 2, 0, 50220, 2, 1, 1, 212, 3, -9.0, -109.0, "Bernard Kuhlman", 1, 4, 3, 5, 1, 3 },
                    { 100, 27, 9, 2, 18307, 0, 1, 0, 154, 2, 74.0, 84.0, "Lucille Bosco", 2, 0, 3, 1, 1, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
