using UnityEngine;

[CreateAssetMenu]
public class AudiosourceManager : ScriptableObject {
    private static AudiosourceManager instance;

    public static AudiosourceManager Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<AudiosourceManager>();
            }
            return instance;
        }
    }
    
    
    
}