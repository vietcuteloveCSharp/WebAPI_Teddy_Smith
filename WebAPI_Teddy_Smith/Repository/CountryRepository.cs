using AutoMapper;
using WebAPI_Teddy_Smith.Data;
using WebAPI_Teddy_Smith.Interface;
using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Repository
{
    public class CountryRepository :ICountryRepository
    {   private readonly DataContext _context;
      
        public CountryRepository(DataContext _context)
        {
            this._context = _context;
            
        }

        public bool countriesExist(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(c => c.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }
    }
    
}
