using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckInAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        //private readonly IOptions<ConnectionStrings> _connstr;
        private static string _ConnectionStr;

        public TeachersController(IOptions<ConnectionStrings> connstr)
        {

            _ConnectionStr = connstr.Value.DefaultConnection;
        }
        // GET: api/<TeachersController>
        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            DataSet ds = MysqlHelper.Query(_ConnectionStr,"select * from teachers;");
            Teacher[] ts = new Teacher[ds.Tables[0].Rows.Count];
            int idx = 0;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                ts[idx] = new Teacher();
                ts[idx].ID = idx;// (int)dr["ID"];
                ts[idx].Name = (string)dr["Name"];
                ts[idx].Session = (string)dr["Session"];
                ts[idx].Phone = (string)dr["Phone"];
                ts[idx].Description = (string)dr["Description"];
                idx++;

            }
            return ts;
        }

        // GET api/<TeachersController>/5
        [HttpGet("{Session}")]
        public Teacher Get(string Session,string Name,string Phone,string Description)
        {
            Session = Session.Replace("'", "");
            Name = Name.Replace("'", "");
            Phone = Phone.Replace("'", "");
            Description = Description.Replace("'", "");
            Teacher s = new Teacher();
            string sql = "select * from teachers where session = '" + Session + "'";
            DataSet ds = MysqlHelper.Query(_ConnectionStr, sql);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                sql = "insert into teachers (Session,Name,Phone,Description) values "
                    + "('" + Session + "','" + Name + "','" + Phone + "','" + Description + "')";
                MysqlHelper.Exec(_ConnectionStr, sql);
            }
            if (s.Name != Name || s.Phone != Phone || s.Description != Description)
            {
                sql = "update teachers set Name = '"
                    + Name + "' ,Phone = '" + Phone
                    + "',Description='" + Description
                    + "' where Session = '" + Session + "'";
                MysqlHelper.Exec(_ConnectionStr, sql);
            }
            s.Session = Session;
            s.Name = Name;
            s.Phone = Phone;
            s.Description = Description;
            return s;
        }

       
    }
}
