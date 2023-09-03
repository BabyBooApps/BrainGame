using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrambleWords_Target_Tile : MonoBehaviour
{
    public string Target_tile_Id;

    public void SetTile(Vector3 Pos , string id)
    {
        Target_tile_Id = id;
       // this.transform.position = Pos;
    }
}
