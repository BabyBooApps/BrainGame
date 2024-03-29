using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public Loading_Animation LoadingAnimation;
    public Puzzle_Level Active_Level;
    public List<Puzzle_Level> Puzzle_Levels_List = new List<Puzzle_Level>();
  //  public Puzzle_Level Puzzle_2x2;
   
    public int Score = 0;
   public int PuzzleIndex = 0;
    public int SeverityLevel = 1;
    public int alphaVal = 0;

    public Button Next_Item;
    
    // Start is called before the first frame update
    void Start()
    {

        //initiatePuzzleLevel();
    }

    public void initiatePuzzleLevel(int cardsCount , int severity)
    {
        // ResetLevel();
        StartCoroutine(ActivatePuzzleLevel(cardsCount, severity));
    }

    public IEnumerator ActivatePuzzleLevel(int cardsCount, int severity)
    {
        yield return LoadingAnimation.Animate_Loading();
        yield return new WaitForSeconds(0.5f);

        SeverityLevel = cardsCount;
        alphaVal = severity;
        Next_Item.gameObject.SetActive(false);
        setActiveLevel(SeverityLevel);
        InitializeLevel(SeverityLevel);
        Active_Level.gameObject.SetActive(true);
        Active_Level.Initiate_Puzzle(PuzzleIndex, alphaVal);
      

    }

    public void ReactivatePuzzle()
    {
        AudioManager.Instance.PlayNextLevelClip();
        ResetLevel();
        Next_Item.gameObject.SetActive(false);

        Active_Level.Initiate_Puzzle(PuzzleIndex , alphaVal);
        Active_Level.gameObject.SetActive(true);
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
            StartCoroutine(Level_Complete());

        }
        else
        {
            Debug.Log("Move on to next card");
        }
    }

    public IEnumerator Level_Complete()
    {
        yield return new WaitForSeconds(1.5f);
        Active_Level.Enable_Final_Image();
        AudioManager.Instance.Play_Game_AudioClip(Active_Level.Current_Puzzle_Level.Puzzle_Id);
        yield return new WaitForSeconds(1.0f);
        iTween.PunchScale(Active_Level.gameObject, new Vector3(1.1f, 1.1f,1.1f), 1.5f);
        AudioManager.Instance.Play_Cheering_Clip();
        yield return new WaitForSeconds(3.0f);
       
        PuzzleIndex++;
        yield return new WaitForSeconds(1.5f);
        AudioManager.Instance.PlayLevelCompleteClip();
        Next_Item.gameObject.SetActive(true);
    }



    public void ResetLevel()
    {
       
        Score = 0;
        Active_Level.ResetLevel();
       
       
    }

    public void DisableLevel()
    {
        LoadingAnimation.ResetLoading();
        ResetLevel();
        Active_Level.DisableLevel();
        Active_Level.gameObject.SetActive(false);
        Active_Level = null;
        for (int i = 0; i < Puzzle_Levels_List.Count; i++)
        {
            Puzzle_Levels_List[i].gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }


}
