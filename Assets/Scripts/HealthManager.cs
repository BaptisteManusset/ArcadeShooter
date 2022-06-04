using Lean.Pool;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class HealthManager : MonoBehaviour, IDamageable, IPoolable {
    [SerializeField] private float currentHealth = -1;
    [SerializeField] public float maxHealth = 100;
    
    [SerializeField] private bool BodyCanTakeDamage = true;

    private bool alreadyDead;


    public UnityAction OnDead;
    public UnityAction OnTakeDamage;
    public UnityAction OnHealthChange;

    private void Awake() {
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

    public void OnDespawn() {}

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
        OnDead?.Invoke();
        
        LeanPool.Despawn(gameObject, .1f);
    }


    public void IncreaseHealth(float value = 1) {
        SetHealth(currentHealth + value);
    }
}

public interface IDamageable {
    bool TakeDamage(float value);
}