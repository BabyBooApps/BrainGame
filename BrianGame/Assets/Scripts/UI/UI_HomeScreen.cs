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

}
