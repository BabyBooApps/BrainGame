using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    public TextMeshPro FirstLetter;
    public TextMeshPro SecondLetter;
    public TextMeshPro Type;
    public TextMeshPro equal;
    public TextMeshPro Answer;


    public void PerformAnimation()
    {
        
        StartCoroutine(AnimateResult());
    }
   public IEnumerator AnimateResult()
    {
        yield return new WaitForSeconds(0.5f);
        iTween.ScaleTo(this.gameObject, Vector3.one, 1.0f);

        yield return new WaitForSeconds(1.0f);

        iTween.PunchScale(FirstLetter.gameObject, new Vector3(1.2f, 1.2f, 1), 0.8f);

        yield return new WaitForSeconds(0.5f);

        iTween.PunchScale(Type.gameObject, new Vector3(1.2f, 1.2f, 1), 0.8f);

        yield return new WaitForSeconds(0.5f);

        iTween.PunchScale(SecondLetter.gameObject, new Vector3(1.2f, 1.2f, 1), 0.8f);

        yield return new WaitForSeconds(0.5f);

        iTween.PunchScale(equal.gameObject, new Vector3(1.2f, 1.2f, 1), 0.8f);

        yield return new WaitForSeconds(0.5f);

        iTween.PunchScale(Answer.gameObject, new Vector3(1.2f, 1.2f, 1), 0.8f);

        yield return new WaitForSeconds(1.0f);

        iTween.ScaleTo(this.gameObject, Vector3.zero, 1.0f);

        yield return new WaitForSeconds(1.0f);

        ResetScreen();

    }

    public void ResetScreen()
    {
        this.transform.localScale = Vector3.zero;
        this.gameObject.SetActive(false);
    }

    public void SetResult(int first, int second, string type, int answer)
    {
        FirstLetter.text = first.ToString();
        SecondLetter.text = second.ToString();
        Answer.text = answer.ToString();
        Type.text = type;
    }
}
