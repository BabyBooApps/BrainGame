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

    
}
