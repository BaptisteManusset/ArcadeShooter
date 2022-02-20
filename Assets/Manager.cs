using System;
using System.Collections;
using Lean.Pool;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Manager : MonoBehaviour {
    [SerializeField] private GameObject gameoverGameObject;

    public enum GameStat {
        Play = 0,
        Gameover = 1
    }

    public static GameStat gameStat = GameStat.Play;


    public static UnityAction onDead;


    private void Awake() {
        onDead += ONDead;
    }

    private void ONDead() {
        if (gameStat == GameStat.Gameover) return;
        StartCoroutine(nameof(OnDeadAnimation));
    }

    IEnumerator OnDeadAnimation() {
        gameStat = GameStat.Gameover;
        gameoverGameObject.SetActive(true);
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(.1f);
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
        gameoverGameObject.SetActive(false);

        timer.Reset();
        gameStat = GameStat.Play;
    }

    [SerializeField] private ScoreBoard scoreBoard;

    private void Update() {
        var pseudo = Random.value.ToString();
        scoreBoard.AddScore(pseudo, Random.value);
        Debug.Log(scoreBoard.GetScore(pseudo));
    }
}