using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Matching : MonoBehaviour
{
    public void OnMenuButtonClick()
    {
        AudioManager.Instance.Play_Btn_CLick();
        GamePlayManager.Instance.Matching_Level.DisableLevel();
        UI_Manager.Instance.BackToMenu();
        this.gameObject.SetActive(false);
    }
}
