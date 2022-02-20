using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreBoard : ScriptableObject {
    [SerializeField] private ScoreDictionary HightScore;


    [SerializeField] private ScoreDictionary scoreList;


    [Serializable]
    public class ScoreDictionary : SerializableDictionary<string, float> { }

    public void AddScore(string pseudo, float value) {
        if (scoreList.ContainsKey(pseudo)) {
            scoreList[pseudo] = value;
            return;
        }

        scoreList.Add(pseudo, value);
    }

    public float GetScore(string pseudo) {
        return scoreList.TryGetValue(pseudo, out float value) ? scoreList[pseudo] : -1;
    }

    [ContextMenu("Clear Score")]
    public void Clear() {
        scoreList.Clear();
    }
}