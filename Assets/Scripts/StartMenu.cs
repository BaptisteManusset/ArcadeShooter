using TMPro;
using UnityEngine;

public class StartMenu : MonoBehaviour {
    private Manager manager;

    [SerializeField] private TMP_InputField inputField;


    private MouseLock mouseLock;

    private void Awake() {
        manager = FindObjectOfType<Manager>();

        mouseLock = FindObjectOfType<MouseLock>();
    }

    private void Update() {
        mouseLock.SetCursorLock(false);
    }

    public void OnEnter() {
        manager.Pseudo = inputField.text;
        manager.RequireRestart();
        gameObject.SetActive(false);
    }
}