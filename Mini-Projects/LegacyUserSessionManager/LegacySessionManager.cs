using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyUserSessionManager
{
    internal class LegacySessionManager
    {

        private Hashtable _Sessions;

        public LegacySessionManager()
        {
            _Sessions = new Hashtable();
        }

        private bool ValidationInput(string SessionID, string UserName, string Role)
        {

            return !string.IsNullOrWhiteSpace(SessionID) && !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Role);
        }

        public void AddSession(string SessionID , string UserName , string Role)
        {

            if(!ValidationInput(SessionID, UserName, Role))
            {

                Console.WriteLine("The Inputs Must be Valide Without space and Not Empty or Null");
                return;

            }

            if (_Sessions.ContainsKey(SessionID))
            {

                Console.WriteLine($"The SessionID {SessionID} is Already Exists Try Another One");
                return;
            }

            else
            {
                _Sessions.Add(SessionID, new UserSession(UserName , Role));
            }

        }

        public void AddOrUpdateSession(string  SessionID , string UserName , string Role)
        {

            if( !ValidationInput(SessionID, UserName, Role))
            {
                Console.WriteLine("The Inputs Must be Valide Without space and Not Empty or Null");
                return;
            }

         
                _Sessions[SessionID] = new UserSession(UserName, Role);
            
        }

        public UserSession GetSession(string SessionID)
        {
            

            if (string.IsNullOrWhiteSpace(SessionID))
            {
                return null;
            }

            if (!_Sessions.ContainsKey(SessionID))
            {
                Console.WriteLine($"No Session with This Id SessionID {SessionID} Try Another One");
                return null;
            }

            return (UserSession)_Sessions[SessionID];
        }

        public void EndSession(string sessionId)
        {

            if (string.IsNullOrWhiteSpace(sessionId))
            {
                Console.WriteLine("You should enter a valide SessionID");
                return;
            }

            if (!_Sessions.ContainsKey(sessionId))
            {
                Console.WriteLine($"No Session with This Id SessionID {sessionId} Try Another One");
                return ;
            }
        

                UserSession session = (UserSession)_Sessions[sessionId];

                if (session != null)
                {

                   if(session.IsActive == false)
                   {
                     Console.WriteLine("This User is Already InActive");
                    return;
                   }

                    session.IsActive = false;

                }


            
        }

        public void RemoveSession(string sessionId)
        {


            if (string.IsNullOrWhiteSpace(sessionId))
            {
                Console.WriteLine("You should enter a valide SessionID");
                return;
            }

            if (!_Sessions.ContainsKey(sessionId))
            {
                Console.WriteLine($"No Session with This Id SessionID {sessionId} Try Another One");
                return;
            }

            _Sessions.Remove(sessionId);

        }

        public void UpdateActivity(string sessionId)
        {

            if (string.IsNullOrWhiteSpace(sessionId))
            {
                Console.WriteLine("You should enter a valide SessionID");
                return;
            }

            if (!_Sessions.ContainsKey(sessionId))
            {
                Console.WriteLine($"No Session with This Id SessionID {sessionId} Try Another One");
                return;
            }


            UserSession session = (UserSession)_Sessions[sessionId];

            if (session != null)
            {

                if (session.IsActive == false)
                {
                    Console.WriteLine("This User is Already InActive");
                    return;
                }

                session.LastActivity = DateTime.Now;

            }



        }

        public bool ContainsSession(string sessionId)
        {

            return _Sessions.ContainsKey(sessionId);

        }

        public void ShowAllSessions()
        {


            if(_Sessions.Count == 0)
            {
                Console.WriteLine("No sessions to show");
                return;
            }

            Console.WriteLine("\n\tList Of All Sessions\t");

           

            foreach (DictionaryEntry entry in _Sessions)
            {

                UserSession userSession = (UserSession)entry.Value;


                Console.WriteLine("\n---------------------------------------------------------\n");
                Console.WriteLine($"Session ID   : {entry.Key}");
                Console.WriteLine($"User Name    : {userSession.UserName}");
                Console.WriteLine($"Role         : {userSession.Role}");
                Console.WriteLine($"Login Time   : {userSession.LoginTime.ToShortDateString()}");
                Console.WriteLine($"Last Activty : {userSession.LastActivity.ToShortDateString()}");
                Console.WriteLine($"Is Active    : {(userSession.IsActive == true ? "Yes Is Active" : "No")}");

                Console.WriteLine("\n---------------------------------------------------------\n");

            }
      
        }

        public void ShowActiveSessions()
        {

            int countActive = 0;

            foreach (DictionaryEntry entry in _Sessions)
            {

                UserSession userSession = (UserSession)entry.Value;

                if (userSession.IsActive == true)
                {
                   
                    Console.WriteLine("\n---------------------------------------------------------\n");
                    Console.WriteLine($"Session ID   : {entry.Key}");
                    Console.WriteLine($"User Name    : {userSession.UserName}");
                    Console.WriteLine($"Role         : {userSession.Role}");
                    Console.WriteLine($"Login Time   : {userSession.LoginTime.ToShortDateString()}");
                    Console.WriteLine($"Last Activty : {userSession.LastActivity.ToShortDateString()}");
                    Console.WriteLine($"Is Active    :  Yes Its Active");

                    Console.WriteLine("\n---------------------------------------------------------\n");

                    countActive++;
                }
               
            }

            if(countActive == 0)
            {

                Console.WriteLine("No active sessions");

            }
        }

        public void CountSessions()
        {
            int countActive = 0;
            int CountInActive = 0;
           

            foreach (UserSession item in _Sessions.Values)
            {
                if(item.IsActive == true)
                {

                    countActive++;

                } else
                { 
                    
                     CountInActive++;
                }
            }

            Console.WriteLine($"The Count Of Total Sessions : {_Sessions.Count}");
            Console.WriteLine($"The Count Of Total Active   : {countActive}");
            Console.WriteLine($"The Count Of Total InActive : {CountInActive}");


        }

        public void ClearAllSessions()
        {
            _Sessions.Clear();
        }
    }
}
