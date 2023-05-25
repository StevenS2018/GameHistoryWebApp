namespace GameHistoryWebApp.Models
{
    public class GameHistoryModel
    {
        public int Id { get; set; }
        public string GameName { get; set; } = string.Empty;
        public int YearRelease { get; set; }

        public int AgeRating { get; set; }

        public string GameGenre { get; set; } = string.Empty;




        public GameHistoryModel(int id, string gameName, int yearRelease, int ageRating, string gameGenre)
        {
            Id = id;
            GameName = gameName;
            YearRelease = yearRelease;
            AgeRating = ageRating;
            GameGenre = gameGenre;
        }

        public GameHistoryModel()
        {

        }
    }
}
