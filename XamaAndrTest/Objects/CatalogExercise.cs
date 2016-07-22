using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XamaAndrTest.Objects
{
    public class CatalogExercise
    {
        private ObjectId _id;
        private String _name;
        private String _type;
        private String _equipment;
        private String _video;
        private String _description;
        private Double _calorificValue;
        private List<ExerciseParameter> _parameters;

        public CatalogExercise()
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

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string Equipment
        {
            get
            {
                return _equipment;
            }

            set
            {
                _equipment = value;
            }
        }

        public string Video
        {
            get
            {
                return _video;
            }

            set
            {
                _video = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
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

        public List<ExerciseParameter> Parameters
        {
            get
            {
                return _parameters;
            }

            set
            {
                _parameters = value;
            }
        }

        public CatalogExercise(ObjectId _id, string _name, string _type, string _equipment, string _video, string _description, double _calorificValue, List<ExerciseParameter> _parameters)
        {
            this._id = _id;
            this._name = _name;
            this._type = _type;
            this._equipment = _equipment;
            this._video = _video;
            this._description = _description;
            this._calorificValue = _calorificValue;
            this._parameters = _parameters;
        }


        public static explicit operator CatalogExercise(BsonDocument doc)
        {
            CatalogExercise result = new CatalogExercise();
            result.ID = doc["_id"].AsObjectId;
            result.Name = doc["name"].AsString;
            result.Type = doc["type"].AsString;
            result.Equipment = doc["equipment"].AsString;
            result.Video = doc["video"].AsString;
            result.Description = doc["description"].AsString;
            result.CalorificValue = doc["calorificValue"].AsDouble;
            result.Parameters = null;
            return result;
        }


        public static implicit operator string(CatalogExercise exe)
        {
            string result = JsonConvert.SerializeObject(exe);
            return result;
        }


        public static implicit operator CatalogExercise(string json)
        {
            CatalogExercise result = new CatalogExercise();
            result = JsonConvert.DeserializeObject<CatalogExercise>(json);
            return result;
        }



    }
}