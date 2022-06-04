using Lean.Pool;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable {
    private Rigidbody rb;
    TrailRenderer trail;

    private void Awake() {
        trail = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody>();
        trail.autodestruct = false;
    }

    public void OnSpawn() {
        trail.Clear();
        rb.velocity = transform.forward * 150;
    }

    public void OnDespawn() {
        rb.velocity = Vector3.zero;
    }
}