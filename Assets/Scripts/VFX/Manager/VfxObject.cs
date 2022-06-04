using System;
using Hellmade.Sound;
using Lean.Pool;
using UnityEngine;
using UnityEngine.Audio;

public class VfxObject : MonoBehaviour, IPoolable {
	ParticleSystem m_particleSystem;
	[SerializeField] private AudioConfig m_AudioConfig;


	private void Awake() {
		m_particleSystem = GetComponent<ParticleSystem>();
	}

	private float GetParticleKillTime() {
		if (m_particleSystem == null) return 0;
		return m_particleSystem.main.startLifetime.constantMax;
	}
	private float GetAudioClipLength() {
		if (m_AudioConfig.AudioClip == null) return 0;
		return m_AudioConfig.AudioClip.length;
	}

	public void OnSpawn() {
		if (m_particleSystem != null) m_particleSystem.Play();
		if (m_AudioConfig.AudioClip) EazySoundManager.PlaySound(m_AudioConfig.AudioClip, m_AudioConfig.Volume, m_AudioConfig.loop,transform);

		float killTime = Mathf.Max(GetParticleKillTime(), GetAudioClipLength());
		LeanPool.Despawn(gameObject,killTime);
	}
	public void OnDespawn() {
	}

	[Serializable]
	class AudioConfig {
		public AudioClip AudioClip = null;
		public bool loop = false;
		public float Volume = 1;
	}

}
