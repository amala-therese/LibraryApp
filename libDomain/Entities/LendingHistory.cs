
namespace libDomain.Entities;

public class LendingHistory
{
    
    public int Id { get; set; }
  
    public int BookID { get; set; }
    public Book Book { get; set; }

    
    public int UserID { get; set; }
    public User User { get; set; }

    public DateTime LendDate { get; set; }
    public DateTime ReturnDate { get; set; }
}
