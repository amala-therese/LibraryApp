namespace libDomain.Entities;
public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Availability { get; set; }
        public virtual List<LendingHistory>? LendingHistory { get; set; }

        
    }