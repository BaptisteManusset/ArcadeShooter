using TMPro;
using UnityEngine;

public class StartMenu : MonoBehaviour {
    private Manager manager;

    [SerializeField] private TMP_InputField inputField;

    private void Awake() {
        manager = FindObjectOfType<Manager>();
    }

    public void OnEnter() {
        manager.Pseudo = inputField.text;
        manager.RequireRestart();
        gameObject.SetActive(false);
    }
}