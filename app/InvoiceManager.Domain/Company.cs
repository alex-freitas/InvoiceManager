namespace InvoiceManager.Domain
{
    public class Company
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Company(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
