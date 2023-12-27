using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ScrambleWords : UI_Screen
{
    public Image BackgroungImg;


    public void SetScreen()
    {
        BackgroungImg.sprite = UI_Config.Instance.ScrambleWords_Background;
        Debug.Log(UI_Config.Instance.ScrambleWords_Background.name);
    }

    public void OnMenuButtonClicked()
    {
        AudioManager.Instance.Play_Btn_CLick();
        UI_Manager.Instance.BackToMenu();
        GamePlayManager.Instance.ScrambleWords_Level.DisableLevel();
        this.gameObject.SetActive(false);
    }

    
}
