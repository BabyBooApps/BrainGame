using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Config : MonoBehaviour
{
    public static UI_Config Instance;
    [Header("Scramble Words")]
    public Sprite ScrambleWords_Background;
    private void Awake()
    {
        // Ensure that there's only one instance of GameManager.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make the GameObject persistent across scenes.
        }
        else
        {
            // If another GameManager exists, destroy this one.
            Destroy(gameObject);
        }

        // Add any initialization code you need here.
    }
    
}
