using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Databox.Examples {
    public class SimpleDataImportFromDatabase : MonoBehaviour {
        public string tableID;
        public string objectID;
        public ObjectMoveUpDown objectScript;
        public Renderer objectRenderer;

        public DataboxObject database;

        void OnEnable() {
            database.OnDatabaseLoaded += OnLoaded;
        }

        void OnDisable() {
            database.OnDatabaseLoaded -= OnLoaded;
        }


        // Assign Data on database loaded
        public void OnLoaded() {
            // Get all data we need from the runtime database and assign it to the object
            Vector3Type _v3 = database.GetData<Vector3Type>(tableID, objectID, "Position");
            ColorType _color = database.GetData<ColorType>(tableID, objectID, "Color");
            FloatType _speed = database.GetData<FloatType>(tableID, objectID, "Speed");
            FloatType _direction = database.GetData<FloatType>(tableID, objectID, "Direction");

            this.transform.position = _v3.Value;
            objectRenderer.material.color = _color.Value;


            objectScript.speed = _speed;
            objectScript.direction = _direction;
            objectScript.position = _v3;
            objectScript.color = _color;
        }
    }
}