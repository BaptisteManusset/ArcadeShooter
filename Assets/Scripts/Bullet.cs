using Lean.Pool;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable {
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void OnSpawn() {
        rb.velocity = transform.forward * 50;
    }

    public void OnDespawn() {
        rb.velocity = Vector3.zero;
    }
}