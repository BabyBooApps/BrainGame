using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrambleWords_Char_Tile : MonoBehaviour
{
    public TextMeshPro text_Obj;
    public string TileId;
    public string Target_Id;
    public Vector3 InitialPos;
    public ScrambleWords_Target_Tile Target;
    bool isPlacedAtTarget = false;

    void SetPosition(Vector3 pos)
    {
        this.transform.position = pos;
    }
    void SetChar(string c)
    {
        text_Obj.text = c;
    }

    public void SetTile(Vector3 pos, string c)
    {
        //SetPosition(pos);
        InitialPos = pos;
        SetChar(c);
        SetTileId(c);
    }
    public void SetTileId(string id)
    {
        TileId = id;
    }

    public void ValidateMove()
    {
        if(TileId == Target_Id)
        {
            Debug.Log("Matched Tile");
            isPlacedAtTarget = true;
           // GetComponent<Collider2D>().enabled = false;
            Fit_Target_Pos();
            GamePlayManager.Instance.ScrambleWords_Level.On_Tile_Validated();
        }else
        {
            Debug.Log("Tile Not Matched");
            BackToInitialPos();
        }
    }
    private void OnMouseUp()
    {
        ValidateMove();
    }

    private void BackToInitialPos()
    {
        iTween.MoveTo(this.gameObject, InitialPos, 0.5f);
    }

    private void Fit_Target_Pos()
    {
        if(Target != null)
        {
            this.transform.position = Target.transform.position;
            GetComponent<DraggableObject>().CanMove = false;
            Target.IsFilled = true;
            //Target.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.GetComponent<ScrambleWords_Target_Tile>())
        {
            Debug.Log("Collided with : " + other.GetComponent<ScrambleWords_Target_Tile>().Target_tile_Id);
            Target = other.GetComponent<ScrambleWords_Target_Tile>();
            if(!Target.IsFilled)
            {
                Target_Id = Target.Target_tile_Id;
                
            }else
            {
                Target = null;
            }
            
          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ScrambleWords_Target_Tile>())
        {
            if(!collision.GetComponent<ScrambleWords_Target_Tile>().IsFilled)
            {
                Debug.Log("Collision ended with : " + collision.GetComponent<ScrambleWords_Target_Tile>().Target_tile_Id);
                Target = null;
            }
            
        }
    }
}

