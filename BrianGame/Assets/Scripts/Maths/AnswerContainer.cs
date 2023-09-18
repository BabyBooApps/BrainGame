using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerContainer : MonoBehaviour
{
    public List<Math_Answer_Tile> Answer_Tiles = new List<Math_Answer_Tile>();
    

    public List<Math_Answer_Tile> GetAnswerTiles()
    {
        return Answer_Tiles.Shuffle();
    }
   
}
