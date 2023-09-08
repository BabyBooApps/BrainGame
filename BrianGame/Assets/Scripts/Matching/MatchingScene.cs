using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingScene : MonoBehaviour
{
    public List<MatchingObject> Matching_Objects_List = new List<MatchingObject>();
    public List<Normal_Object> NormalObjectPlaceHolder_List = new List<Normal_Object>();
    public List<DarkObject> DarkObjectPlaceHolder_List = new List<DarkObject>();
    public List<MatchingObject> TempMatchObjectList = new List<MatchingObject>();

    public int MatchCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        LoadItems();
       StartCoroutine( SetCurrentMatchObjects(0));
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

    public IEnumerator SetCurrentMatchObjects(int StartingCount)
    {
        for(int i = 0; i < NormalObjectPlaceHolder_List.Count; i++)
        {
            NormalObjectPlaceHolder_List[i].transform.localScale = Vector3.zero;
        }

        for (int i = 0; i < DarkObjectPlaceHolder_List.Count; i++)
        {
            DarkObjectPlaceHolder_List[i].transform.localScale = Vector3.zero;
        }

        for (int i = 0; i < 4; i++ )
        {
            MatchingObject obj = Matching_Objects_List[StartingCount + i];
            TempMatchObjectList.Add(obj);
        }

        yield return Set_NormalMatchObject(TempMatchObjectList);
        Set_DarkMatchObjects(TempMatchObjectList);

        TempMatchObjectList.Clear();
    }

    IEnumerator Set_NormalMatchObject(List<MatchingObject> objList)
    {
        for(int i = 0; i < objList.Count; i++)
        {
            NormalObjectPlaceHolder_List[i].transform.localScale = new Vector3(0.3f, 0.3f,1);
            NormalObjectPlaceHolder_List[i].SetSprite(objList[i].NormalSprite);
            iTween.PunchScale(NormalObjectPlaceHolder_List[i].gameObject, new Vector3(1.2f,1.2f,1), 0.9f);
            yield return new WaitForSeconds(0.3f);
            NormalObjectPlaceHolder_List[i].connector.setId(objList[i].Id);
        }
        
    }

    void Set_DarkMatchObjects(List<MatchingObject> objList)
    {
        objList =  objList.Shuffle();
        for (int i = 0; i < objList.Count; i++)
        {
            DarkObjectPlaceHolder_List[i].transform.localScale = new Vector3(0.3f, 0.3f, 1);
            DarkObjectPlaceHolder_List[i].SetSprite(objList[i].DarkSprite);
            DarkObjectPlaceHolder_List[i].connector.setId(objList[i].Id);
        }

    }

    public void OnSuccessfulConnection()
    {
        MatchCount++;
        if(MatchCount >= 4)
        {
            Debug.Log("Game Successful");
            ResetLevel();
            Matching_Objects_List = Matching_Objects_List.Shuffle();
            StartCoroutine(SetCurrentMatchObjects(0));
        }
        else
        {
            Debug.Log("Game Not Completed Yet");
        }
    }

    public void ResetLevel()
    {
        MatchCount = 0;
        for (int i = 0; i < NormalObjectPlaceHolder_List.Count; i++)
        {
            NormalObjectPlaceHolder_List[i].transform.localScale = Vector3.zero;
            NormalObjectPlaceHolder_List[i].connector.ResetConnector();
        }

        for (int i = 0; i < DarkObjectPlaceHolder_List.Count; i++)
        {
            DarkObjectPlaceHolder_List[i].transform.localScale = Vector3.zero;
            DarkObjectPlaceHolder_List[i].connector.ResetConnector();
        }
    }


}
