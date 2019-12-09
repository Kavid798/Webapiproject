using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Webapiproject.Models;
using static System.Net.WebRequestMethods;

namespace Webapiproject.Controllers
{
    public class CustomerController : Controller
    {
        private string ApiBaseAddress = ConfigurationManager.AppSettings["ApiBaseAddress"];
        // GET: Customer
        public async Task<ActionResult> Index()
        {
            IEnumerable<Customer> customers = null;
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseAddress);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.GetAsync("Customers/GetAllCustomer");
                if(result.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    customers = await result.Content.ReadAsAsync<List<Customer>>();
                }
                else
                {
                    customers = Enumerable.Empty<Customer>();
                }

            }
                return View(customers);
        }
        public async Task<ActionResult> Details(int id)
        {
            Customer customers = null;
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseAddress);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.GetAsync($"Customers/Byidto/{id}");
                if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return HttpNotFound("Customer ID does not exist");
                }
                if(result.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    customers = await result.Content.ReadAsAsync<Customer>();
                }
                else
                {
                    customers = null;
                }

            }
            return View(customers);
        }
        [Route("Customer/SearchbynameAndCity/{input}")]
        [HttpGet]
        public async Task<ActionResult> SearchbynameAndCity(string input)
        {
            Customer customer = new Customer();
            
            return View();
        }
        [Route("Customer/Searchbyname/{input}")]
        [HttpPost]
        public async Task<ActionResult> Searchbyname(string input)
        {
            IEnumerable<Customer> customers = null;
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseAddress);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.GetAsync($"Customers/Byidname/{input}");
                if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return HttpNotFound("Customer ID does not exist");
                }
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    customers = await result.Content.ReadAsAsync<List<Customer>>();
                }
                else
                {
                    customers = null;
                }

            }
            return View(customers);
        }

    }
}