
using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    public class InventoryController : Controller
    {
        private OracleCrud _db;
        private readonly IConfiguration _config;

        /* The configuration for building the path to the json file is already done in Program.cs.
         * We can therefor use depency injection to insert it into the controller constructor without
         * having to rebuild that path.
         */
        public InventoryController(IConfiguration config)
        {
            _config = config;
            _db = new OracleCrud(_config.GetConnectionString("Default"));
        }

        [Route("api/[controller]")]
        [HttpGet]
        public List<InventoryModel> GetAllInventoryQuantities()
        {
            return _db.GetInventoryQuantities();
        }

    }
}
