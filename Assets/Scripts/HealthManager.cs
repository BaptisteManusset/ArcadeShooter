using System;
using Lean.Pool;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class HealthManager : MonoBehaviour, IDamageable, IPoolable {
    private Rigidbody rb;

    [SerializeField] private float currentHealth = -1;
    [SerializeField] public float maxHealth = 100;


    [Space] [SerializeField] private GameObject deathParticle;


    [SerializeField] private bool BodyCanTakeDamage = true;

    private bool alreadyDead;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }


    public UnityAction OnDead;
    public UnityAction OnHealthChange;

    public float GetHealth() {
        return currentHealth;
    }

    public bool IsDead() => alreadyDead;

    public void SetMaxHealth(float value) {
        currentHealth = maxHealth = value;
    }

    private void SetHealth(float value) {
        if (alreadyDead) return;

        currentHealth = value;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        if (!(currentHealth <= 0)) return;
        Died();
    }

    private void Died() {
        alreadyDead = true;
        LeanPool.Spawn(deathParticle, transform.position, quaternion.identity);

        LeanPool.Despawn(gameObject, .1f);
    }

    public bool TakeDamage(float value) {
        SetHealth(currentHealth - value);
        return true;
    }

    public void IncreaseHealth(float value = 1) {
        SetHealth(currentHealth + value);
    }

    public void OnSpawn() {
        alreadyDead = false;
        currentHealth = maxHealth;
    }

    public void OnDespawn() {
        /**/
    }

    private void OnCollisionEnter(Collision other) {
        if (BodyCanTakeDamage == false) return;
        if (other.collider.CompareTag("Bullet")) {
            TakeDamage(1);
        }
    }
}

public interface IDamageable {
    bool TakeDamage(float value);
}