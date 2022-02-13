using UnityEngine;

public class DeathZone : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        CharacterController cc = Player.current.GetComponent<CharacterController>();
        cc.enabled = false;
        cc.transform.position = Vector3.up;
        cc.enabled = true;
    }
}