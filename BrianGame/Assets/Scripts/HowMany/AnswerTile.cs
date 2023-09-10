using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerTile : MonoBehaviour
{
    public TextMeshPro Text_Filed;
    public int Id;

    public void Set_Id(int id)
    {
        Id = id;
        Text_Filed.text = id.ToString();
        Text_Filed.gameObject.SetActive(false);
    }

    public int GetId()
    {
        return Id;
    }

}
