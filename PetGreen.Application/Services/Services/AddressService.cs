using PetGreen.Application.Services.Interfaces;
using PetGreen.Application.Services.Validators;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using System.Linq;

namespace PetGreen.Application.Services.Services
{
    public class AddressService : BaseEntity, IAddressService
    {
        private readonly BaseService<Address> _baseService;
        private readonly BaseService<City> _cityService;
        private readonly BaseService<State> _stateService;
        private readonly Db _context;

        public AddressService(Db context)
        {
            _context = context;
            _baseService = new BaseService<Address>(context);
            _cityService = new BaseService<City>(context);
            _stateService = new BaseService<State>(context);
        }

        /// <summary>
        /// Adiciona um novo registro na tabela CDAddress
        /// </summary>
        /// <param name="address"></param>
        public void Register(Address address)
        {
            try
            {
                City city = (from c in _context.City where c.IBGE == address.City.IBGE select c).FirstOrDefault();

                if (city == null)
                {
                    State state = (from s in _context.State where s.UF == address.City.State.UF select s).FirstOrDefault();

                    if ( state == null)
                    {
                        _stateService.Post<StateValidator>(address.City.State);
                        address.City.StateID = address.City.State.ID;
                    } else
                    {
                        address.City.StateID = state.ID;
                    }

                    _cityService.Post<CityValidator>(address.City);
                    address.CityID = address.City.ID;
                } else
                {
                    address.CityID = city.ID;
                }

                _baseService.Post<AddressValidator>(address);
            }
            catch
            {
                throw;
            }
        }
    }
}

