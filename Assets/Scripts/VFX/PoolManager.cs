using System.Collections;
using System.Collections.Generic;
using Databox.Utils;
using Lean.Pool;
using UnityEngine;

public class PoolManager : Singleton<PoolManager> {
	[SerializeField]
	LeanGameObjectPool m_shielder;
	public LeanGameObjectPool Shielder => m_shielder;

	[SerializeField]
	LeanGameObjectPool m_skull;
	public LeanGameObjectPool Skull => m_skull;

	[SerializeField]
	LeanGameObjectPool m_sword;
	public LeanGameObjectPool Sword => m_sword;

	[SerializeField]
	LeanGameObjectPool m_tower;
	public LeanGameObjectPool Tower => m_tower;

	[Header("VFX")] [SerializeField] PoolManagerVfx m_vfx;
	public PoolManagerVfx VFX => m_vfx;


}
