using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public GameObject Positions_LessThan5;
    public GameObject Positions_GreaterThan5;
    public float size_LessThan_5 = 0.4f;
    public float size_GreaterThan_5 = 0.4f;
    public AnswerTile Answer;

    public List<Vector3> Target_Pos_List = new List<Vector3>();


    public void ResetContainer()
    {

        ResetChilds(Positions_LessThan5);
        ResetChilds(Positions_GreaterThan5);
    }

    public void SetSprite(GameObject obj, Sprite sp , float size)
    {
       // yield return new WaitForEndOfFrame();
        obj.GetComponent<SpriteRenderer>().sprite = sp;
        iTween.ScaleTo(obj, new Vector3(size, size, 1), 0.5f);
      //  yield return new WaitForSeconds(0.3f);
       // obj.transform.localScale = new Vector3(0.4f, 0.4f, 1);
       
    }

    public void ResetChilds(GameObject obj)
    {
        foreach (Transform child in obj.transform)
        {
            child.transform.localScale = Vector3.zero;
        }
    }
    public List<GameObject> GetTagetPosList(GameObject targetObject)
    {
        List<GameObject> TempPos = new List<GameObject>();

        foreach(Transform child in targetObject.transform)
        {
            TempPos.Add(child.gameObject);
        }

        return TempPos;
    }

    public List<GameObject> SetPositionsList(bool isLessThan5)
    {
        List<GameObject> TempPos = new List<GameObject>();

        switch(isLessThan5)
        {
            case true:
                TempPos = GetTagetPosList(Positions_LessThan5);
                break;
            case false:
                TempPos = GetTagetPosList(Positions_GreaterThan5);
                break;
        }

        return TempPos;
    }

    public float getObj_Size(bool isLessThan5)
    {
        float temp_size = 0.4f;

        switch(isLessThan5)
        {
            case true:
                temp_size = size_LessThan_5;
                break;

            case false:
                temp_size = size_GreaterThan_5;
                break;
        }
        return temp_size;
    }

    public void PopulateObject(bool lessthan5 , Sprite sp , int count)
    {
        List<GameObject> Temp = new List<GameObject>();
        Temp = SetPositionsList(lessthan5);

       // yield return new WaitForEndOfFrame();
        for(int i = 0;  i < count; i++)
        {
         // yield return SetSprite(Temp[i], sp, 0.4f);
            SetSprite(Temp[i], sp, 0.4f);


        }

        Temp.Clear();
    }
}
