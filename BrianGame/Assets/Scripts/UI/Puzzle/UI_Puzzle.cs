using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Puzzle : MonoBehaviour
{
    public UI_Puzzle_Select Puzzle_Selection;
    public GameObject Puzzle_Game_Screen;
    public int Get_Puzzle_Cards()
    {
        int count = 0;

         count = Puzzle_Selection.RadioButton_Groups[0].GetSelectedIndex();

        return count;
    }

    public int Get_Puzzle_Severity()
    {
        int count = 0;

        count = Puzzle_Selection.RadioButton_Groups[1].GetSelectedIndex();

        return count;
    }

    public void Activate_Puzzle_Selection_Screen()
    {
        Puzzle_Game_Screen.SetActive(false);
        Puzzle_Selection.gameObject.SetActive(true);
    }

    public void Activate_Puzzle_Game_Screen()
    {
        Puzzle_Game_Screen.SetActive(true);
        Puzzle_Selection.gameObject.SetActive(false);
    }

    public void OnStartPuzzleBtn_Click()
    {
        AudioManager.Instance.Play_Btn_CLick();
        UI_Manager.Instance.InitializePuzzleLevel(Get_Puzzle_Cards(), Get_Puzzle_Severity());
    }

    public void OnMenuButtonClick()
    {
        AudioManager.Instance.Play_Btn_CLick();
        GamePlayManager.Instance.Puzzle_Scene.DisableLevel();
        UI_Manager.Instance.BackToMenu();
        this.gameObject.SetActive(false);
    }
}
