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
        public JsonResult ListColumns(string TableName)
        {
            List<string> ColumnsList = clientDatabaseManagement.ListColumnsForTable(TableName);
            return Json(ColumnsList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TableRows(string TableName, IEnumerable<string> columns)
        {
            List<dynamic> RowsList = clientDatabaseManagement.GetFirstTenRows(TableName, columns);
            return Json(RowsList, JsonRequestBehavior.AllowGet);
        }
    }
}