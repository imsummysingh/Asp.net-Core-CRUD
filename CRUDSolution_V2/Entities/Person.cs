using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Person domain model class
    /// </summary>
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }
        //nvarchar(max)
        [StringLength(40)]
        public string? PersonName { get; set; }
        [StringLength(40)]
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [StringLength(10)]
        public string? Gender { get; set; }
        //unique Identifier
        public Guid? CountryId { get; set; }
        [StringLength(200)]
        public string? Address { get; set; }
        //bit
        public bool? ReceiveNewsLetters { get; set; }

        //Tax Identication Number
        public string? TIN { get; set; }

        public Country? Country { get; set; }
    }
}
