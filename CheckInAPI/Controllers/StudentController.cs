using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using CheckInAPI.Models;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckInAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static string _ConnectionStr;
        public StudentController(IOptions<ConnectionStrings> connstr)
        {
            _ConnectionStr = connstr.Value.DefaultConnection;
            
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            DataSet ds = MysqlHelper.Query(_ConnectionStr, "select * from students;");
            Student[] ts = new Student[ds.Tables[0].Rows.Count];
            int idx = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ts[idx] = new Student();
                //ts[idx].ID = idx;// (int)dr["ID"];
                ts[idx].Name = (string)dr["Name"];
                ts[idx].Session = (string)dr["Session"];
                ts[idx].Phone = (string)dr["Phone"];
                ts[idx].Description = (string)dr["Description"];
                ts[idx].RegistTime = ((DateTime)dr["RegistTime"]).ToString("G");
                idx++;

            }
            return ts;

        }

        // GET api/<StudentController>/5
        [HttpGet("{Session}")]
        public Student Get(string Session, string Name, string Phone,string Description)
        {
            Session = Session.Replace("'", "");
            Name = Name.Replace("'", "");
            Phone = Phone.Replace("'", "");
            Description = Description.Replace("'", "");
            Student s = new Student();
            string sql = "select * from students where Session = '"+ Session + "'";
            DataSet ds = MysqlHelper.Query(_ConnectionStr,sql);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                sql = "insert into students (Session,Name,Phone,Description) values "
                    +"('"+ Session + "','"+ Name + "','"+ Phone + "','"+ Description + "')";
                MysqlHelper.Exec(_ConnectionStr, sql);
            }
            if(s.Name != Name || s.Phone != Phone || s.Description != Description)
            {
                sql = "update students set Name = '"
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
