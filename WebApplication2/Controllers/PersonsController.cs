using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [RoutePrefix("api/v1/persons")]
    public class PersonsController : ApiController
    {
        [Route("", Name = "ListPersons")]
        [HttpGet]
        public HttpResponseMessage ListPersons()
        {
            try
            {
                return this.Request.CreateResponse(new[] {
                    new Person() { Id= 1, Name="Person 1"},
                    new Person() { Id= 2, Name="Person 2"}
                });
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("{id}", Name = "PersonById")]
        [HttpGet]
        public HttpResponseMessage PersonById(int id)
        {
            try
            {
                switch (id)
                {
                    case 1:
                        return this.Request.CreateResponse(new Person() { Id = 1, Name = "Person 1" });
                    case 2:
                        return this.Request.CreateResponse(new Person() { Id = 2, Name = "Person 2" });
                    default:
                        return this.Request.CreateResponse(HttpStatusCode.NoContent);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("", Name = "AddPerson")]
        [HttpPost]
        public HttpResponseMessage AddPerson([FromBody]Person person)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("{personId}", Name = "UpdatePerson")]
        [HttpPut]
        public HttpResponseMessage UpdatePerson(int personId, [FromBody]Person person)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
