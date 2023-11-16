using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MultiplicationPopUP : MonoBehaviour
{
    public Dropdown Tables_Dropdown;
   public void SetMultiplier()
    {
        GamePlayManager.Instance.Math_Level.Multiplication_Level.Multiplier = Tables_Dropdown.value + 1;
    }

    public void On_Table_Selected(int val)
    {
        GamePlayManager.Instance.Math_Level.Multiplication_Level.Multiplier = val;
        UI_Manager.Instance.initializeMathLevel(Math_Type.Multiplication);
    }

    public void OnOkClicked()
    {
        UI_Manager.Instance.initializeMathLevel(Math_Type.Multiplication);
    }
}
