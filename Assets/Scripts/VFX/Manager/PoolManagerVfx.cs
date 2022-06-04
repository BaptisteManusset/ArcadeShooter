using System;
using Lean.Pool;
using UnityEngine;
namespace VFX.Manager {
	public class PoolManagerVfx : MonoBehaviour {
		public LeanGameObjectPool VfxPool;

		[Space] public MobPool Player = new MobPool();
		[Space] public MobPool Sword = new MobPool();
		[Space] public MobPool Tower = new MobPool();

		[Serializable]
		public class MobPool {
			public LeanGameObjectPool Spawn;
			public LeanGameObjectPool TakeDamage;
			public LeanGameObjectPool Fire;
			public LeanGameObjectPool Death;
		}
	}
}
