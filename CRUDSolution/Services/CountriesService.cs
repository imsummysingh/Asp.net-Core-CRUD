using ServiceContracts;
using ServiceContracts.DTO;
using Entities;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        //private field
        private readonly List<Country> _countries;

        public CountriesService()
        {
            _countries = new List<Country>();
        }
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            //validation : CountryAddRequest parameter cannot be null
            if (countryAddRequest == null) 
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            //validation: CountryName is null then throw exception
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //validation: duplicateCountryName is not allowed
            if(_countries.Where(temp=>temp.CountryName==countryAddRequest.CountryName).Count()>0)
            {
                throw new ArgumentException("Country Name already exists");
            }


            //convert object from CountryAddRequest to Country Type
            Country country= countryAddRequest.ToCountry();

            //generate Guid for CountryId
            country.CountryId = Guid.NewGuid();

            //add country object into _Countries
            _countries.Add(country);

            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            return _countries.Select(country=>country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryId(Guid? countryId)
        {
            if(countryId == null)
            {
                return null;
            }

            Country? country_response_from_list=_countries.FirstOrDefault(temp=>temp.CountryId==countryId);

            if(country_response_from_list == null) { return null; }
            return country_response_from_list.ToCountryResponse();
        }
    }
}
