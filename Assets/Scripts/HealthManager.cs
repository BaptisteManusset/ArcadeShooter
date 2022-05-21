using System;
using Hellmade.Sound;
// using LeakyAbstraction;
using Lean.Pool;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class HealthManager : MonoBehaviour, IDamageable, IPoolable {
    [SerializeField] private float currentHealth = -1;
    [SerializeField] public float maxHealth = 100;


    [Space] [SerializeField] private GameObject deathParticle;
    [SerializeField] private Transform deathParticleSpawn;

    [SerializeField] private bool BodyCanTakeDamage = true;

    private bool alreadyDead;


    public UnityAction OnDead;
    public UnityAction OnTakeDamage;
    public UnityAction OnHealthChange;
    private Rigidbody rb;


    private void Awake() {
        rb = GetComponent<Rigidbody>();

        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision other) {
        if (BodyCanTakeDamage == false) return;
        if (other.collider.CompareTag("Bullet")) {
            TakeDamage(1);
        }
    }

    public bool TakeDamage(float value) {
        OnTakeDamage?.Invoke();
        SetHealth(currentHealth - value);
        return true;
    }

    public void OnSpawn() {
        alreadyDead = false;
        currentHealth = maxHealth;
    }

    public void OnDespawn() {
        /**/
    }

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
        if (deathParticleSpawn == null) deathParticleSpawn = transform;
        OnDead?.Invoke();


        LeanPool.Spawn(deathParticle, deathParticleSpawn.position, quaternion.identity);

        LeanPool.Despawn(gameObject, .1f);
    }


    public void IncreaseHealth(float value = 1) {
        SetHealth(currentHealth + value);
    }
}

public interface IDamageable {
    bool TakeDamage(float value);
}