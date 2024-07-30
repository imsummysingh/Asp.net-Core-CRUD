using Entities;
using System;


namespace ServiceContracts.DTO
{   
    /// <summary>
    /// DTO for adding country
    /// does not require the Id because it will generate automatically
    /// </summary>
    public class CountryAddRequest
    {
        public string? CountryName { get; set; }
        public Country ToCountry()
        {
            return new Country()
            {
                CountryName = CountryName
            };
        }
    }
}
