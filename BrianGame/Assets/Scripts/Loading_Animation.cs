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

    Vector3 Icon_Pos_Initial;
    Vector3 Icon_Scale_Initial;


    private void Start()
    {
        Icon_Pos_Initial = Icon.transform.position;
        Icon_Scale_Initial = Icon.transform.localScale;
    }

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

    public void ResetLoading()
    {
        Icon.transform.position = Icon_Pos_Initial;
        Icon.transform.localScale = Icon_Scale_Initial;
        Loading_Circle.gameObject.SetActive(true);
        Loading_Circle.Reset_circle();
        Loading_Txt.gameObject.SetActive(true);
    }

    
}
