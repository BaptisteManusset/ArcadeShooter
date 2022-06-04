using System;
using Manager;
using UnityEngine;

public class MouseLock : MonoBehaviour {
    private void Start() {
        SetCursorLock(false);
    }

    private void Awake() {
        GameState.OnGameOverEnter += () => SetCursorLock(false);
        GameState.OnPlayEnter += () => SetCursorLock(true);
    }


    public void SetCursorLock(bool cursorLock) {
        if (cursorLock) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void OnGUI() {
        GUILayout.Label($"cusor lock :{Cursor.lockState}");
    }
}