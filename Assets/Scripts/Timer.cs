using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField, Tooltip("Time in second")] private float timer = 30;

    [SerializeField] private TMP_Text timerText;


    void Update() {
        if (Manager.gameStat == Manager.GameStat.Gameover) return;
        timer += Time.deltaTime;
        DisplayTimer();
    }

    private void DisplayTimer() {
        timerText.text = FormatTime(timer);
    }


    private static string FormatTime(float time) {
        TimeSpan t = TimeSpan.FromSeconds(time);
        return $"{t.Minutes,1:0}:{t.Seconds,2:00}.{t.Milliseconds,3:000}";
    }

    public void Reset() {
        timer = 0;
        DisplayTimer();
    }
}