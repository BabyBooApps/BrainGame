using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Substraction : MonoBehaviour
{
    public DynamicGridManager Grid;

    public List<Vector3> Get_Obj_Positions(List<int> QuestionsList)
    {
        List<Vector3> PosList = new List<Vector3>();

        PosList = Grid.CalculateGridPositions_V3(QuestionsList[0]);

        return PosList;
    }

    public int Perform_Substraction(int a, int b)
    {
        int c;
        c = a - b;

        return c;
    }
}
