using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Level : MonoBehaviour
{
    public List<Puzzle_Target_Tile> Puzzle_Tiles_Target_Pos = new List<Puzzle_Target_Tile>();
    public List<Puzzle_Tile> Puzzle_Tiles_List = new List<Puzzle_Tile>();
    public List<Puzzle_Tile_Drag> Dragging_Tile = new List<Puzzle_Tile_Drag>();
    public List<Vector3> DragginTilesPosList = new List<Vector3>();
    public GameObject TilesContainer;
    public GameObject Drag_Objects_Container;
    public int id;
    public int TargetScore = 0;
    public Puzzle_Tile Current_Puzzle_Level;

    public GameObject Final_Image;

    public void InitializeLevel(int level)
    {
        Init_Puzzle_Tiles();
        Set_PuzzleTilesList(level);
        SetDraggingObject();
    }
    public List<Puzzle_Target_Tile> Init_Puzzle_Tiles()
    {
        foreach (Transform child in TilesContainer.transform)
        {
            Puzzle_Target_Tile tile = child.GetComponent<Puzzle_Target_Tile>();
            if (tile != null)
            {
                Puzzle_Tiles_Target_Pos.Add(tile);
            }
        }
        TargetScore = Puzzle_Tiles_Target_Pos.Count;

        return Puzzle_Tiles_Target_Pos;
    }

    public void Set_PuzzleTilesList(int level)
    {
        if(level == 0)
        {
            Puzzle_Tiles_List = GameData.Instance.PuzzleTiles_2x2.Shuffle();
        }else if(level == 1)
        {
            Puzzle_Tiles_List = GameData.Instance.PuzzleTiles_3x3.Shuffle();
        }
        else if(level == 2)
        {
            Puzzle_Tiles_List = GameData.Instance.PuzzleTiles_4x4.Shuffle();
        }
    }

    public void SetDraggingObject()
    {
        DragginTilesPosList.Clear();
        foreach (Transform child in Drag_Objects_Container.transform)
        {
            Puzzle_Tile_Drag tile = child.GetComponent<Puzzle_Tile_Drag>();
            if (tile != null)
            {
                Dragging_Tile.Add(tile);
                DragginTilesPosList.Add(tile.transform.position);
               
            }

        }

        Dragging_Tile =  Dragging_Tile.Shuffle();
        DragginTilesPosList = DragginTilesPosList.Shuffle();

    }

    public void Initiate_Puzzle(int no , int severity)
    {
        Final_Image.gameObject.SetActive(false);
        Set_Puzzle_Backgrounds(no,severity);
        SetDraggingObj_Backgrounds(no);
    }

    public void Set_Puzzle_Backgrounds(int puzzle_no , int severity)
    {
        for(int i = 0; i < Puzzle_Tiles_Target_Pos.Count; i++)
        {
            Current_Puzzle_Level = Puzzle_Tiles_List[puzzle_no];
            Set_Final_Image(Current_Puzzle_Level.FInal_Image);

            float alpha = 75;
            if (severity == 0)
            {
                alpha = 0.5f;
            }else
            {
                alpha = 0.1f;
            }
            Puzzle_Tiles_Target_Pos[i].Set_Sprite(Puzzle_Tiles_List[puzzle_no].puzzle_Sprites_List[i] , alpha);
            Puzzle_Tiles_Target_Pos[i].setId(i);
           
        }
    }

    public void SetDraggingObj_Backgrounds(int puzzle_no)
    {
        for (int i = 0; i < Dragging_Tile.Count; i++)
        {
            Dragging_Tile[i].SetSprite(Puzzle_Tiles_List[puzzle_no].puzzle_Sprites_List[i]);
            Dragging_Tile[i].SetMatchPos(Puzzle_Tiles_Target_Pos[i].transform.position);
            Dragging_Tile[i].setId(i);
        }
    }

    public void Set_Final_Image(Sprite sp)
    {
       
        Final_Image.GetComponent<SpriteRenderer>().sprite = sp;
    }

    public void Enable_Final_Image()
    {
        Final_Image.gameObject.SetActive(true);
    }

    public void ResetLevel()
    {
        Final_Image.gameObject.SetActive(false);
        DragginTilesPosList.Shuffle();
        for (int i = 0;  i < Dragging_Tile.Count; i++ )
        {
            Dragging_Tile[i].ResetTile();
            Dragging_Tile[i].transform.position = DragginTilesPosList[i];
            Dragging_Tile[i].SetInitialPos(DragginTilesPosList[i]);
        }
        Dragging_Tile.Shuffle();
        DragginTilesPosList.Shuffle();
        


        //Puzzle_Tiles_Target_Pos.Clear();
    }

    public void DisableLevel()
    {
        Dragging_Tile.Clear();
        Puzzle_Tiles_Target_Pos.Clear();
        TargetScore = 0;
    }

}
