using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace XamaAndrTest.Objects
{
    public class Occupation
    {
        private ObjectId _id;
        private ObjectId _client;
        private ObjectId _trainer;
        private DateTime _date;
        private TimeSpan _occupationStart;
        private TimeSpan _occupationEnd;
        private String _status;
        private String _purpose;
        private List<ObjectId> _exercises;
        private String _mark;
        private Double _calorificValue;
        private Double _estimatedExecutionPlan;

        public Occupation(ObjectId _id, ObjectId _client, ObjectId _trainer, DateTime _date, TimeSpan _occupationStart, TimeSpan _occupationEnd, string _status, string _purpose, List<ObjectId> _exercises, string _mark, double _calorificValue, double _estimatedExecutionPlan)
        {
            this._client = _client;
            this._trainer = _trainer;
            this._date = _date;
            this._occupationStart = _occupationStart;
            this._occupationEnd = _occupationEnd;
            this._status = _status;
            this._purpose = _purpose;
            this._exercises = _exercises;
            this._mark = _mark;
            this._calorificValue = _calorificValue;
            this._estimatedExecutionPlan = _estimatedExecutionPlan;
        }

        public Occupation()
        { 
        
        }

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
        
        public ObjectId Client
        {
            get
            {
                return _client;
            }

            set
            {
                _client = value;
            }
        }

        public ObjectId Trainer
        {
            get
            {
                return _trainer;
            }

            set
            {
                _trainer = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        public TimeSpan OccupationStart
        {
            get
            {
                return _occupationStart;
            }

            set
            {
                _occupationStart = value;
            }
        }

        public TimeSpan OccupationEnd
        {
            get
            {
                return _occupationEnd;
            }

            set
            {
                _occupationEnd = value;
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        public string Purpose
        {
            get
            {
                return _purpose;
            }

            set
            {
                _purpose = value;
            }
        }

        public List<ObjectId> Exercises
        {
            get
            {
                return _exercises;
            }

            set
            {
                _exercises = value;
            }
        }

        public string Mark
        {
            get
            {
                return _mark;
            }

            set
            {
                _mark = value;
            }
        }

        public double CalorificValue
        {
            get
            {
                return _calorificValue;
            }

            set
            {
                _calorificValue = value;
            }
        }

        public double EstimatedExecutionPlan
        {
            get
            {
                return _estimatedExecutionPlan;
            }

            set
            {
                _estimatedExecutionPlan = value;
            }
        }


        public static explicit operator Occupation(BsonDocument occupation)
        {
            Occupation result = new Occupation();
            result.ID = occupation["_id"].AsObjectId;
            result.Client = occupation["client"].AsObjectId;
            result.Trainer = occupation["trainer"].AsObjectId;
            result.Date = occupation["date_time"].ToUniversalTime();
            result.OccupationStart = new TimeSpan();
            result.OccupationEnd = new TimeSpan();
            result.Status = occupation["status"].AsString;
            result.Purpose = occupation["purpose"].AsString;
          //  result.Exercises = new List<ObjectId>();
         //  result.Exercises = occupation["exercises"].AsBsonArray;

            List<ObjectId> tmp = new List<ObjectId>();
            var temp = occupation["exercises"].AsBsonArray;
            for (int i = 0; i < temp.Count; i++)
            {
                tmp.Add(temp[i].AsObjectId);
            }
            result.Exercises = tmp;
            result.Mark = occupation["mark"].AsString;
            result.CalorificValue = 0;
            result.EstimatedExecutionPlan = 0;
            return result;
        }


        public static implicit operator string(Occupation occupation)
        {
            string result = JsonConvert.SerializeObject(occupation);
            return result;
        }


        public static implicit operator Occupation(string json)
        {
            Occupation result = new Occupation();
            result = JsonConvert.DeserializeObject<Occupation>(json);
            return result;
        }


    }
}