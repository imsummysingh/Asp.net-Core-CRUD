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

        //it compares the current object to another object of CountryResponse type and returns true,
        //if both values are same; otherwise returns false
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != typeof(CountryResponse))
            {
                return false;
            }

            CountryResponse country_to_compare = (CountryResponse)obj;

            return this.CountryId==country_to_compare.CountryId && this.CountryName==country_to_compare.CountryName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// converting country object to country response
    /// (We used to do this in controller for API)
    /// </summary>
    public static class CountryExtensions
    {
        //Converts from country object to country response object
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
