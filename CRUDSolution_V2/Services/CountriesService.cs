﻿using ServiceContracts;
using ServiceContracts.DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        //private field
        private readonly ICountriesRepository _countriesRepository;


        public CountriesService(ICountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;            
        }
        public async Task<CountryResponse> AddCountry(CountryAddRequest? countryAddRequest)
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
            if(await _countriesRepository.GetCountryByCountryName(countryAddRequest.CountryName)!=null)
            {
                throw new ArgumentException("Country Name already exists");
            }


            //convert object from CountryAddRequest to Country Type
            Country country= countryAddRequest.ToCountry();

            //generate Guid for CountryId
            country.CountryId = Guid.NewGuid();

            //add country object into _Countries
            await _countriesRepository.AddCountry(country);           

            return country.ToCountryResponse();
        }

        public async Task<List<CountryResponse>> GetAllCountries()
        {
            return (await _countriesRepository.GetAllCountries()).Select(country=>country.ToCountryResponse()).ToList();
        }

        public async Task<CountryResponse?> GetCountryByCountryId(Guid? countryId)
        {
            if(countryId == null)
            {
                return null;
            }

            Country? country_response_from_list=await _countriesRepository.GetCountryByCountryId(countryId.Value);

            if(country_response_from_list == null) { return null; }
            return country_response_from_list.ToCountryResponse();
        }
    }
}
