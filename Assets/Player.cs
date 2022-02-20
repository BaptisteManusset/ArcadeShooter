using System;
using UnityEngine;

public class Player : MonoBehaviour {
    public static Player current;

    private void Awake() {
        current = this;
    }


    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Ennemy")) {
            Manager.onDead?.Invoke();
        }
    }
}