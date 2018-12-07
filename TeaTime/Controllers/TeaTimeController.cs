using System;
using System.Runtime.Caching;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TeaTime.Controllers
{
    public class TeaTimeController : ApiController
    {
        private MemoryCache _cache;

        public TeaTimeController()
        {
            _cache = MemoryCache.Default;
        }

        [EnableCors("*", "*", "*")]
        public DateTime? Get()
        {
            var teaTime = _cache.Get("date" + DateTime.Now.ToString("dd/MM/yyyy"));

            if (teaTime != null)
                return (DateTime?) teaTime;

            return null;
        }

        [EnableCors("*", "*", "*")]
        public void Post([FromBody]DateTime value)
        {
            _cache["date" + DateTime.Now.ToString("dd/MM/yyyy")] = value;
        }

        [EnableCors("*", "*", "*")]
        public void Delete()
        {
            _cache.Remove("date" + DateTime.Now.ToString("dd/MM/yyyy"));
        }
    }
}
