using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Target_Tile : MonoBehaviour
{
    public int Tile_id;

    public void Set_Sprite(Sprite sp , float alpha)
    {
        this.GetComponent<SpriteRenderer>().sprite = sp;
        this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
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
