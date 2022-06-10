using Lean.Pool;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable {
    private Rigidbody m_rb;

    private void Awake() {
        m_rb = GetComponent<Rigidbody>();
    }

    public void OnSpawn() {
        m_rb.velocity = transform.forward * 150;
    }

    public void OnDespawn() {
        m_rb.velocity = Vector3.zero;
    }
}