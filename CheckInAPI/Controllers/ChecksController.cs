using CheckInAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckInAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecksController : ControllerBase
    {
        private static string _ConnectionStr;
        public ChecksController(IOptions<ConnectionStrings> connstr)
        {

            _ConnectionStr = connstr.Value.DefaultConnection;
        }
        // GET: api/<ChecksController>
        [HttpGet]
        public IEnumerable<Checks> Get(string TeacherSession)
        {
            TeacherSession = TeacherSession.Replace("'", "");
            DataSet ds = null;
            if (string.IsNullOrEmpty(TeacherSession))
            {
                ds = MysqlHelper.Query(_ConnectionStr, "select * from checkins  order by ID desc;");
            }
            else
            {
                ds = MysqlHelper.Query(_ConnectionStr, "select * from checkins where TeacherSession = '"
                    + TeacherSession + "'  order by ID desc;");
            }
            
            Checks[] ts = new Checks[ds.Tables[0].Rows.Count];
            int idx = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ts[idx] = new Checks();
                ts[idx].ID = idx;// (int)dr["ID"];
                ts[idx].ClassRoom = (string)dr["ClassRoom"];
                ts[idx].Session = (string)dr["Session"];
                ts[idx].TeacherSession = (string)dr["TeacherSession"];
                ts[idx].Description = (string)dr["Description"];
                idx++;

            }
            return ts;
        }

        //private Checks

        // GET api/<ChecksController>/5
        [HttpGet("{Session}")]
        public Checks Get(string Session,string ClassRoom, string TeacherSession, string Description)
        {
            Session = Session.Replace("'", "");
            ClassRoom = ClassRoom.Replace("'", "");
            TeacherSession = TeacherSession.Replace("'", "");
            Description = Description.Replace("'", "");
            Checks s = new Checks();
            string sql = "SELECT a.*,b.Name from checkins a INNER JOIN teachers b ON a.TeacherSession = b.`Session` where a.session = '" + Session + "'";
            DataSet ds = MysqlHelper.Query(_ConnectionStr, sql);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                sql = "insert into checkins (Session,ClassRoom,TeacherSession,Description) values "
                    + "('" + Session + "','" + ClassRoom + "','" + TeacherSession + "','" + Description + "')";
                MysqlHelper.Exec(_ConnectionStr, sql);
                sql = "SELECT a.*,b.Name from checkins a INNER JOIN teachers b ON a.TeacherSession = b.`Session` where a.session = '" + Session + "'";
                ds = MysqlHelper.Query(_ConnectionStr, sql);
            }
            //if (s.ClassRoom != ClassRoom || s.TeacherSession != TeacherSession || s.Description != Description)
            //{
            //    sql = "update checkins set ClassRoom = '"
            //        + ClassRoom + "' ,TeacherSession = '" + TeacherSession
            //        + "',Description='" + Description
            //        + "' where Session = '" + Session + "'";
            //    MysqlHelper.Exec(_ConnectionStr, sql);
            //}
            s.Session = (string)ds.Tables[0].Rows[0]["Session"];
            s.ClassRoom = (string)ds.Tables[0].Rows[0]["ClassRoom"];
            s.TeacherSession = (string)ds.Tables[0].Rows[0]["TeacherSession"];
            s.Description = (string)ds.Tables[0].Rows[0]["Description"];
            s.Name = (string)ds.Tables[0].Rows[0]["Name"];
            return s;
        }

        // DELETE api/<ChecksController>/5
        [HttpDelete("{Session}")]
        public void Delete(string Session)
        {
            Session = Session.Replace("'", "");
            string sql = "delete from checkins where Session = '" + Session + "'";
            MysqlHelper.Exec(_ConnectionStr, sql);
        }
    }
}
