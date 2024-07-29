using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// interface for the country service which will implement the business logic
    /// Represent business logic for manipulating country entity
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Adds a country object to the list of countries
        /// </summary>
        /// <param name="countryAddRequest">Country object to add</param>
        /// <returns>Returns the country object after adding it(including newly generated country id)</returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);
    }
}
