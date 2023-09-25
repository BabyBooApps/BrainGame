using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Loading_Animation : MonoBehaviour
{
    public GameObject Icon;
    public LoadingCircle Loading_Circle;
    public TextMeshPro Loading_Txt;
    public LoadingIcon loading_Icon;

    public Transform Final_Icon_Transform;

    public IEnumerator Animate_Loading()
    {
        yield return new WaitForEndOfFrame();

        Loading_Circle.StartAnimation();

        yield return new WaitForSeconds(1.0f);

        Loading_Circle.CanAnimate = false;
        Loading_Circle.gameObject.SetActive(false);
        Loading_Txt.gameObject.SetActive(false);

        loading_Icon.Scale_And_Move_Icon(Final_Icon_Transform);
    }

    
}
