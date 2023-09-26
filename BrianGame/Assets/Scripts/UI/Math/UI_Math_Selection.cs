using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Math_Selection : MonoBehaviour
{
    public Button Addition_Btn;
    public Button Substraction_Btn;
    public Button Multiplication_Btn;

    public void OnAdditionButtonClick()
    {
        UI_Manager.Instance.initializeMathLevel(Math_Type.Addition);
    }

    public void OnSubstractionButtonClick()
    {
        UI_Manager.Instance.initializeMathLevel(Math_Type.Subtraction);
    }

    public void OnMultiplicationButtonClick()
    {
        UI_Manager.Instance.Activate_Multiplcation_SelectionPopUp();
    }



}
