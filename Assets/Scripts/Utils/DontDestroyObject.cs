using UnityEngine;

//Add this script to any game object in your starting scene that you want to remain in all other scenes loaded
public class DontDestroyObject : MonoBehaviour
{

    public static DontDestroyObject Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
           // Destroy(gameObject);
        }
    }
}
