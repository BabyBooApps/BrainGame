using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HowMany : UI_Screen
{
    public Button Next_Question_Button;

    public void On_Next_Button_Click()
    {
        GamePlayManager.Instance.HowMany_Scene.OnNextClicked();
    }

    public void Disable_Next_Btn()
    {
        Next_Question_Button.gameObject.SetActive(false);
    }

    public void Enable_Next_Button()
    {
        Next_Question_Button.gameObject.SetActive(true);
    }

    public void OnMenuButtonClicked()
    {
        GamePlayManager.Instance.HowMany_Scene.DisableLevel();
        UI_Manager.Instance.BackToMenu();
        this.gameObject.SetActive(false);
    }
}
