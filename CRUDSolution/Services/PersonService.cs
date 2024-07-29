using System;
using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using System.ComponentModel.DataAnnotations;
using Services.Helpers;

namespace Services
{
    public class PersonService : IPersonService
    {
        //private field
        private readonly List<Person> _persons;
        private readonly ICountriesService _countries;

        public PersonService()
        {
            _persons = new List<Person>();
            _countries = new CountriesService();
        }
        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countries.GetCountryByCountryId(person.CountryId)?.CountryName;
            return personResponse;
        }
        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            //check if PerssonRequest is not null
            if(personAddRequest == null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }

            //check if person name is not null
            //if(string.IsNullOrEmpty(personAddRequest.PersonName))
            //{
            //    throw new ArgumentException("Person name cannot be blank");
            //}



            ////model validation - for multiple validation
            //ValidationContext validationContext = new ValidationContext(personAddRequest);
            //List<ValidationResult> validationResults = new List<ValidationResult>();
            //bool isValid=Validator.TryValidateObject(personAddRequest, validationContext, validationResults, true);

            //if (!isValid)
            //{
            //    throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            //}

            //validation-> from helper
            //model validation
            ValidationHelper.ModelValidation(personAddRequest);

            //convert personAddRequest into person Type
            Person person= personAddRequest.ToPerson();

            //generate person id
            person.PersonId = Guid.NewGuid();

            //add person object to persons list
            _persons.Add(person);

            //convert person object to persosResponse type
            return ConvertPersonToPersonResponse(person);

        }

        public List<PersonResponse> GetAllPersons()
        {
            throw new NotImplementedException();
        }
    }
}
