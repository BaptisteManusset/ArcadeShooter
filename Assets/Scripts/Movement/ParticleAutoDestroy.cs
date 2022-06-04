using Lean.Pool;
using UnityEngine;
namespace Movement {
    public class ParticleAutoDestroy : MonoBehaviour, IPoolable {
        private ParticleSystem ps;

        private void Awake() {
            ps = GetComponent<ParticleSystem>();
        }

        public void OnSpawn() {
            LeanPool.Despawn(gameObject, ps.main.startLifetime.constantMax);
        }

        public void OnDespawn() { }
    }
}