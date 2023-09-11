using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Target_Tile : MonoBehaviour
{
    public int Tile_id;

    public void Set_Sprite(Sprite sp)
    {
        this.GetComponent<SpriteRenderer>().sprite = sp;
    }

    public void setId(int id)
    {
        Tile_id = id;
    }

    public int getId()
    {
        return Tile_id;
    }
}
