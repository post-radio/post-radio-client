using System;

namespace Global.Network.Session.Runtime.Create
{
    public class IdGenerator
    {
        public string Create()
        {
            var guid = Guid.NewGuid().ToString();

            guid = guid.Remove(0, 4).Substring(0, 19);

            return guid;
        }
    }
}