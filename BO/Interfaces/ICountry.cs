namespace BO.Interfaces
{
    public interface ICountry
    {
        int Id { get; set; }
        string Name { get; set; }

        string ToString();
    }
}