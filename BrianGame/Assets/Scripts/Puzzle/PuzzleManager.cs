using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
   
    public Puzzle_Level Active_Level;
    public List<Puzzle_Level> Puzzle_Levels_List = new List<Puzzle_Level>();
    public Puzzle_Level Puzzle_2x2;
   
    public int Score = 0;
   public int PuzzleIndex = 0;
    public int SeverityLevel = 2;

    public Button Next_Item;
    
    // Start is called before the first frame update
    void Start()
    {

        initiatePuzzleLevel();
    }

    public void initiatePuzzleLevel()
    {
        // ResetLevel();
        Next_Item.gameObject.SetActive(false);
        setActiveLevel(SeverityLevel);
        InitializeLevel(SeverityLevel);
        Active_Level.Initiate_Puzzle(PuzzleIndex);
    }

    public void ReactivatePuzzle()
    {
        ResetLevel();
        Next_Item.gameObject.SetActive(false);
        Active_Level.Initiate_Puzzle(PuzzleIndex);
    }

    public void setActiveLevel(int index)
    {
        Active_Level = Puzzle_Levels_List[index];
    }

    public void InitializeLevel(int level)
    {
        Active_Level.InitializeLevel(level);
    }
    
    public void OnPuzzle_Card_Placed()
    {
        Score++;

        if(Score >= Active_Level.TargetScore)
        {
            Debug.Log("level Completed Successfully");
            PuzzleIndex++;
            Next_Item.gameObject.SetActive(true);
            
        }else
        {
            Debug.Log("Move on to next card");
        }
    }



    public void ResetLevel()
    {
        Score = 0;
        Active_Level.ResetLevel();
    }


}
