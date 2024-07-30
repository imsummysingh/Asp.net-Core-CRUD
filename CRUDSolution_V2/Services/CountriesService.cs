using ServiceContracts;
using ServiceContracts.DTO;
using Entities;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        //private field
        private readonly List<Country> _countries;

        public CountriesService(bool initialize = true)
        {
            _countries = new List<Country>();
            if (initialize)
            {
                _countries.AddRange(new List<Country>() { 
                new Country() { CountryId = Guid.Parse("1AB8D7A5-6E5C-4DDA-AC50-CB18AFBE230E"), CountryName="USA" },
                new Country() { CountryId = Guid.Parse("DF1E2346-A90D-4311-A33C-08FB97072C91"), CountryName = "India" },
                new Country() { CountryId = Guid.Parse("9A45F1C4-2426-4EC7-B20F-128C758C6A0B"), CountryName = "Canada" },
                new Country() { CountryId = Guid.Parse("F9006EEB-F093-4517-9D61-B835C4056524"), CountryName = "UK" },
                new Country() { CountryId = Guid.Parse("4EE22C5A-1884-4A90-9928-B5312C0D8B59"), CountryName = "Australia" } 
                });                               

            }
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
