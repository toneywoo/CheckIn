using CheckInAPI.Models;
using Microsoft.AspNetCore.Cors;
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
    //[EnableCors("any")] //设置跨域处理的 代理
    public class CheckRecordsController : ControllerBase
    {
        private static string _ConnectionStr;
        public CheckRecordsController(IOptions<ConnectionStrings> connstr)
        {

            _ConnectionStr = connstr.Value.DefaultConnection;
        }
        // GET: api/<CheckRecordsController>
        [HttpGet]
        //[EnableCors("any")] //设置跨域处理的 代理
        public IEnumerable<CheckInRecord> Get()
        {
            DataSet ds = MysqlHelper.Query(_ConnectionStr, "select * from checkinrecords ;");
            CheckInRecord[] ts = new CheckInRecord[ds.Tables[0].Rows.Count];
            int idx = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ts[idx] = new CheckInRecord();
                ts[idx].ID = idx;// (int)dr["ID"];
                ts[idx].StudentSession = (string)dr["StudentSession"];
                ts[idx].CheckInSession = (string)dr["CheckInSession"];
                ts[idx].CheckTime = ((DateTime)dr["CheckTime"]).ToString("G");
                //ts[idx].Description = (string)dr["Description"];
                idx++;

            }
            return ts;
        }

        // GET api/<CheckRecordsController>/5
        [HttpGet("{CheckInSession}")]
        public IEnumerable<Records> Get(string CheckInSession,string StudentSession)
        {
            CheckInSession = CheckInSession.Replace("'", "");
            StudentSession = StudentSession.Replace("'", "");
            DataSet ds = MysqlHelper.Query(_ConnectionStr
                , "SELECT * FROM checkinrecords a INNER JOIN students b ON a.StudentSession = b.`Session` where CheckInSession = '" + CheckInSession 
                + "' or StudentSession = '"+ StudentSession + "';");
            Records[] ts = new Records[ds.Tables[0].Rows.Count];
            int idx = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ts[idx] = new Records();
                ts[idx].ID = idx;// (int)dr["ID"];
                ts[idx].StudentSession = (string)dr["StudentSession"];
                ts[idx].CheckInSession = (string)dr["CheckInSession"];
                ts[idx].CheckTime = ((DateTime)dr["CheckTime"]).ToString("G");
                ts[idx].Name = (string)dr["Name"];
                ts[idx].Session = (string)dr["Session"];
                ts[idx].Phone = (string)dr["Phone"];
                ts[idx].Description = (string)dr["Description"].ToString();
                ts[idx].RegistTime = ((DateTime)dr["RegistTime"]).ToString("G");
                idx++;

            }
            return ts;
        }

        // PUT api/<CheckRecordsController>/5
        [HttpPut("{CheckInSession}")]
        public int Put(string CheckInSession, string StudentSession)
        {
            CheckInSession = CheckInSession.Replace("'", "");
            StudentSession = StudentSession.Replace("'", "");
            return MysqlHelper.Exec(_ConnectionStr
                , "insert into checkinrecords (CheckInSession,StudentSession) values ('" + CheckInSession
                + "','" + StudentSession + "');");
        }

    }
}
