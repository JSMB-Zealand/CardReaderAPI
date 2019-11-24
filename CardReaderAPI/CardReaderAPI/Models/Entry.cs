using System;

namespace CardReaderAPI.Models
{
    public class Entry: User
    {
        public DateTime Time;

        public Entry()
        {

        }

        public Entry(string id, string name, string rank, DateTime time)
        {
            Id = id;
            Name = name;
            Rank = rank;
            Time = time;
        }
    }
}
