using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;
    public UI_ScrambleWords ScrambleWords_Screen;
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
    // Start is called before the first frame update
    void Start()
    {
        Invoke("InitializeScreens", 1.0f);
       // InitializeScreens();
    }

   void InitializeScreens()
    {
        ScrambleWords_Screen.SetScreen();
    }
}
