using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Math_Answer_Tile : MonoBehaviour
{
    public GameObject Text_Obj;
    public int Id;
    public DraggableObject drag_Obj;
    public GameObject collidedObj;
    public Vector3 initialPos;

    private void Awake()
    {
        initialPos = this.transform.position;
    }
    private void Start()
    {
        drag_Obj = GetComponent<DraggableObject>();
       
    }
    public void SetText(int val)
    {
        Text_Obj.GetComponent<TextMeshPro>().text = val.ToString();
        SetId(val);
    }

    public void SetId(int val)
    {
        Id = val;
    }

    public int getId()
    {
        return Id;
    }

    private void OnMouseUp()
    {
        if(collidedObj)
        {
            ValidateAnswer(collidedObj);
        }else
        {
            iTween.MoveTo(this.gameObject, initialPos, 1.0f);
        }
    }

    void ValidateAnswer(GameObject obj)
    {
        if(obj.GetComponent<Math_Target_Answer>())
        {
            if(obj.GetComponent<Math_Target_Answer>().GetId() == getId())
            {
                Debug.Log("Answer Matched Successfully");
                this.transform.position = obj.transform.position;
                drag_Obj.CanMove = false;
                GamePlayManager.Instance.Math_Level.OnAnswerValidated();
            }else
            {
                Debug.Log("Wrong Answer");
                iTween.MoveTo(this.gameObject, initialPos, 1.0f);
            }
        }else
        {
            Debug.Log("Wrong Tile");
            iTween.MoveTo(this.gameObject, initialPos, 1.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with : " + collision.name);
        collidedObj = collision.gameObject;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collidedObj = null;
    }

    public void ResetTile()
    {
        if(drag_Obj)
        drag_Obj.CanMove = true;

        this.transform.position = initialPos;
    }
}
