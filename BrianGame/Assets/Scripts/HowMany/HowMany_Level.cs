using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowMany_Level : MonoBehaviour
{
    public List<HowManyObj> HowMany_Level_Objects = new List<HowManyObj>();
    public List<Container> Container_List;
    public List<HowManyObj> Target_Id_List = new List<HowManyObj>();
    public List<int> numberList = new List<int>();
    public List<Answer_Draggable> Answer_Tiles = new List<Answer_Draggable>();
    public int Score = 0;
    public GameObject LogoObj;

    public Button NextBtn;


    // Start is called before the first frame update
    void Start()
    {
        Initialize_Level();

        SetLevel();
    }

    public void set_Level_Objects()
    {
        HowMany_Level_Objects = GameData.Instance.HowMany_Items.Shuffle();
    }

    public void Initialize_Level()
    {
        Score = 0;
        Target_Id_List.Clear();
        numberList.Clear();
        HowMany_Level_Objects.Clear();
        NextBtn.gameObject.SetActive(false);

        for(int i = 0; i < Container_List.Count; i++)
        {
            Container_List[i].ResetContainer();
        }

        for(int i = 0; i < Answer_Tiles.Count; i++)
        {
            Answer_Tiles[i].ResetTile();
        }
    }

    public void SetLevel()
    {
        set_Level_Objects();
        set_Target_Id(Container_List.Count);
        AddRandomNumbers(1, 10);
        PopulateItems();
        SetAnswers();
    }

    public void set_Target_Id(int count)
    {
       for(int i = 0; i < count; i++)
        {
            Target_Id_List.Add(HowMany_Level_Objects[i]);
        }
    }

    public void PopulateItems()
    {
       // yield return new WaitForSeconds(0);
        for(int i = 0; i < numberList.Count; i++)
        {
            int num = numberList[i];
           Container_List[i].PopulateObject((num <= 5),Target_Id_List[i].image, num);
           Container_List[i].Answer.Set_Id(num);
            
        }
    } 

    public void SetAnswers()
    {
        List<int> TempAnsList = numberList.Shuffle();

        for(int i = 0; i < TempAnsList.Count; i++)
        {
            Answer_Tiles[i].SetId(TempAnsList[i]);
        }
    }

    private void AddRandomNumbers(int min, int max)
    {
        if (max - min + 1 < Container_List.Count)
        {
            Debug.LogWarning("The range is too small to generate 3 different random numbers.");
            return;
        }

        numberList.Clear(); // Clear the list to start fresh

        while (numberList.Count < Container_List.Count)
        {
            int randomNumber = Random.Range(min, max + 1);

            // Check if the generated number is not already in the list
            if (!numberList.Contains(randomNumber))
            {
                numberList.Add(randomNumber);
            }
        }
    }

    public void OnAnswerMatched()
    {
        Score++;
        AnimateLogo();
        if (Score >= Target_Id_List.Count)
        {
            Debug.Log("Level Completed Successfully");
            NextBtn.gameObject.SetActive(true);
            // Initialize_Level();
            // SetLevel();
        }
        else
        {
            Debug.Log("Level NotCompleted ");
        }
    }

    public void OnNextClicked()
    {
         Initialize_Level();
         SetLevel();
    }

    public void AnimateLogo()
    {
        iTween.PunchScale(LogoObj, new Vector3(1, 1, 1), 1.0f);
    }





  }
