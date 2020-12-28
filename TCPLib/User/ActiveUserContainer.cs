using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib
{
    class ActiveUserContainer : Container<ActiveUser>
    {
      
        public ActiveUserContainer() : base() { }
      
        public List<ActiveUser> ContentList { get => contentList; set => contentList = value; }

        public new void Create(ActiveUser activeUser)
        {
            contentList.Add(activeUser);
        }

        public override bool Find(String login)
        {
            foreach(ActiveUser au in contentList)
            {
                if (au.Login.Equals(login))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Delete(String login)
        {
            contentList.RemoveAll(elem => elem.Login.Equals(login));
        }
        
    }
}
