using System;
using ServiceContracts.DTO;
namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulation person entity
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Adds a new person into the list of persons
        /// </summary>
        /// <param name="personAddRequest">Person to add</param>
        /// <returns>Returns the same person details, along with newly generated PersonId</returns>
        PersonResponse AddPerson(PersonAddRequest? personAddRequest);

        /// <summary>
        /// Returns all person
        /// </summary>
        /// <returns>Returns a list of objects of PersonRespons type</returns>
        List<PersonResponse> GetAllPersons();
    }
}
