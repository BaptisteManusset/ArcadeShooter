using UnityEngine;
using UnityEngine.Events;

public static class GameState {
    public enum GameStat {
        Menu = 2,
        Play = 0,
        Gameover = 1
    }

    private static GameStat current = GameStat.Menu;

    public static UnityAction OnMenuEnter;
    public static UnityAction OnPlayEnter;
    public static UnityAction OnGameOverEnter;


    public static GameStat Current {
        get {
            Debug.Log($"Get {current}");
            return current;
        }

        set {
            Debug.Log($"Set {value} > {current}");

            current = value;

            switch (current) {
                default:
                    OnMenuEnter?.Invoke();
                    break;
                case GameStat.Play:
                    OnPlayEnter?.Invoke();
                    break;
                case GameStat.Gameover:
                    OnGameOverEnter?.Invoke();
                    break;
            }
        }
    }


    public static bool IsPlay() => current == GameStat.Play;
    public static bool IsGameOver() => current == GameStat.Gameover;
    public static bool IsMenu() => current == GameStat.Menu;


    public static void TriggerGameOver() {
        Current = GameStat.Gameover;
    }
}