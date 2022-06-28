using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness_App
{
    public interface IDatabase
    {
        /*public void GetPost();
        public void GetRanking();
        public void GetFriends();*/
        public void Registrer(User newuser);
        public bool login(User newuser);
        public bool UserAlreadyExists(User newuser);
        public string RecoverPassWrd(string correousuario);



    }
}
