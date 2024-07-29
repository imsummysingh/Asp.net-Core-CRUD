using ServiceContracts;
using System;
using System.Collections.Generic;
using Services;
using ServiceContracts.DTO;
using ServiceContracts.Enums;


namespace CRUDTests
{
    public class PersonServiceTest
    {
        private readonly IPersonService _personService;

        public PersonServiceTest()
        {
            _personService = new PersonService();
        }


        #region AddPerson

        //when we supply null values as PersonAddRequest, it should throw ArgumentNullException
        [Fact]
        public void AddPerson_NullPerson()
        {
            //arrange
            PersonAddRequest? personAddRequest = null;

            //act & assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                _personService.AddPerson(personAddRequest);
            });
        }

        //when we supply null values as PersonName, it should throw ArgumentException ->email,dob etc as null
        [Fact]
        public void AddPerson_PersonNameIsNull()
        {
            //arrange
            PersonAddRequest? personAddRequest = new PersonAddRequest()
            {
                PersonName = null
            };

            //act & assert
            Assert.Throws<ArgumentException>(() =>
            {
                _personService.AddPerson(personAddRequest);
            });
        }

        //when we supply proper person details, it should insert the person into person list,
        //and it should return an object of personResponse which includes with newly generated PersonId
        [Fact]
        public void AddPerson_ProperPersonDetails()
        {
            //arrange
            PersonAddRequest? personAddRequest = new PersonAddRequest()
            {
                PersonName = "Ranjeet",
                Email = "ranjo@gmail.com",
                Address = "Gurgaon",
                CountryId = Guid.NewGuid(),
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("1995-01-30"),
                ReceiveNewsLetters = true
            };

            //act 
            PersonResponse person_response_from_add = _personService.AddPerson(personAddRequest);
            List<PersonResponse> person_list=_personService.GetAllPersons();

            //assert
            Assert.True(person_response_from_add.PersonId != Guid.Empty);
            Assert.Contains(person_response_from_add, person_list);
        }

        #endregion
    }
}
