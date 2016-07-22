using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace XamaAndrTest.Objects
{
    public class Trainer : User
    {
        private String _information;
        private List<Client> _clients;

        public string Information
        {
            get
            {
                return _information;
            }

            set
            {
                _information = value;
            }
        }

        public List<Client> Clients
        {
            get
            {
                return _clients;
            }
        }

        public Trainer(ObjectId id, string login, string password, string role, string fio, object foto, string contacts, string _information) : base(id, login, password, role, fio, foto, contacts)
        {
            this._information = _information;
            _clients = new List<Client>();
        }

        public void AddClient(Client client)
        {
            _clients.Add(client);
        }
    }
}