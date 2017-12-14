using MvcTests.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace MvcTests.Controllers
{
    [RoutePrefix("invitationdigital")]
    public class invitationdigitalController : Controller
    {
        [Route("tests/{index?}")]
        // GET: invitationdigital
        public ActionResult Tests(int? index)
        {

            // for the purposes of this project; here is the call to the API. In real terms this would refactored into an object and the key
            // sourced from the webconfig.


            // Resources : https://stackoverflow.com/questions/24131067/deserialize-json-to-array-or-list-with-httpclient-readasasync-using-net-4-0-ta

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(@"http://localhost:49869");
                client.DefaultRequestHeaders.Add("x-apikey", "4835d7e2-5ef5-4fdb-a0a4-023535028308");

                var model = new List<TestsViewModel>();
                var response = client.GetAsync($"api/values/{index}")
                                .ContinueWith((task) =>
                                {
                                    var result = task.Result;
                                    var jsonTask = result.Content.ReadAsAsync<TestsViewModel>();
                                    jsonTask.Wait();
                                    model.Add(jsonTask.Result);
                                    return View(model);
                                });


               
            }

            return View();
        }


    }
}