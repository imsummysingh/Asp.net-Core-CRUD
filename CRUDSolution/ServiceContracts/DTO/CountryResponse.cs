using System;
using Entities;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO Class that is used as return type for CountriesService methods.
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
    }

    /// <summary>
    /// converting country object to country response
    /// (We used to do this in controller for API)
    /// </summary>
    public static class CountryExtensions
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse()
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName
            };
        }
    }
}
