using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeatAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimateObject());
    }


    void AnimateBeatUp()
    {
        iTween.PunchScale(this.gameObject, new Vector3(0.5f, 0.5f, 0), 2.2f);
    }
    void AnimateBeatDown()
    {
        iTween.PunchScale(this.gameObject, new Vector3(0.5f, 0.5f, 0), 1.2f);
    }

    IEnumerator AnimateObject()
    {
        AnimateBeatUp();
        yield return new WaitForSeconds (1.25f);
        StartCoroutine(AnimateObject());

    }
}
