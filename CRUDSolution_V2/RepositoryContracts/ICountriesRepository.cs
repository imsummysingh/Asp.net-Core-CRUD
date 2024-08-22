using Entities;

namespace RepositoryContracts
{
    /// <summary>
    /// Represents data access logic for managing person entiry
    /// </summary>
    public interface ICountriesRepository
    {
        /// <summary>
        /// Adds a new country object to the data store
        /// </summary>
        /// <param name="country">Country object to add</param>
        /// <returns>Returns the country object after adding it to the data store.</returns>
        Task<Country> AddCountry(Country country);

        /// <summary>
        /// Returns all countries in the data store.
        /// </summary>
        /// <returns></returns>
        Task<List<Country>> GetAllCountries();

        /// <summary>
        /// Returns a country object based on the country id, otherwise returns null value
        /// </summary>
        /// <param name="countryId">CountryId to search</param>
        /// <returns>Matching country or null</returns>
        Task<Country?> GetCountryByCountryId(Guid countryId);

        /// <summary>
        /// Returns a country object based on the country name, otherwise retuns null
        /// </summary>
        /// <param name="countryName">countryName to search</param>
        /// <returns>Mathcing country or null</returns>
        Task<Country?> GetCountryByCountryName(string countryName);
    }
}
