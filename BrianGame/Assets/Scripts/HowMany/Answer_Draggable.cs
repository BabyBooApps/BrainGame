using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Answer_Draggable : MonoBehaviour
{
    public int Id;
    public TextMeshPro text_obj;
    public Vector3 StartingPos;
    public DraggableObject drag_obj;
    public AnswerTile Target_Ans;
    public bool isAnswered = false;

    private void Start()
    {
        StartingPos = this.transform.position;
        drag_obj = GetComponent<DraggableObject>();
        drag_obj.CanMove = false;
    }

    public void ResetTile()
    {
        drag_obj.CanMove = false;
        this.transform.position = StartingPos;
        isAnswered = false;
        Target_Ans = null;
    }
    public void SetId(int id)
    {
        Id = id;
        text_obj.text = id.ToString();
        
    }

    public void OnMouseDown()
    {
        if(!isAnswered)
        drag_obj.CanMove = true;
    }

    private void OnMouseUp()
    {
        drag_obj.CanMove = false;
        if (Target_Ans)
        {
            if(Target_Ans.Id == Id)
            {
                Debug.Log("Matched Successfully");
                isAnswered = true;
                this.transform.position = Target_Ans.transform.position;
                
                GamePlayManager.Instance.HowMany_Scene.OnAnswerMatched(Id);
            }else
            {
                Debug.Log("Not Matched");
                AudioManager.Instance.PlayFailClip();
                iTween.MoveTo(this.gameObject, StartingPos, 0.5f);
            }
        }else
        {
            Debug.Log("Not connected to other tile");
            iTween.MoveTo(this.gameObject, StartingPos, 0.5f);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<AnswerTile>())
        {
            Target_Ans = collision.GetComponent<AnswerTile>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<AnswerTile>())
        {
            Target_Ans = null;
        }
    }

}
