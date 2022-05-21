using UnityEngine;

public class Player : MonoBehaviour {
    public static Player current;

    private void Awake() {
        current = this;
    }


    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Ennemy"))
            GameState.TriggerGameOver();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ennemy"))
            GameState.TriggerGameOver();
    }
}