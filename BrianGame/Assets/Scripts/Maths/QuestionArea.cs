using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionArea : MonoBehaviour
{
    public TextMeshPro Question_Seg1;
    public TextMeshPro Question_Seg2;
    public TextMeshPro Math_Type;
    public TextMeshPro Equal;
    public TextMeshPro Answer;

    public Math_Target_Answer TargetAnswer;

    public void set_Question_Seg1(string Q1)
    {
        Question_Seg1.text = Q1;
    }

    public void set_Question_Seg2(string Q2)
    {
        Question_Seg2.text = Q2;
    }

    public void set_MathType(string type)
    {
        Math_Type.text = type;
    }

    public void set_Answer(string Ans)
    {
        Answer.text = Ans;
        Answer.gameObject.SetActive(false);
    }

   
}
