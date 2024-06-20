using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HomeScreen : UI_Screen
{
    public Button MenuScreen_Btn;
    public Button NoAdsBtn;
    private void Start()
    {
        Set_No_Ads_Btn();
    }

    public void On_MenuScreen_Button_Click()
    {
        AudioManager.Instance.Play_Btn_CLick();
        UI_Manager.Instance.MoveToMenuScreen();
    }

    public void OnSettings_ButtonClick()
    {
        UI_Manager.Instance.OnSettings_Button_Click();
    }

    public void Set_No_Ads_Btn()
    {
        //NoAdsBtn.enabled = !PlayerPrefsManager.Instance.GetNoAdsStatus();
        NoAdsBtn.gameObject.SetActive(!PlayerPrefsManager.Instance.GetNoAdsStatus());
    }

    public void On_Moregames_Button_Click()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=6487105028651572662");
    }

    public void On_Rating_Btn_Click()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.babybooapps.braingame");
    }

}
