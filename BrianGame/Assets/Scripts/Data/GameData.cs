using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;
    [Header("ScrambleWords")]
    public List<ScrambleWords_Object> ScrambleWords_Items = new List<ScrambleWords_Object>();

    [Header("Matching")]
    public List<MatchingObject> Matching_Items = new List<MatchingObject>();

    [Header("HowMany")]
    public List<HowManyObj> HowMany_Items = new List<HowManyObj>();

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
