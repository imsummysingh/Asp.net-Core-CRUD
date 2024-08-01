﻿using ServiceContracts;
using ServiceContracts.DTO;
using Entities;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        //private field
        private readonly PersonsDbContext _db;


        public CountriesService(PersonsDbContext personsDbContext)
        {
            _db = personsDbContext;            
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
            if(_db.Countries.Count(temp=>temp.CountryName==countryAddRequest.CountryName)>0)
            {
                throw new ArgumentException("Country Name already exists");
            }


            //convert object from CountryAddRequest to Country Type
            Country country= countryAddRequest.ToCountry();

            //generate Guid for CountryId
            country.CountryId = Guid.NewGuid();

            //add country object into _Countries
            _db.Countries.Add(country);
            _db.SaveChanges();

            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            return _db.Countries.Select(country=>country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryId(Guid? countryId)
        {
            if(countryId == null)
            {
                return null;
            }

            Country? country_response_from_list=_db.Countries.FirstOrDefault(temp=>temp.CountryId==countryId);

            if(country_response_from_list == null) { return null; }
            return country_response_from_list.ToCountryResponse();
        }
    }
}
