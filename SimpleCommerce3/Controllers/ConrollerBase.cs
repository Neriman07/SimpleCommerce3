using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleCommerce3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Controllers
{
    public class ControllerBase:Controller
    {
        protected readonly ApplicationDbContext _context;
        public ControllerBase(ApplicationDbContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;
            controller.ViewBag.Categories = _context.Categories.ToList();
            base.OnActionExecuting(context);
        }
    }
}
