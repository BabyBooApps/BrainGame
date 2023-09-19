using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Addition_Level : MonoBehaviour
{
    public DynamicGridManager LeftGrid;
    public DynamicGridManager Right_Grid;

    public List<Vector3> Get_Obj_Positions(List<int> QuestionsList)
    {
        List<Vector3> PosList = new List<Vector3>();

        List<Vector3> LeftPosList = LeftGrid.CalculateGridPositions_V2(QuestionsList[0]);
        List<Vector3> RightPosList = Right_Grid.CalculateGridPositions_V2(QuestionsList[1]);

        for(int i = 0; i < LeftPosList.Count; i++)
        {
            PosList.Add(LeftPosList[i]);
        }
        for (int i = 0; i < RightPosList.Count; i++)
        {
            PosList.Add(RightPosList[i]);
        }

        return PosList;
    }

    public int Perform_Addition(int a , int b)
    {
        int c;
        c = a + b;

        return c;
    }
}
