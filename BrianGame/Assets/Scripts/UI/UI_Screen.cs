using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Screen : MonoBehaviour
{
    

    public void ShowScreen()
    {
        this.gameObject.SetActive(true);
    }

    public void HideScreen()
    {
        this.gameObject.SetActive(false);
    }
    
}
