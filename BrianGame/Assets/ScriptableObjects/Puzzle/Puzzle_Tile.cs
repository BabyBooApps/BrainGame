using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PuzzleObj", menuName = "Custom/Puzzle_Obj")]

public class Puzzle_Tile : ScriptableObject
{
    public string Puzzle_Id = "";
    public List<Sprite> puzzle_Sprites_List = new List<Sprite>();
   
}
