using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Domain model for storing the country details.
    /// </summary>
    public class Country
    {
        //countryId as primary key
        [Key]   
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
    }
}
