using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Interface
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
        bool countriesExist(int id);
    }
}
