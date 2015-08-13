using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace web.Controllers
{
    public class CalendarController : ApiController
    {
        public IHttpActionResult Get(DateGen.IntervalEnum type
                                    , int num
                                    , DateTime dt
                                    , int occurrence)
        {
            var txt = calendar.getCalendar(type
                                            , num
                                            , dt
                                            , occurrence);

            IHttpActionResult response;
            var responseMsg = new HttpResponseMessage(HttpStatusCode.OK);
            responseMsg.Content = new StringContent(txt, Encoding.UTF8, "text/calendar");
            responseMsg.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "calendar.ical"
            };
            response = ResponseMessage(responseMsg);

            return response;
        }
    }
}