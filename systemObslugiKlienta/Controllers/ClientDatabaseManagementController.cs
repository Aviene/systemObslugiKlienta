using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadFromClientShard;
using systemObslugiKlienta.Models;

namespace systemObslugiKlienta.Controllers
{
    public class ClientDatabaseManagementController : Controller
    {
        ClientDatabaseManagment clientDatabaseManagement = new ClientDatabaseManagment("AVIENE", "Shard18");
        // GET: ClientDatabaseManagement
        public ActionResult Index()
        {  
            return View(clientDatabaseManagement.ListDatabaseTables());
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult TableRows(string TableName)
        {
            List<string> RowsList = clientDatabaseManagement.ListColumnsForTable(TableName);
            return Json(RowsList, JsonRequestBehavior.AllowGet);
        }
    }
}