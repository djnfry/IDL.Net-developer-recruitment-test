using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

using MvcTestsApi.Models;

namespace MvcTestsApi.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly TestDto[] _returnValues = {
            new TestDto
            {
                Name = "This is item 1",
                Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.",
                CreatedDate = DateTime.UtcNow
            }, 
            new TestDto
            {
                Name = "This is item 2",
                Description = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio.",
                CreatedDate = DateTime.UtcNow
            },
            new TestDto
            {
                Name = "This is item 3",
                Description = "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur?",
                CreatedDate = DateTime.UtcNow
            }
        };

        public IEnumerable<TestDto> Get()
        {
            return _returnValues;
        }

        public TestDto Get(int id)
        {
            var index = id - 1;
            if (index < 0 || index >= _returnValues.Length)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return _returnValues[index];
        }
    }
}
