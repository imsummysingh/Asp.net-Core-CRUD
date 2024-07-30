using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services;
using System.Globalization;

namespace CRUD.Controllers
{
    [Route("[controller]")]
    public class PersonsController_WithoutTagHelper : Controller
    {
        //private field
        private readonly IPersonService _personService;
        private readonly ICountriesService _countriesService;

        public PersonsController_WithoutTagHelper(IPersonService personService, ICountriesService countriesService)
        {
            _personService = personService;
            _countriesService = countriesService;
        }

        //[Route("persons/index")]
        //[Route("/")]

        //Url: index
        [Route("[action]")]
        [Route("/")]
        public IActionResult Index(string searchBy, string? searchString, string sortBy = nameof(PersonResponse.PersonName), SortOrderOptions sortOrder = SortOrderOptions.ASC)
        {
            //search
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                { nameof(PersonResponse.PersonName), "Person Name" },
                { nameof(PersonResponse.Email), "Email" },
                { nameof(PersonResponse.DateOfBirth), "Date of Birth" },
                { nameof(PersonResponse.Gender), "Gender" },
                { nameof(PersonResponse.CountryId), "Country" },
                { nameof(PersonResponse.Address), "Address" }
            };
            List<PersonResponse> persons = _personService.GetFilteredPersons(searchBy, searchString);
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;

            //Sort
            List<PersonResponse> sortedPersons = _personService.GetSortedPersons(persons, sortBy, sortOrder);
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSortOrder = sortOrder.ToString();

            return View(sortedPersons);  //views/persons/index.cshtml
        }

        //Executes when the user clicks on "Create Person" hyperlink (while opening the create view)
        //[Route("persons/create")]
        //[HttpGet]
        //Url: persons/create
        [Route("[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            List<CountryResponse> countries = _countriesService.GetAllCountries();
            ViewBag.Countries = countries;

            return View();
        }

        //[HttpPost]
        //[Route("persons/create")]
        [HttpPost]
        //Url: persons/create
        [Route("[action]")]
        public IActionResult Create(PersonAddRequest personAddRequest)
        {
            if (!ModelState.IsValid)
            {
                List<CountryResponse> countries = _countriesService.GetAllCountries();
                ViewBag.Countries = countries;

                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View();
            }

            //call the service method
            PersonResponse personResponse = _personService.AddPerson(personAddRequest);

            //navigate to Index() action method (it makes another get request to "persons/index"
            return RedirectToAction("Index", "Persons");
        }
    }
}
