using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents DTO Class that is used as return type of most methods of person service
    /// </summary>
    public class PersonResponse
    {
        public Guid PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }
        public Guid? CountryId { get; set; }
        public string? Address { get; set; }
        public bool? ReceiveNewsLetters { get; set; }
        public double? Age { get; set; }

        /// <summary>
        /// Compares the current object data with parameter object
        /// </summary>
        /// <param name="obj">The personResponse Object to compare</param>
        /// <returns>True or false, indicating whether all person details are matched with the specidfied parameter object</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) {  return false; }

            if(obj.GetType() != typeof(PersonResponse)) { return false; }

            PersonResponse person = (PersonResponse)obj;

            return this.PersonId==person.PersonId && this.PersonName == person.PersonName 
                    && this.Email==person.Email && this.DateOfBirth==person.DateOfBirth 
                    && this.Gender==person.Gender
                    && this.CountryId==person.CountryId && this.Address==person.Address 
                    && this.ReceiveNewsLetters==person.ReceiveNewsLetters;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
    public static class PersonExtensions
    {
        /// <summary>
        /// An extension method to convert an object of Person class into PersonResponse class
        /// </summary>
        /// <param name="person">The Person object to convert</param>
        /// /// <returns>Returns the converted PersonResponse object</returns>
        public static PersonResponse ToPersonResponse(this Person person)
        {
            //person => convert => PersonResponse
            return new PersonResponse()
            {
                PersonId = person.PersonId,
                PersonName = person.PersonName,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
                ReceiveNewsLetters = person.ReceiveNewsLetters,
                Address = person.Address,
                CountryId = person.CountryId,
                Gender = person.Gender,
                Age = (person.DateOfBirth != null) ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25) : null
            };
        }
    }
}
