using System;
using Hellmade.Sound;
using Lean.Pool;
using UnityEngine;

public class VfxObject : MonoBehaviour, IPoolable {
	ParticleSystem _particleSystem;
	[SerializeField] AudioClip _audioClip;


	private void Awake() {
		_particleSystem = GetComponent<ParticleSystem>();
	}

	private float GetParticleKillTime() {
		if (_particleSystem == null) return 0;
		return _particleSystem.main.startLifetime.constantMax;
	}
	private float GetAudioClipLength() {
		if (_audioClip == null) return 0;
		return _audioClip.length;
	}

	public void OnSpawn() {
		if (_particleSystem != null) _particleSystem.Play();
		if (_audioClip) EazySoundManager.PlaySound(_audioClip, transform);


		float killTime = Mathf.Max(GetParticleKillTime(), GetAudioClipLength());
		Invoke(nameof(Despawn), killTime);

	}
	void Despawn() {
        LeanPool.Despawn(gameObject);
    }

	public void OnDespawn() {
	}
}
