using TMPro;
using UnityEngine;
namespace UI {
    public class GameOverUi : MonoBehaviour {
        [SerializeField] private TMP_Text pseudo;
        [SerializeField] private TMP_Text score;
        [SerializeField] private GameObject hightScore;

        private Manager.Manager manager;
        private ScoreBoard scoreBoard;

        private void Awake() {
            scoreBoard = FindObjectOfType<ScoreBoard>();
            manager = FindObjectOfType<Manager.Manager>();
        }

        private void OnEnable() {
            pseudo.text = manager.Pseudo;
            score.text = Timer.time.ToString();
        }
    }
}