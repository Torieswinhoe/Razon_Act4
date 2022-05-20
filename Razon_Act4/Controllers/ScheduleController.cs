using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Razon_Act4.Models;

namespace Razon_Act4.Controllers
{
    public class ScheduleController : ApiController
    {
            [HttpGet]
            public HttpResponseMessage Index()
            {
                try
                {
                    sched_dbEntities2 db = new sched_dbEntities2();
                    var schedules = db.Schedules;
                    var response = Request.CreateResponse<IEnumerable<Schedule>>(HttpStatusCode.OK, schedules);
                    return response;
                }
                catch (Exception ex)
                {
                    var errorresponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                    return errorresponse;
                }
            }
            [HttpGet]
            public HttpResponseMessage Index(int id)
            {
                try
                {
                sched_dbEntities2 db = new sched_dbEntities2();
                    var schedule = db.Schedules.Where(m => m.Schedule1==id).FirstOrDefault();
                    if (schedule == null)
                        throw new Exception("Schedule not Found");
                    var response = Request.CreateResponse<Schedule>(HttpStatusCode.OK, schedule);
                    return response;
                }
                catch (Exception ex)
                {
                    var errorresponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                    return errorresponse;
                }
            }

        }
    }

