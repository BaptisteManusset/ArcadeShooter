using Lean.Pool;
using UnityEngine;
public class PoolManagerVfx : MonoBehaviour {
	[SerializeField]
	LeanGameObjectPool m_default;
	public LeanGameObjectPool Default => m_default;
}
