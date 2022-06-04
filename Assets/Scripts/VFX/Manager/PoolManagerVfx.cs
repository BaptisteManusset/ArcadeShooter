using System;
using Lean.Pool;
using UnityEngine;
using UnityEngine.Serialization;
public class PoolManagerVfx : MonoBehaviour {
	public LeanGameObjectPool VfxPool;

	[Space] public MobPool Player;
	[Space] public MobPool Sword;
	[Space] public MobPool Tower;

	[Serializable]
	public class MobPool {
		public LeanGameObjectPool Spawn;
		public LeanGameObjectPool TakeDamage;
		public LeanGameObjectPool Fire;
		public LeanGameObjectPool Death;
	}
}
