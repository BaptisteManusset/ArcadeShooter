using System;
using UnityEngine;

public class SpawnParticle : MonoBehaviour {
	[SerializeField]
	private Spawner m_spawner;
	ParticleSystem m_particle;
	private void Awake() {
		m_spawner.OnSpawn += SpawnParticleSystem;
		m_particle = GetComponent<ParticleSystem>();
	}

	private void OnDestroy() {
		m_spawner.OnSpawn -= SpawnParticleSystem;;
	}
	private void SpawnParticleSystem() {
		m_particle.Play();
	}
}
