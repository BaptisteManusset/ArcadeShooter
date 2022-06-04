using Lean.Pool;
using UnityEngine;

public class Bomber : MonoBehaviour, IPoolable {
    private new Rigidbody rigidbody;

    [SerializeField] private float speed = 10;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        Vector3 direction = (Player.current.transform.position - transform.position).normalized;

        rigidbody.velocity = direction * speed * Time.deltaTime;
    }

    public void OnSpawn() { }

    public void OnDespawn() { }
}