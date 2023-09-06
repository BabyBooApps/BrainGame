using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance;
    public ScrambleWordsScene ScrambleWords_Level;
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
        InitializeLevels();
       // ScrambleWords_Level.Initialize();
    }

    void InitializeLevels()
    {
        ScrambleWords_Level = FindAnyObjectByType(typeof(ScrambleWordsScene)) as ScrambleWordsScene;
    }
}
