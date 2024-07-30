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
            _countryService = new CountriesService(false);
        }

        #region AddCountry
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
            CountryAddRequest? request = new CountryAddRequest()
            {
                CountryName = "Japan"
            };                      

            //act
            CountryResponse response = _countryService.AddCountry(request);
            List<CountryResponse> countries_from_GetAllCountries=_countryService.GetAllCountries();

            //assert
            Assert.True(response.CountryId != Guid.Empty);
            Assert.Contains(response,countries_from_GetAllCountries);
        }

        #endregion

        #region GetAllCountries        

        //the list of countries should be emoty by default(before adding any countries)
        [Fact]
        public void GetAllCountries_EmptyLiss()
        {
            //acts
            List<CountryResponse> actual_country_Response_list = _countryService.GetAllCountries();

            //assert
            Assert.Empty(actual_country_Response_list);
        }


        [Fact]
        public void GetAllCountries_AddFewCountries()
        {
            //Arrange
            List<CountryAddRequest> country_request_list = new List<CountryAddRequest>()
            {
                new CountryAddRequest() { CountryName="USA" },
                new CountryAddRequest() { CountryName="India" },
                new CountryAddRequest() { CountryName="Korea" }
            };

            //Act
            List<CountryResponse> country_list_from_add_country = new List<CountryResponse>();
            foreach(CountryAddRequest country_request in country_request_list)
            {
                country_list_from_add_country.Add(_countryService.AddCountry(country_request));
            }

            List<CountryResponse> actualCountryResponseList=_countryService.GetAllCountries();

            //read each element from countries_list_from_add_Country
            foreach (CountryResponse expected_Country in country_list_from_add_country)
            {
                Assert.Contains(expected_Country, actualCountryResponseList);
            }
        }

        #endregion

        #region GetCountryByCountryId
        
        //if we supply null as countryId, it should return null as country response
        [Fact]
        public void GetCountryByCountryId_NullCountryId()
        {
            //arrange
            Guid? countryId = null;

            //act
            CountryResponse? country_response_from_get_method=_countryService.GetCountryByCountryId(countryId);

            //assert
            Assert.Null(country_response_from_get_method);
        }

        //if we supply valid countryId, it should return matching country details as countryResponse object
        [Fact]
        public void GetCountryByCountryId_ValidCountryId()
        {
            //arrange
            CountryAddRequest? country_add_request = new CountryAddRequest()
            {
                CountryName = "China"
            };
            CountryResponse country_response_from_add=_countryService.AddCountry(country_add_request);


            //act
            CountryResponse? country_response_from_get=_countryService.GetCountryByCountryId(country_response_from_add.CountryId);

            //assert
            Assert.Equal(country_response_from_add, country_response_from_get);
        }

        #endregion
    }
}
