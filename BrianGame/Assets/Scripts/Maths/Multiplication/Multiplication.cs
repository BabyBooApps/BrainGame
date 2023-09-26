using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication : MonoBehaviour
{
    public DynamicGridManager Grid;
    public int Multiplier = 1;

    public List<Vector3> Get_Obj_Positions(List<int> QuestionsList)
    {
        List<Vector3> PosList = new List<Vector3>();

        PosList = Grid.GenerateGrid(QuestionsList[0] , QuestionsList[1]);

        return PosList;
    }
    public int Perform_Multiplication(int a, int b)
    {
        int c;
        c = a * b;

        return c;
    }
}
