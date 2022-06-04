using Manager;
using UnityEngine;
public class PlayerVfx : MonoBehaviour {
    private void Awake() {
        GameState.OnGameOverEnter += OnGameOverEnter;
    }
    private void OnGameOverEnter() {
        PoolManager.Instance.VFX.Player.Death.Spawn(transform.position);
    }
}