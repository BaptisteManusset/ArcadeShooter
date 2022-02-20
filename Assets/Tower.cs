using Lean.Pool;
using UnityEngine;

public class Tower : MonoBehaviour, IPoolable {
    private TrailRenderer trailRenderer;

    private void Awake() {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    public void OnSpawn() {
        trailRenderer.Clear();
    }

    public void OnDespawn() {
        
    }
}