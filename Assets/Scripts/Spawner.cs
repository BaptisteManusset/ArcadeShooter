using Lean.Pool;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private GameObject entity;

    private void Start() {
        InvokeRepeating(nameof(Spawning), 1, 1);
    }

    void Spawning() {
        LeanPool.Spawn(entity, transform.position, transform.rotation);
    }
}