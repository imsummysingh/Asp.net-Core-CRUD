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

        /// <summary>
        /// Returns all countries from the list
        /// </summary>
        /// <returns>All countries from the list as CountryResponse<CountryResponse></M></returns>
        List<CountryResponse> GetAllCountries();

        /// <summary>
        /// Return a country object based on the given country Id
        /// </summary>
        /// <param name="countryId">CountryId(guid) to search</param>
        /// <returns>Matching country as country response object</returns>
        CountryResponse? GetCountryByCountryId(Guid? countryId);
    }
}
