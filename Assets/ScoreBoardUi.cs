using TMPro;
using UnityEngine;

public class ScoreBoardUi : MonoBehaviour {
    [SerializeField] private GameObject content;

    [SerializeField] private GameObject Prefab;

    private void Awake() {
        ScoreBoard.OnNewHightScore += OnNewHightScore;

        GameState.OnGameOverEnter += ONDead;
        GameState.OnPlayEnter += ONRestart;
    }

    private void ONRestart() {
        Clearing();
    }

    private void Clearing() {
        for (int i = content.transform.childCount - 1; i >= 0; i--) {
            Destroy(content.transform.GetChild(i).gameObject);
        }
    }

    private void ONDead() { }

    private void OnEnable() {
        OnNewHightScore();
    }

    [ContextMenu("Hightscore list")]
    private void OnNewHightScore() {
        Clearing();

        var table = ScoreBoard.Database.GetEntriesFromTable(ScoreBoard.TableId);

        //Debug.Log(_table.Count + " Entries in " + tableName);

        // Then we iterate through all entries
        foreach (var entry in table.Keys) {
            string text = "";
            text += $"[{entry}] ";

            // Next we get for each entry all values inside of it
            var _values = ScoreBoard.Database.GetValuesFromEntry(ScoreBoard.TableId, entry);

            //Debug.Log(_values.Count + " Values in " + entry);

            // Then we iterate through all values
            foreach (string value in _values.Keys) {
                // Finally we try to get all float values inside of each entry
                FloatType _float;
                if (ScoreBoard.Database.TryGetData<FloatType>(ScoreBoard.TableId, entry, value, out _float)) {
                    // Return the float value 

                    text += $"{_float.Value} ";
                }
            }

            var p = Instantiate(Prefab, content.transform);
            var t = p.GetComponentInChildren<TMP_Text>();
            t.text = text;
        }
    }
}