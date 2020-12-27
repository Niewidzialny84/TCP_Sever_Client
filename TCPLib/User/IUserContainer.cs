using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib
{
    //This is something like CRUD
    public interface IUserContainer
    {
        void LoadFromDB();
        void AddUserToDB(String login, String password, Boolean admin);
        void RemoveUserFromDB(String login);
        void UpdateUserInDB(String login, String password);
    }
}
