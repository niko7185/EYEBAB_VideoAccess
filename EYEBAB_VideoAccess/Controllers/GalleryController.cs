using DataAccess;

using Entities;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EYEBAB_VideoAccess.Controllers
{

    [Route("api/")]
    [ApiController]
    public class GalleryController : Controller
    {

        [HttpGet("[controller]/{lang}")]
        public ActionResult<IEnumerable<GalleryVideo>> Get(string lang)
        {

            GalleryRepository repository = new GalleryRepository();

            return repository.GetAllByLang(lang);
        }

        [HttpGet("filter")]
        public ActionResult<IEnumerable<string>> Get()
        {

            GalleryRepository repository = new GalleryRepository();

            return repository.GetCategories();
        }

    }
}
