using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Tile_Drag : MonoBehaviour
{
    public int id;
    public Vector3 InitialSize;
    public Vector3 initialPos;

    public Vector3 Match_Pos;

    DraggableObject drag_script;

    bool isAligned = false;
    private void Start()
    {
        InitialSize = this.transform.localScale;
        initialPos = this.transform.position;
        drag_script = GetComponent<DraggableObject>();
    }

    public void ResetTile()
    {
        this.transform.position = initialPos;
        this.transform.localScale = InitialSize;
        isAligned = false;
        drag_script.CanMove = false;
    }
    public void SetSprite(Sprite sp)
    {
        GetComponent<SpriteRenderer>().sprite = sp;
    }

    public void setId(int ID)
    {
        id = ID;
    }

    public void SetMatchPos(Vector3 pos)
    {
        Match_Pos = pos;
    }

    public int getId()
    {
        return id;
    }

    public void ValidateMove()
    {
       float distance =  Vector3.Distance(this.transform.position, Match_Pos);
        Debug.Log("distance : " +distance);
        if(distance < 1.2f)
        {
            AudioManager.Instance.Play_Correct_Answer_Clip();
            iTween.MoveTo(this.gameObject, new Vector3(Match_Pos.x,Match_Pos.y,-1), 0.2f);
            drag_script.CanMove = false;
            isAligned = true;
            GamePlayManager.Instance.Puzzle_Scene.OnPuzzle_Card_Placed();
           
        }
        else
        {
            AudioManager.Instance.PlayFailClip();
            iTween.ScaleTo(this.gameObject, InitialSize, 0.5f);
            iTween.MoveTo(this.gameObject, initialPos, 1.0f);
        }
        
           
        //Vector3 pos = this.transform.position;
        //if(Mathf.Abs(pos.x - Match_Pos.x) < 50 )
        //{
        //    Debug.Log("Matched in X pos");

        //    if (Mathf.Abs(pos.y - Match_Pos.y) < 50)
        //    {

        //    }
        //}

    }

    private void OnMouseDown()
    {
        if(!isAligned)
        {
            drag_script.CanMove = true;
            iTween.ScaleTo(this.gameObject, Vector3.one, 0.5f);
        }
        
    }

    private void OnMouseUp()
    {
        if(!isAligned)
        {
            drag_script.CanMove = false;
            ValidateMove();
        }
       
        
    }
}
