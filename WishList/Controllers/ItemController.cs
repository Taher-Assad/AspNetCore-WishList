using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return Index();
        }

        private readonly ApplicationDbContext _context;
        public  ItemController (ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Create(HttpGetAttribute httpGet)
        {
            return Index();
        }
        public IActionResult Create(HttpPostAttribute httpPost)
        {
            return Index();
        }

        public IActionResult Delete(int Id)
        {
            return Index();
        }
    }
   
}
