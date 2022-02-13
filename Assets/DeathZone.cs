using UnityEngine;

public class DeathZone : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Player.current.transform.position = Vector3.up;
        }
    }
}