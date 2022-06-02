using System;
using Hellmade.Sound;
using Lean.Pool;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent( typeof( HealthManager ) )]
public class MobAudio : MonoBehaviour, IPoolable {
	[SerializeField] private MobSound mobSound;
	private HealthManager healthManager;


	private void Awake() {
		healthManager = GetComponent<HealthManager>();
	}

	public void OnSpawn() {
		healthManager.OnDead += OnDead;
		healthManager.OnTakeDamage += OnTakeDamage;
		healthManager.OnHealthChange += OnHealthChange;


		if ( mobSound.spawnSound ) EazySoundManager.PlaySound( mobSound.spawnSound, false, transform );
		if ( mobSound.hummingSound) EazySoundManager.PlaySound( mobSound.hummingSound, true, transform );
	}

	public void OnDespawn() { }

	private void OnHealthChange() { }

	private void OnTakeDamage() {
		// EazySoundManager.PlaySound( mobSound.damageSound, transform );
		PoolManager.Instance.VFX.Default.Spawn(transform.position);
	}

	private void OnDead() {
		EazySoundManager.PlaySound( mobSound.deathSound, false, transform );
	}

	[Serializable]
	class MobSound {
		public AudioClip spawnSound;
		public AudioClip hummingSound;
		public AudioClip damageSound;
		public AudioClip deathSound;
	}
}
