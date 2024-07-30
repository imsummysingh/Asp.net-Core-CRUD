namespace Entities
{
    /// <summary>
    /// Domain model for storing the country details.
    /// </summary>
    public class Country
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
    }
}
