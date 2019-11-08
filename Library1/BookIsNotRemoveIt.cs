namespace Library1
{
    public class BookRemoveIt
    {
        public enum Status
        {
            NoSuchBook,
            BookAlreadyLoaned,
            Open,
            NoSuchBookLoan
        };

        public Status BookIsNotRemoveItStatus;
        public decimal Amount;
    }
}