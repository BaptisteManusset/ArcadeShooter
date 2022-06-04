using System;
using Lean.Pool;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(HealthManager))]
public class MobVfxBase : MonoBehaviour, IPoolable {
	[SerializeField] protected MobSound mobSound;
	private HealthManager m_healthManager;


#region register
	protected virtual void Awake() {
		m_healthManager = GetComponent<HealthManager>();
		m_healthManager.OnDead += OnDead;
		m_healthManager.OnTakeDamage += OnTakeDamage;
		m_healthManager.OnHealthChange += OnHealthChange;
	}

	private void OnDestroy() {
		m_healthManager.OnDead -= OnDead;
		m_healthManager.OnTakeDamage -= OnTakeDamage;
		m_healthManager.OnHealthChange -= OnHealthChange;
	}
#endregion

	public virtual void OnSpawn() {}

	public virtual void OnDespawn() {}

	protected virtual void OnHealthChange() {}

	protected virtual void OnTakeDamage() {}

	protected virtual void OnDead() {}

	[Serializable]
	protected class MobSound {
		public AudioClip spawnSound;
		public AudioClip hummingSound;
		public AudioClip damageSound;
		public AudioClip deathSound;
	}
}
