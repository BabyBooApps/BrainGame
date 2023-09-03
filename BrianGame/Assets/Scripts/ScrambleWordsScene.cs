using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrambleWordsScene : MonoBehaviour
{
    List<ScrambleWords_Object> ScrambleWords_Items = new List<ScrambleWords_Object>();
    public SpriteRenderer Item_Image;
    public string Item_Name;
    public List<char> ShuffledChar = new List<char>();
    public int TestIndex = 0;
    public List<Vector3> CharTilesPositionsList = new List<Vector3>();
    public List<Vector3> TargetTilesPositionsList = new List<Vector3>();

    List<List<Vector3>> Three_Character_Words_Pos = new List<List<Vector3>>
    {
       new List<Vector3>{new Vector3(-0.77f,1,0), new Vector3(-0.77f, -1, 0)},
       new List<Vector3>{new Vector3(0.92f,1,0), new Vector3(0.92f, -1, 0)},
       new List<Vector3>{new Vector3(2.64f,1,0), new Vector3(2.64f, -1, 0)}

    };
    List<List<Vector3>> Four_Character_Words_Pos = new List<List<Vector3>>
    {
       new List<Vector3>{new Vector3(-0.33f,1,0), new Vector3(-0.33f, -1, 0)},
       new List<Vector3>{new Vector3(1.36f,1,0), new Vector3(1.36f, -1, 0)},
       new List<Vector3>{new Vector3(3.08f,1,0), new Vector3(3.08f, -1, 0)},
        new List<Vector3>{new Vector3(4.91f,1,0), new Vector3(4.91f, -1, 0)}

    };
    List<List<Vector3>> Five_Character_Words_Pos = new List<List<Vector3>>
    {
       new List<Vector3>{new Vector3(-1.33f,1,0), new Vector3(-1.33f, -1, 0)},
       new List<Vector3>{new Vector3(0.36f,1,0), new Vector3(0.36f, -1, 0)},
       new List<Vector3>{new Vector3(2.08f,1,0), new Vector3(2.08f, -1, 0)},
       new List<Vector3>{new Vector3(3.91f,1,0), new Vector3(3.91f, -1, 0)},
       new List<Vector3>{new Vector3(5.7f,1,0), new Vector3(5.7f, -1, 0)}

    };
    List<List<Vector3>> Six_Character_Words_Pos = new List<List<Vector3>>
    {
       new List<Vector3>{new Vector3(-2.23f,1,0), new Vector3(-2.23f, -1, 0)},
       new List<Vector3>{new Vector3(-0.54f,1,0), new Vector3(-0.54f, -1, 0)},
       new List<Vector3>{new Vector3(1.18f,1,0), new Vector3(1.18f, -1, 0)},
       new List<Vector3>{new Vector3(3.01f,1,0), new Vector3(3.01f, -1, 0)},
       new List<Vector3>{new Vector3(4.8f,1,0), new Vector3(4.8f, -1, 0)},
       new List<Vector3>{new Vector3(6.6f,1,0), new Vector3(6.6f, -1, 0)}

    };

    public ScrambleWords_Char_Tile Tile_Prefab;
    public ScrambleWords_Target_Tile Target_Tile_Prefab;

    public List<ScrambleWords_Object> GetScrambleWordsItems()
    {
        List<ScrambleWords_Object>  ScrambleWords_Items_Temp = GameData.Instance.ScrambleWords_Items;
        return ScrambleWords_Items_Temp.Shuffle();
    }

    public void Initialize()
    {
        ScrambleWords_Items = GetScrambleWordsItems();
        SetTestItem(TestIndex);
    }

    public void SetTestItem(int index)
    {
        Sprite Test_Sprite = ScrambleWords_Items[index].Object_Image;
        SetItemImage(Test_Sprite);
        Item_Name = ScrambleWords_Items[index].Object_Name;
        Debug.Log("Item Name : " + Item_Name);
        ShuffledChar.Clear();
        ShuffledChar = Item_Name.ShffleCharFromString();
        SetPositionsOfTiles(ShuffledChar.Count);
        SpawnCharTiles(ShuffledChar.Count);
        SpawnTargetTiles(ShuffledChar.Count);
    }
    public void SetItemImage(Sprite img)
    {
        Item_Image.sprite = img;
    }

    public void SetPositionsOfTiles(int charCount)
    {
        CharTilesPositionsList.Clear();
        TargetTilesPositionsList.Clear();

        List<List<Vector3>> TargetPosList = new List<List<Vector3>>();

        switch(charCount)
        {
            case 3:
                TargetPosList = Three_Character_Words_Pos;
                break;
            case 4:
                TargetPosList = Four_Character_Words_Pos;
                break;
            case 5:
                TargetPosList = Five_Character_Words_Pos;
                break;
            case 6:
                TargetPosList = Six_Character_Words_Pos;
                break;
        }

        if(TargetPosList.Count > 0)
        {
            for (int i = 0; i < TargetPosList.Count; i++)
            {
                CharTilesPositionsList.Add(TargetPosList[i][0]);
                TargetTilesPositionsList.Add(TargetPosList[i][1]);
         
            }
        }

        TargetPosList.Clear();


    }

    void SpawnCharTiles(int tileCount)
    {
        for(int i = 0; i< tileCount; i++)
        {
            ScrambleWords_Char_Tile tile = Instantiate(Tile_Prefab) as ScrambleWords_Char_Tile;
            tile.transform.position = CharTilesPositionsList[i];
            tile.SetTile(CharTilesPositionsList[i], ShuffledChar[i].ToString());
           
        }
    }

    void SpawnTargetTiles(int tileCount)
    {
        for (int i = 0; i < tileCount; i++)
        {
            ScrambleWords_Target_Tile tile = Instantiate(Target_Tile_Prefab) as ScrambleWords_Target_Tile;
            tile.transform.position = TargetTilesPositionsList[i];
            tile.SetTile(TargetTilesPositionsList[i], Item_Name[i].ToString());

        }
    }
}
