using Api2022_Quito.Models.Request;
using Api2022_Quito.Models.Response;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api2022_Quito.Controllers
{
    public class PeopleController : ApiController
    {
        // GET: People


        public List<PersonResponse> Get()
        {

            var service = new PersonService();
            var people = service.Get();

            //Convert Domaint to Response
            var response = people.Select(x => new PersonResponse
            {
                FullName = string.Concat(x.FirstName, " ", x.LastName)
            }).ToList();

            return response;
        }
        [HttpPost]
        public bool Insert(PersonRequest request)
        {
            var response = true;
            try
            {
                var service = new PersonService();
                service.Insert(new Domain.Person
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName
                });
            }
            catch (Exception)
            {
                //log ex
                response = false;
            }
            return response;
        }

    }
}