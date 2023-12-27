using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Math : MonoBehaviour
{
    public UI_Math_Selection Math_SelectionScreen;
    public GameObject GameScreen;
    public UI_MultiplicationPopUP multiplication_PopUp;

    public void ActivateMathSelectionScreen()
    {
        Math_SelectionScreen.gameObject.SetActive(true);
        GameScreen.SetActive(false);
        multiplication_PopUp.gameObject.SetActive(false);
    }
    public void DeactivateMathSelectionScreen()
    {
        Math_SelectionScreen.gameObject.SetActive(false);
        GameScreen.SetActive(true);
        multiplication_PopUp.gameObject.SetActive(false);
    }

    public void OnMenuButtonClicked()
    {
        AudioManager.Instance.Play_Btn_CLick();
        UI_Manager.Instance.BackToMenu();
        GamePlayManager.Instance.Math_Level.DisableLevel();
        this.gameObject.SetActive(false);
    }
}
