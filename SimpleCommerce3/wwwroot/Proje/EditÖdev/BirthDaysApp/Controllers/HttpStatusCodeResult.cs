using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BirthDaysApp.Controllers
{
    internal class HttpStatusCodeResult : IActionResult
    {
        private object httpStatusCodeResult;

        public HttpStatusCodeResult(object httpStatusCodeResult)
        {
            this.httpStatusCodeResult = httpStatusCodeResult;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}