using Lean.Pool;
using UnityEngine;

public class Manager : MonoBehaviour {
    [SerializeField] private ScoreBoard scoreBoard;
    public string Pseudo;


    private void Awake() {
        Time.timeScale = 0;

        GameState.OnGameOverEnter += OnGameOverEnter;
        GameState.OnPlayEnter += ONRestart;
    }

    private void OnGameOverEnter() {
        if (!GameState.IsPlay()) return;

        GameState.Current = GameState.GameStat.Gameover;
        Time.timeScale = 0.1f;
    }

    private void ONRestart() {
        LeanGameObjectPool[] pools = FindObjectsOfType<LeanGameObjectPool>();
        if (pools.Length > 0) {
            foreach (LeanGameObjectPool pool in pools) {
                pool.DespawnAll();
            }
        }

        CharacterController cc = Player.current.GetComponent<CharacterController>();
        cc.enabled = false;
        cc.transform.position = Vector3.up;
        cc.enabled = true;
        var timer = FindObjectOfType<Timer>();
        Time.timeScale = 1f;


        timer.Reset();
    }


    public void RequireRestart() {
        GameState.Current = GameState.GameStat.Play;
    }
}