using Hellmade.Sound;
using UnityEngine;

public class PlayerSound : MonoBehaviour {
    [SerializeField] private AudioClip deadSound;

    private void Awake() {
        GameState.OnGameOverEnter += OnGameOverEnter;
    }


    private void OnGameOverEnter() {
        EazySoundManager.PlaySound(deadSound, false, transform);
    }
}