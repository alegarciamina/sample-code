using System.Web;
using System.Web.SessionState;
using UT.Application.Storage;

namespace UT.Presentation.Web.Models
{
    public class WebSessionStorage:ISessionStorage
    {
        public virtual void Add(string name, object value)
        {
            Session.Add(name, value);
        }

        public virtual void Remove(string name)
        {
            Session.Remove(name);
        }

        public virtual object this[string name]
        {
            get { return Session[name]; }
            set { Session[name] = value; }
        }

        private HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }

        public void Clear()
        {
            Session.Clear();
        }

        public void Abandon()
        {
            Session.Abandon();
        }
    }
}