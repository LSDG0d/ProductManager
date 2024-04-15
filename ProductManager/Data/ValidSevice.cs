using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManager.Data;
using ProductManager.Models;

namespace ProductManager.Data
{
    public class ValidSevice
    {
        public static string ValidThis(string Login, string Password)
        {
            if(Login != null && Password != null)
            {
                List<UserModel> users = new List<UserModel>();
                users = DataBaseService.GetUsers();
                foreach (var user in users)
                {
                    if(user.Login == Login && user.Password == Password)
                    {
                        return user.Role;
                    }
                }
            }
            return "Пользователь не найден";
        }
    }
}
