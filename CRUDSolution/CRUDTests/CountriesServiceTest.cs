using ServiceContracts;
using Entities;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using Services;


namespace CRUDTests
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countryService;

        public CountriesServiceTest()
        {
            _countryService = new CountriesService();
        }

        //when COuntryAddRequest is null, it should throw ArgumentNullException
        [Fact]
        public void AddCountry_NullCountry()
        {
            //Arrange
            CountryAddRequest request = null;

            //assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //act
                _countryService.AddCountry(request);
            });            
        }


        //When the countryName is null, it should throw ArgumentException
        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            //Arrange
            CountryAddRequest request = new CountryAddRequest()
            {
                CountryName = null
            };

            //assert
            Assert.Throws<ArgumentException>(() =>
            {
                //act
                _countryService.AddCountry(request);
            });
        }


        //when countryName is duplicate, it should throw ArgumentException
        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            //Arrange
            CountryAddRequest request1 = new CountryAddRequest()
            {
                CountryName = "USA"
            };
            CountryAddRequest request2 = new CountryAddRequest()
            {
                CountryName = "USA"
            };

            //assert
            Assert.Throws<ArgumentException>(() =>
            {
                //act
                _countryService.AddCountry(request1);
                _countryService.AddCountry(request2);
            });
        }


        //When you supply proper country name, it should insert (add) the country to the existing list of countries.
        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            //Arrange
            CountryAddRequest request = new CountryAddRequest()
            {
                CountryName = "Japan"
            };                      

            //act
            CountryResponse response = _countryService.AddCountry(request);

            //assert
            Assert.True(response.CountryId != Guid.Empty);
        }
    }
}
