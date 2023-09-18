using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maths_Level : MonoBehaviour
{
    public Math_Type mathType = Math_Type.Addition;
    public Addition_Level addition_Level;

    private void Start()
    {
        addition_Level = FindAnyObjectByType(typeof(Addition_Level)) as Addition_Level;

        addition_Level.GenerateQuestion_Answer();

    }
}

public enum Math_Type
{
    none,
    Addition,
    Subtraction,
    Multiplication,
    Division
}
