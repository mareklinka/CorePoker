namespace CorePoker.Data
{
    // infortunately, EF Core does not support transparent m:n relationships without the binding table
    // let's hope this kind of mapping will become obsolete soon
    public class TablePlayer
    {
        public int TableId { get; set; }

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public Table Table { get; set; }
    }
}