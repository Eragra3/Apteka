using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Apteka.Helpers
{
    public interface ISessionManager
    {
        T Get<T>(string key) where T : class;

        void Set(string key, object data);

        bool IsSet(string key);

        void Remove(string key);
    }

    public class SessionManager : ISessionManager
    {
        public T Get<T>(string key) where T : class
        {
            return HttpContext.Current.Session[key] as T;
        }

        public void Set(string key, object data)
        {
            if (data == null)
                return;
            HttpContext.Current.Session.Add(key, data);
        }

        public bool IsSet(string key)
        {
            return HttpContext.Current.Session[key] != null;
        }

        public void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
    }
}
