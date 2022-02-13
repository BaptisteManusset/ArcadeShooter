using Lean.Pool;
using UnityEngine;

public class Skull : MonoBehaviour, IPoolable {
    private Rigidbody rb;


    [SerializeField] private float speed = 5;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Vector3 position = transform.position;
        Vector3 direction = Player.current.transform.position - position;
        rb.MovePosition(position + direction * Time.deltaTime * speed);
        transform.LookAt(Player.current.transform.position);
    }

    public void OnSpawn() { }

    public void OnDespawn() { }
}