using System;
using UnityEngine;
public class Rotater : MonoBehaviour {
	[Range(1,100)]
	[SerializeField] private float m_speed = 100;
	private void FixedUpdate() {
		transform.Rotate(0, m_speed * Time.fixedDeltaTime, 0);

	}
}
