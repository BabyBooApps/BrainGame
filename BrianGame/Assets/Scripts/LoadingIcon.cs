using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingIcon : MonoBehaviour
{
    public Transform intialTransform;
    Vector3 initialiPos;
    Vector3 InitialScale;
  
    private void Start()
    {
        intialTransform = this.transform;
        initialiPos = intialTransform.position;
        InitialScale = intialTransform.localScale;
    }
    public void Scale_And_Move_Icon(Transform targetPos)
    {
        iTween.MoveTo(this.gameObject, targetPos.position, 1.0f);
        iTween.ScaleTo(this.gameObject, targetPos.localScale, 1.0f);

    }

    public void Reset_Loading_Icon()
    {
        this.transform.position = initialiPos;
        this.transform.localScale = InitialScale;
    }
}
