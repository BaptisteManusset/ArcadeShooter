using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField, Tooltip("Time in second")] public static float time = 30;

    [SerializeField] private TMP_Text timerText;


    void Update() {
        if (!GameState.IsPlay()) return;
        time += Time.deltaTime;
        DisplayTimer();
    }

    private void DisplayTimer() {
        timerText.text = FormatTime(time);
    }


    private static string FormatTime(float time) {
        TimeSpan t = TimeSpan.FromSeconds(time);
        return $"{t.Minutes,1:0}:{t.Seconds,2:00}.{t.Milliseconds,3:000}";
    }

    public void Reset() {
        time = 0;
        DisplayTimer();
    }
}