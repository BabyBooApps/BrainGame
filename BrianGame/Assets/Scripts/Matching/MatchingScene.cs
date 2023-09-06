using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingScene : MonoBehaviour
{
    public List<MatchingObject> Matching_Objects_List = new List<MatchingObject>();
    public List<Normal_Object> NormalObjectPlaceHolder_List = new List<Normal_Object>();
    public List<DarkObject> DarkObjectPlaceHolder_List = new List<DarkObject>();
    public List<MatchingObject> TempMatchObjectList = new List<MatchingObject>();

    // Start is called before the first frame update
    void Start()
    {
        LoadItems();
        SetCurrentMatchObjects(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadItems()
    {
        for(int i = 0; i < GameData.Instance.Matching_Items.Count; i++)
        {
            Matching_Objects_List.Add(GameData.Instance.Matching_Items[i]);
        }

        Matching_Objects_List =  Matching_Objects_List.Shuffle();
    }

    public void SetCurrentMatchObjects(int StartingCount)
    {
      
        for(int i = 0; i < 4; i++ )
        {
            MatchingObject obj = Matching_Objects_List[StartingCount + i];
            TempMatchObjectList.Add(obj);
        }

        Set_NormalMatchObject(TempMatchObjectList);
        Set_DarkMatchObjects(TempMatchObjectList);

        //TempMatchObjectList.Clear();
    }

    void Set_NormalMatchObject(List<MatchingObject> objList)
    {
        for(int i = 0; i < objList.Count; i++)
        {
            NormalObjectPlaceHolder_List[i].SetSprite(objList[i].NormalSprite);
            NormalObjectPlaceHolder_List[i].connector.setId(objList[i].Id);
        }
        
    }

    void Set_DarkMatchObjects(List<MatchingObject> objList)
    {
        objList =  objList.Shuffle();
        for (int i = 0; i < objList.Count; i++)
        {
            DarkObjectPlaceHolder_List[i].SetSprite(objList[i].DarkSprite);
            DarkObjectPlaceHolder_List[i].connector.setId(objList[i].Id);
        }

    }


}
