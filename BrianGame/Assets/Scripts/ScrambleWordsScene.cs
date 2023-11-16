using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScrambleWordsScene : MonoBehaviour
{
    public Loading_Animation loadingAnimation;
    List<ScrambleWords_Object> ScrambleWords_Items = new List<ScrambleWords_Object>();
    public SpriteRenderer Item_Image;
    public Transform Item_Image_Pos;
    public string Item_Name;
    public TextMeshPro Item_Name_Object;
    public List<char> ShuffledChar = new List<char>();
    public int TestIndex = 0;
    public int MatchedTiles = 0;
    public List<Vector3> CharTilesPositionsList = new List<Vector3>();
    public List<Vector3> TargetTilesPositionsList = new List<Vector3>();
    List<ScrambleWords_Char_Tile> CharTiles = new List<ScrambleWords_Char_Tile>();
    List<ScrambleWords_Target_Tile> TargetTiles = new List<ScrambleWords_Target_Tile>();

    public List<Transform> Three_Character_Questions = new List<Transform>();
    public List<Transform> Three_Character_Answers = new List<Transform>();
    public List<Transform> Four_Character_Questions = new List<Transform>();
    public List<Transform> Four_Character_Answers = new List<Transform>();
    public List<Transform> Five_Character_Questions = new List<Transform>();
    public List<Transform> Five_Character_Answers = new List<Transform>();
    public List<Transform> Six_Character_Questions = new List<Transform>();
    public List<Transform> Six_Character_Answers = new List<Transform>();

    List<List<Vector3>> Three_Character_Words_Pos = new List<List<Vector3>>
    {
       new List<Vector3>{new Vector3(-0.77f,-1.7f,0), new Vector3(-0.77f, -3.7f, 0)},
       new List<Vector3>{new Vector3(0.92f,-1.7f,0), new Vector3(0.92f, -3.7f, 0)},
       new List<Vector3>{new Vector3(2.64f, -1.7f, 0), new Vector3(2.64f, -3.7f, 0)}

    };
    List<List<Vector3>> Four_Character_Words_Pos = new List<List<Vector3>>
    {
       new List<Vector3>{new Vector3(-0.33f, -1.7f, 0), new Vector3(-0.33f, -3.7f, 0)},
       new List<Vector3>{new Vector3(1.36f, -1.7f, 0), new Vector3(1.36f, -3.7f, 0)},
       new List<Vector3>{new Vector3(3.08f, -1.7f, 0), new Vector3(3.08f, -3.7f, 0)},
        new List<Vector3>{new Vector3(4.91f, -1.7f, 0), new Vector3(4.91f, -3.7f, 0)}

    };
    List<List<Vector3>> Five_Character_Words_Pos = new List<List<Vector3>>
    {
       new List<Vector3>{new Vector3(-1.33f, -1.7f, 0), new Vector3(-1.33f, -3.7f, 0)},
       new List<Vector3>{new Vector3(0.36f, -1.7f, 0), new Vector3(0.36f, -3.7f, 0)},
       new List<Vector3>{new Vector3(2.08f, -1.7f, 0), new Vector3(2.08f, -3.7f, 0)},
       new List<Vector3>{new Vector3(3.91f, -1.7f, 0), new Vector3(3.91f, -3.7f, 0)},
       new List<Vector3>{new Vector3(5.7f, -1.7f, 0), new Vector3(5.7f, -3.7f, 0)}

    };
    List<List<Vector3>> Six_Character_Words_Pos = new List<List<Vector3>>
    {
       new List<Vector3>{new Vector3(-2.23f, -1.7f, 0), new Vector3(-2.23f, -3.7f, 0)},
       new List<Vector3>{new Vector3(-0.54f, -1.7f, 0), new Vector3(-0.54f, -3.7f, 0)},
       new List<Vector3>{new Vector3(1.18f, -1.7f, 0), new Vector3(1.18f, -3.7f, 0)},
       new List<Vector3>{new Vector3(3.01f, -1.7f, 0), new Vector3(3.01f, -3.7f, 0)},
       new List<Vector3>{new Vector3(4.8f, -1.7f, 0), new Vector3(4.8f, -3.7f, 0)},
       new List<Vector3>{new Vector3(6.6f, -1.7f, 0), new Vector3(6.6f, -3.7f, 0)}

    };

    public ScrambleWords_Char_Tile Tile_Prefab;
    public ScrambleWords_Target_Tile Target_Tile_Prefab;

    public Vector3 Item_Anim_Pos = new Vector3(1f, -3, 0);

    public List<ScrambleWords_Object> GetScrambleWordsItems()
    {
        List<ScrambleWords_Object> ScrambleWords_Items_Temp = GameData.Instance.ScrambleWords_Items;
        return ScrambleWords_Items_Temp.Shuffle();
    }

    public void Initialize()
    {
        StartCoroutine(Animate_Initialize());
    }

    IEnumerator Animate_Initialize()
    {
        Item_Image.gameObject.SetActive(false);
        ScrambleWords_Items = GetScrambleWordsItems();
        yield return loadingAnimation.Animate_Loading();
        yield return new WaitForSeconds(0.5f);
        yield return SetTestItem(TestIndex);
        //StartCoroutine(SetTestItem(TestIndex)) ;
    }

    public void SetItemName_Object(bool active)
    {
        if (active)
        {
            Item_Name_Object.gameObject.SetActive(true);
            Item_Name_Object.text = Item_Name;
            Item_Name_Object.transform.localScale = Vector3.zero;
            iTween.ScaleTo(Item_Name_Object.gameObject, Vector3.one, 1.0f);
        }
        else
        {
            Item_Name_Object.gameObject.SetActive(false);
        }
    }

    public IEnumerator SetTestItem(int index)
    {
        Item_Image.gameObject.SetActive(true);
        Sprite Test_Sprite = ScrambleWords_Items[index].Object_Image;
        SetItemName_Object(false);
        SetItemImage(Test_Sprite);
        iTween.MoveTo(Item_Image.gameObject, Item_Image_Pos.position, 1.0f);
        Item_Image.GetComponent<BeatAnimation>().CanAnimate = true;
        Item_Name = ScrambleWords_Items[index].Object_Name;
        Debug.Log("Item Name : " + Item_Name);
        ShuffledChar.Clear();
        ShuffledChar = Item_Name.ShffleCharFromString();
        yield return new WaitForSeconds(0.5f);

        SetPositionsOfTiles(ShuffledChar.Count);
        StartCoroutine(SpawnCharTiles(ShuffledChar.Count));
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(SpawnTargetTiles(ShuffledChar.Count));
    }

    public void On_Tile_Validated()
    {
        MatchedTiles++;
        if (MatchedTiles >= ShuffledChar.Count)
        {
            TestIndex++;
            Debug.Log("Word Matched Correctly");
            StartCoroutine(MoveToNextItem());

        }
        else
        {

            Debug.Log("Move To Next Char");

        }
    }

    IEnumerator MoveToNextItem()
    {
        yield return StartCoroutine(SuccessAnimation());
        clearExistingItems();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SetTestItem(TestIndex));
    }

    IEnumerator SuccessAnimation()
    {
        Item_Image.GetComponent<BeatAnimation>().CanAnimate = false;
        yield return new WaitForSeconds(0.5f);
        DisableTiles();
        iTween.MoveTo(Item_Image.gameObject, Item_Anim_Pos, 1.0f);
        iTween.ScaleTo(Item_Image.gameObject, new Vector3(1.5f, 1.5f, 1), 1f);
        yield return new WaitForSeconds(0.5f);
        SetItemName_Object(true);
        yield return new WaitForSeconds(1.0f);



    }

    public void DisableTiles()
    {
        for (int i = 0; i < CharTiles.Count; i++)
        {
            // iTween.FadeTo(CharTiles[i].gameObject, 0, 0.2f);
            CharTiles[i].gameObject.SetActive(false);
        }
        for (int J = 0; J < TargetTiles.Count; J++)
        {
            // iTween.FadeTo(TargetTiles[J].gameObject, 0, 0.2f);
            TargetTiles[J].gameObject.SetActive(false);
        }
    }

    public void clearExistingItems()
    {
        ShuffledChar.Clear();
        for (int i = 0; i < CharTiles.Count; i++)
        {
            Destroy(CharTiles[i].gameObject);
        }
        for (int J = 0; J < TargetTiles.Count; J++)
        {
            Destroy(TargetTiles[J].gameObject);
        }

        CharTiles.Clear();
        TargetTiles.Clear();
        CharTilesPositionsList.Clear();
        TargetTilesPositionsList.Clear();
        MatchedTiles = 0;

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

        switch (charCount)
        {
            case 3:
                TargetPosList = ConvertTransformListToVector3Pos(Three_Character_Questions,Three_Character_Answers);
                break;
            case 4:
                //TargetPosList = Four_Character_Words_Pos;
                TargetPosList = ConvertTransformListToVector3Pos(Four_Character_Questions, Four_Character_Answers);
                break;
            case 5:
                //TargetPosList = Five_Character_Words_Pos;
                TargetPosList = ConvertTransformListToVector3Pos(Five_Character_Questions, Five_Character_Answers); 
                break;
            case 6:
                //TargetPosList = Six_Character_Words_Pos;
                TargetPosList = ConvertTransformListToVector3Pos(Six_Character_Questions, Six_Character_Answers);
                break;
        }

        if (TargetPosList.Count > 0)
        {
            for (int i = 0; i < TargetPosList.Count; i++)
            {
                CharTilesPositionsList.Add(TargetPosList[i][0]);
                TargetTilesPositionsList.Add(TargetPosList[i][1]);

            }
        }

        //TargetPosList.Clear();


    }

    public List<List<Vector3>> ConvertTransformListToVector3Pos(List<Transform> QuestionList, List<Transform> AnswerList)
    {
        try
        {
            List<List<Vector3>> finalPosList = new List<List<Vector3>>();

            for (int i = 0; i < QuestionList.Count; i++)
            {
                List<Vector3> TempPosList = new List<Vector3>(); // Create a new TempPosList for each iteration

                TempPosList.Add(QuestionList[i].transform.position);
                TempPosList.Add(AnswerList[i].transform.position);

                finalPosList.Add(TempPosList);
            }

            return finalPosList;
        }
        catch (Exception ex)
        {
            Debug.Log("Setting character positions list error : " + ex.Message);
        }

        return null;
    }


    IEnumerator SpawnCharTiles(int tileCount)
    {
        for (int i = 0; i < tileCount; i++)
        {
            ScrambleWords_Char_Tile tile = Instantiate(Tile_Prefab) as ScrambleWords_Char_Tile;
            tile.transform.position = CharTilesPositionsList[i];
            tile.SetTile(CharTilesPositionsList[i], ShuffledChar[i].ToString());
            iTween.ShakeRotation(tile.gameObject, new Vector3(0, 90, 0), 0.5f);
            CharTiles.Add(tile);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator SpawnTargetTiles(int tileCount)
    {
        for (int i = 0; i < tileCount; i++)
        {
            ScrambleWords_Target_Tile tile = Instantiate(Target_Tile_Prefab) as ScrambleWords_Target_Tile;
            tile.transform.position = TargetTilesPositionsList[i];
            tile.SetTile(TargetTilesPositionsList[i], Item_Name[i].ToString());
            iTween.ShakeRotation(tile.gameObject, new Vector3(0, 90, 0), 0.5f);
            TargetTiles.Add(tile);
            yield return new WaitForSeconds(0.1f);

        }
    }

    public void DisableLevel()
    {
        loadingAnimation.ResetLoading();
        clearExistingItems();
        TestIndex = 0;
        MatchedTiles = 0;
        this.gameObject.SetActive(false);

    }
}
