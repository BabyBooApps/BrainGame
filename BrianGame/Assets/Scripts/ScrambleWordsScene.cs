using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrambleWordsScene : MonoBehaviour
{
    public List<ScrambleWords_Object> ScrambleWords_Items = new List<ScrambleWords_Object>();
    public SpriteRenderer Item_Image;
    public string Item_Name;
    public List<char> ShuffledChar = new List<char>();
    public int TestIndex = 0;
    
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
    }
    public void SetItemImage(Sprite img)
    {
        Item_Image.sprite = img;
    }
}
