using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance;
    [SerializeField]
    public ScrambleWordsScene ScrambleWords_Level;
    public MatchingScene Matching_Level;
    public HowMany_Level HowMany_Scene;
    public PuzzleManager Puzzle_Scene;
    public Maths_Level Math_Level;
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
       // ScrambleWords_Level = FindAnyObjectByType(typeof(ScrambleWordsScene)) as ScrambleWordsScene;
      //  Matching_Level = FindObjectOfType(typeof(MatchingScene)) as MatchingScene;
       // HowMany_Scene = FindAnyObjectByType(typeof(HowMany_Level)) as HowMany_Level;
       // Puzzle_Scene = FindAnyObjectByType(typeof(PuzzleManager)) as PuzzleManager;
       // Math_Level = FindAnyObjectByType(typeof(Maths_Level)) as Maths_Level;
    }

    public void InitializeScrambleWordsLevel()
    {
        ScrambleWords_Level.gameObject.SetActive(true);

        ScrambleWords_Level.Initialize();
    }

    public void InitializeMatchingLevel()
    {
        Matching_Level.gameObject.SetActive(true);
        Matching_Level.StartMatchingLevel();
    }

    public void InitializeHowManyLevel()
    {
        HowMany_Scene.gameObject.SetActive(true);
        HowMany_Scene.StartGamePlay();
    }

    public void InitializePuzzleLevel(int cardsCount , int severity)
    {
        Puzzle_Scene.gameObject.SetActive(true);
        Puzzle_Scene.initiatePuzzleLevel(cardsCount , severity);
        
    }

    public void InitializeMathLevel(Math_Type type)
    {
        Math_Level.gameObject.SetActive(true);
        Math_Level.Start_Level(type);
    }
}
