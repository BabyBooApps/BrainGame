using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HomeScreen : UI_Screen
{
    public Button MenuScreen_Btn;

    public void On_MenuScreen_Button_Click()
    {
        UI_Manager.Instance.MoveToMenuScreen();
    }

}
