using Databox;
using Databox.Dictionary;
using Manager;
using UnityEngine;
using UnityEngine.Events;
namespace UI {
    public class ScoreBoard : MonoBehaviour {
        [SerializeField] private DataboxObject database;

        public static DataboxObject Database {
            get { return FindObjectOfType<ScoreBoard>().database; }
        }

        public const string TableId = "HightScore";
        private const string ScoreId = "Score";

        public static UnityAction OnNewHightScore;
        private Manager.Manager manager;


        [ContextMenu("Add Data")]
        public void AddData() {
            SetScore();
        }

        private void SetScore() {
            FloatType score = new FloatType() { Value = Timer.time };
        
            if (database.EntryExists(TableId, manager.Pseudo)) {
                FloatType data = database.GetData<FloatType>(TableId, manager.Pseudo, ScoreId);
                if (!(data.Value < score.Value)) return;
                database.SetData<FloatType>(TableId, manager.Pseudo, ScoreId, score);
                OnNewHightScore?.Invoke();
            }
            else {
                database.AddData(TableId, manager.Pseudo, ScoreId, score);
                OnNewHightScore?.Invoke();
            }
        }

        private void Awake() {
            manager = GetComponent<Manager.Manager>();
            OnNewHightScore += NewHightScore;

            GameState.OnGameOverEnter += SetScore;
        }

        private void NewHightScore() {
            Debug.Log("New Hight Score !!!");
        }


        private void OnDisable() {
            if (database)
                database.SaveDatabase();
        }

        private void OnDestroy() {
            if (database)
                database.SaveDatabase();
        }


        public static OrderedDictionary<string, DataboxObject.DatabaseEntry> GetEntry() {
            var slt = Database.GetEntriesFromTable(TableId);
            return slt;
        }
    }
}