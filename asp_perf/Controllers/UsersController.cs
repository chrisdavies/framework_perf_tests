using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using MySql.Data.MySqlClient;
using System.Linq;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPPERF.Controllers
{
    public class UsersController : Controller
    {
        static IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        //
        // GET: /users/

        public async Task<IActionResult> Index()
        {
            List<Models.RuzUser> users = null;

            using (var conn = GetConnection()) {
                var result = await conn.QueryAsync<Models.RuzUser>("select id, name, email, salt, crypted_password, time_zone, state, created_at, updated_at from users where state='active' order by email desc");
                users = result.AsList();
            }

            return View(users);
        }

        public IDbConnection GetConnection()
        {
            return new MySqlConnection(config.GetConnectionString("defaultConnection"));
        }
    }
}