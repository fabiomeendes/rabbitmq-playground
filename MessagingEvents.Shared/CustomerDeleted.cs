namespace MessagingEvents.Shared
{
    public class CustomerDeleted
    {
        public CustomerDeleted() { }

        public CustomerDeleted(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
