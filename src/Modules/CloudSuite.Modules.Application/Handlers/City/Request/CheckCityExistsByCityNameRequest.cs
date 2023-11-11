using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Hadlers.City.Request
{
    public class CheckCityExistsByCityNameRequest : IRequest<CheckCitExistsyByCityNameResponse>
    {
        public Guid Id { get; set; }

        public string? CityName { get; set; }

        public CheckCityExistsByCityNameRequest(string cityName)
        {
            Id = Guid.NewGuid();
            CityName = cityName;
        }

        public CheckCityExistsByCityNameRequest() { }

    }
}
