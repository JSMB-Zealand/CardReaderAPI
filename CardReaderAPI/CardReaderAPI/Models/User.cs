namespace CardReaderAPI.Models
{
    public class User
    {
        private string id;
        private string name;
        private string rank;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Rank { get => rank; set => rank = value; }

        public User()
        {
        }

        public User(string id, string name, string rank)
        {
            Id = id;
            Name = name;
            Rank = rank;
        }
    }
}
