using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadFromClientShard;
using systemObslugiKlienta.Models;
using System.Security.Principal;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace systemObslugiKlienta.Controllers
{
    public class ClientDatabaseManagementController : Controller
    {
         static ClientDatabaseManagment clientDatabaseManagement;       
        //ClientDatabaseManagment clientDatabaseManagement = new ClientDatabaseManagment("AVIENE", "Shard18");
        
        // GET: ClientDatabaseManagement
        public ActionResult Index()
        {
            //gets current user
            var userManager = new UserManager<User, int>(new CustomUserStore(new SystemObslugiKlientaContext()));
            var user = userManager.FindByName(User.Identity.GetUserName());

            //server-shard user`s list
            var listUserShards = new List<Tuple<string, string>>();

            //get current user`s shards
            var userShards = user.UserShards;
            foreach (var userShard in userShards)
            {
                listUserShards.Add(new Tuple<string, string>(userShard.Servers.Name, userShard.ShardName));
            }

            return View(listUserShards);

            //return View(clientDatabaseManagement.ListDatabaseTables());
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult ListTables(string ServerName, string ShardName)
        {
            clientDatabaseManagement = new ClientDatabaseManagment(ServerName, ShardName);
            return Json(clientDatabaseManagement.ListDatabaseTables(), JsonRequestBehavior.AllowGet);
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