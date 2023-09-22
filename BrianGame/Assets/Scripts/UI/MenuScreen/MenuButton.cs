using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    Button btn;
    Image Img;
    private void Start()
    {
        btn = GetComponent<Button>();
        Img = GetComponent<Image>();
        //SetAlpha(0);
    }
    public void EnableButton()
    {
        // Rotate the UI element by the specified angle.
       
        try
        {

            RectTransform rect = GetComponent<RectTransform>();
            rect.localRotation = Quaternion.Euler(0f, 90, 0);
            iTween.RotateTo(this.gameObject, new Vector3(0, 360, 0), 0.5f);
        }
        catch(Exception ex)
        {
            Debug.Log("Lean Tween Rotation error : " + ex.Message);
        }
        
    }

    public void SetAlpha(int alpha_val)
    {
        // Create a color with the same RGB values but alpha set to zero.
        Color transparentColor = new Color(Img.color.r, Img.color.g, Img.color.b,alpha_val);

        // Set the button's Image color to the transparent color.
        Img.color = transparentColor;
    }
}
