using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using Manager;
using UnityEngine;

public class Spawner : MonoBehaviour {
	[SerializeField] private GameObject entity;

	[SerializeField] private List<SpawnObject> spawnObjects = new List<SpawnObject>();

	private const float time = .01f;

	private const float waveDelay = 5;

	private Coroutine couroutine;

	[SerializeField] private Vector3 position;


	public delegate void SpawnerEvent();
	public SpawnerEvent OnSpawn;

	IEnumerator Spawn() {
		yield return new WaitForSecondsRealtime( 3 );
		foreach (SpawnObject sObj in spawnObjects) {
			for( int i = 0; i < sObj.count; i++ ) {
				yield return new WaitForSecondsRealtime( time );
				Spawning( sObj.prefab );
			}
		}

		yield return new WaitForSecondsRealtime( waveDelay );
		couroutine = StartCoroutine( nameof(Spawn) );
	}

	void Spawning(GameObject gameObject) {
		if ( !GameState.IsPlay() ) return;
		LeanPool.Spawn( gameObject, transform.position + position, transform.rotation );
		OnSpawn?.Invoke();
	}

	public void OnEnable() {
		couroutine = StartCoroutine( nameof(Spawn) );
	}

	public void OnDisable() {
		StopCoroutine( couroutine );
	}

	private void OnDrawGizmosSelected() {
		Gizmos.DrawSphere( transform.position + position, .1f );
	}
}

[Serializable]
class SpawnObject {
	public GameObject prefab;
	public int count;
}
