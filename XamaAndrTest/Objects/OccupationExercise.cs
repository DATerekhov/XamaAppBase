using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XamaAndrTest.Objects
{
    public class OccupationExercise : CatalogExercise
    {
        private int _number;
        private String _mark;
        private Double _progress;
        private List<int> _exerciseParameters;

        public OccupationExercise(ObjectId _id, string _name, string _type, string _equipment, string _video, string _description, double _calorificValue, List<ExerciseParameter> _parameters, int _number, string _mark, double _progress, List<int> _exerciseParameters) : base(_id, _name, _type, _equipment, _video, _description, _calorificValue, _parameters)
        {
            this._number = _number;            
            this._mark = _mark;
            this._progress = _progress;
            this._exerciseParameters = _exerciseParameters;
        }

        public OccupationExercise()
        { 
        }

        public int Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
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

        public double Progress
        {
            get
            {
                return _progress;
            }

            set
            {
                _progress = value;
            }
        }

        public List<int> ExerciseParameters
        {
            get
            {
                return _exerciseParameters;
            }

            set
            {
                _exerciseParameters = value;
            }
        }


        public static explicit operator OccupationExercise(BsonDocument doc)
        {          
            OccupationExercise result = new OccupationExercise();
            try
            {
                result.ID = doc["_id"].AsObjectId;
                result.Name = doc["name"].AsString;
                result.Type = doc["type"].AsString;
                result.Equipment = doc["equipment"].AsString;
                result.Video = doc["video"].AsString;
                result.Description = doc["description"].AsString;
                result.CalorificValue = doc["calorificValue"].AsDouble;
                result.Parameters = null;
            }
            catch
            { 
            }
            result.Number = doc["number"].AsInt32;
            result.Mark = doc["mark"].AsString;
            result.Progress = doc["progress"].AsDouble;
            result.ExerciseParameters = null;
            return result;
        }


        public static implicit operator string(OccupationExercise exe)
        {
            string result = JsonConvert.SerializeObject(exe);
            return result;
        }


        public static implicit operator OccupationExercise(string json)
        {
            OccupationExercise result = new OccupationExercise();
            result = JsonConvert.DeserializeObject<OccupationExercise>(json);
            return result;
        }


    }
}