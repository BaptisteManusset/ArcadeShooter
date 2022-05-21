using UnityEngine;

public class HealthWeakPoint : MonoBehaviour {
    private HealthManager healthManager;

    private void Awake() {
        healthManager = GetComponentInParent<HealthManager>();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Bullet")) {
            healthManager.TakeDamage(1);
        }
    }
}