using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace XamaAndrTest.Objects
{
    public class User
    {
        private ObjectId _id;
        private string _login;
        private string _password;
        private string _role;
        private string _fio;
        private object _foto;
        private string _contacts;

        public ObjectId ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }        

        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string Role
        {
            get
            {
                return _role;
            }

            set
            {
                _role = value;
            }
        }

        public string Fio
        {
            get
            {
                return _fio;
            }

            set
            {
                _fio = value;
            }
        }

        public object Foto
        {
            get
            {
                return _foto;
            }

            set
            {
                _foto = value;
            }
        }

        public string Contacts
        {
            get
            {
                return _contacts;
            }

            set
            {
                _contacts = value;
            }
        }

        public User(ObjectId id, string login, string password, string role, string fio, object foto, string contacts)
        {
            _id = id;
            _login = login;
            _password = password;
            _role = role;
            _fio = fio;
            _foto = foto;
            _contacts = contacts;
        }
        public User() { }


        public static explicit operator User(BsonDocument user)
        {
            User result = new User();
            result.ID = user["_id"].AsObjectId;
            result.Login = user["login"].AsString;
            result.Password = user["password"].AsString;
            result.Fio = user["fio"].AsString;
            result.Role = user["role"].AsString;
            result.Contacts = user["contacts"].AsString;
            result.Foto = null;
            return result;
        }


        public static implicit operator string(User user)
        {
            string result = JsonConvert.SerializeObject(user);
            return result;
        }


        public static implicit operator User(string json)
        {
            User result = new User();
            result = JsonConvert.DeserializeObject<User>(json);
            return result;
        }



    }
}