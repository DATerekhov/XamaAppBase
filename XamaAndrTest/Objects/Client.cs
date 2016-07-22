using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XamaAndrTest.Objects
{
    public class Client : User
    {
        private int _growth;
        private List<Weight> _weights;
        private List<Trainer> _trainers;
        private String _presenseStatus;

        public Client(ObjectId id, string login, string password, string role, string fio, object foto, string contacts, int growth, Weight weight, string presenseStatus) : base(id, login, password, role, fio, foto, contacts)
        {
            _growth = growth;
            _weights = new List<Weight>();
            _weights.Add(weight);
            _trainers = new List<Trainer>();
            _presenseStatus = presenseStatus;
        }

        public Client()
        {
        }

        public int Growth
        {
            get
            {
                return _growth;
            }

            set
            {
                _growth = value;
            }
        }

        public List<Weight> Weights
        {
            get
            {
                return _weights;
            }

            set
            {
                _weights = value;
            }
        }

        public List<Trainer> Trainers
        {
            get
            {
                return _trainers;
            }

            set
            {
                _trainers = value;
            }
        }

        public string PresenseStatus
        {
            get
            {
                return _presenseStatus;
            }

            set
            {
                _presenseStatus = value;
            }
        }

        public Trainer GetCurrentTrainer()
        {
            return _trainers[_trainers.Count - 1];
        }

        public static explicit operator Client(BsonDocument user)
        {
            Client result = new Client();
            result.ID = user["_id"].AsObjectId;
            result.Login = user["login"].AsString;
            result.Password = user["password"].AsString;
            result.Fio = user["fio"].AsString;
            result.Role = user["role"].AsString;
            result.Contacts = user["contacts"].AsString;
            result.Foto = null;
            result.Growth = user["growth"].AsInt32;
            result.PresenseStatus = user["status"].AsString;
            result.Trainers = new List<Trainer>();
            result.Weights = new List<Weight>();
            return result;
        }



        public static implicit operator string(Client client)
        {
            string result = JsonConvert.SerializeObject(client);
            return result;
        }


        public static implicit operator Client(string json)
        {
            Client result = new Client();
            result = JsonConvert.DeserializeObject<Client>(json);
            return result;
        }


    }
}