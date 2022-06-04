using System;
// using LeakyAbstraction;
using Lean.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleSpawner : MonoBehaviour {
    [SerializeField] private float distance = 70;

    [SerializeField] private GameObject entity;

    // [SerializeField] private GameSound soundAtSpawn = GameSound.None;

    private void Start() {
        InvokeRepeating(nameof(Spawning), 1, 10);
    }

    void Spawning() {
        if (!GameState.IsPlay()) return;


        Debug.Log($"{entity}  {transform.position + RandomPointOnCircleEdge(distance)}  {transform.rotation}" );
        // LeanPool.Spawn(entity, transform.position + RandomPointOnCircleEdge(distance), transform.rotation);
        LeanPool.Spawn(entity, transform.position , transform.rotation);

        // if (soundAtSpawn != GameSound.None)
            // SoundManager.Instance.PlaySound(soundAtSpawn);
    }

    public static Vector3 RandomPointOnCircleEdge(float radius) {
        Vector2 vector2 = Random.insideUnitCircle.normalized * radius;
        return new Vector3(vector2.x, 0, vector2.y);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(Vector3.zero, distance);
    }
}