using CountryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;

namespace CountryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        DataContext DataContext;
        public CountryController(DataContext dataContext)
        {
            DataContext = dataContext;
        }


        [HttpGet]
        public IActionResult GetAllCountries()
        {
            return Ok(DataContext.Countries.ToList());
        }
   
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetCountry(Guid id) {
           var country=  DataContext.Countries.Find(id);
            if (country == null)
            {
                return NotFound(); 
            }
            else  
                return Ok(country);    
        }

      
        [HttpPost]
        public IActionResult AddCountry(Country country) {
            var newCountry = new Country()
            {
                Name = country.Name,
                Population = country.Population,
                Capital = country.Capital,
                Area = country.Area,
                Religion = country.Religion,

            };

            DataContext.Countries.Add(newCountry);
            DataContext.SaveChanges();
            return Ok(newCountry);
        }

        [HttpPut]
        public IActionResult EditCountry(Guid id,Country country) {
            var _country = DataContext.Countries.Find(id);
            if(_country is null)
            {
                return NotFound();
            }

            _country.Name = country.Name;
            _country.Capital = country.Capital;
            _country.Area = country.Area;
            _country.Religion = country.Religion;
            _country.Population = country.Population;

            DataContext.SaveChanges();
            return Ok(_country);
        }

        [HttpDelete]
        public IActionResult DeleteCountry(Guid id)
        {
            var country = DataContext.Countries.Find(id);
            if (country is null) { return NotFound(); }

            DataContext.Countries.Remove(country);
            DataContext.SaveChanges();
            return Ok();
        }
    }
}
