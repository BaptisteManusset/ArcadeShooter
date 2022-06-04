using UnityEngine;
namespace Manager {
    public class UiManager : MonoBehaviour {
        [SerializeField] private GameObject gameoverUi;
        [SerializeField] private GameObject startUi;

        // Start is called before the first frame update
        void Start() {
            GameState.OnGameOverEnter += ONDead;
            GameState.OnPlayEnter += ONRestart;
            GameState.OnMenuEnter += OnMenuEnter;
            ONRestart();
        }

        private void OnMenuEnter() {
            startUi.SetActive(true);
        }

        private void ONRestart() {
            gameoverUi.SetActive(false);
        }

        private void ONDead() {
            gameoverUi.SetActive(true);
        }
    }
}