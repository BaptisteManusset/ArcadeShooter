using UnityEngine;

public class Player : MonoBehaviour {
    public static Player current;

    private void Awake() {
        current = this;
    }
}