using Lean.Pool;
using UnityEngine;

public class Cannon : MonoBehaviour {
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float value = 0;
    [Range(0, 0.1f)] [SerializeField] private float countdownMax = .05f;
    [SerializeField] [Space] float coneSize = 5;

    private void Update() {
        if (!GameState.IsPlay()) return;
        if (Input.GetMouseButton(0)) {
            if (value <= 0) {
                for (int i = 0; i < 5; i++) {
                    float xSpread = Random.Range(-1, 1);
                    float ySpread = Random.Range(-1, 1);
                    
                    //normalize the spread vector to keep it conical
                    Vector3 spread = new Vector3(xSpread, ySpread, 0.0f).normalized * coneSize;
                    Quaternion rotation = Quaternion.Euler(spread) * spawnPoint.rotation;
                    
                    GameObject b = LeanPool.Spawn(bullet, spawnPoint.position, rotation);
                    
                    PoolManager.Instance.VFX.Player.Fire.Spawn(transform.position,Quaternion.Euler(spawnPoint.forward));

                    LeanPool.Despawn(b, .5f);
                }
                value = countdownMax;
            }
            else {
                value -= Time.deltaTime;
            }
        }
    }
}