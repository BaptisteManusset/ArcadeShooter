using Manager;
using UnityEngine;

public class DeathZone : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;

        GameState.TriggerGameOver();
    }
}