using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowMany_Level : MonoBehaviour
{
    public Loading_Animation LoadingAnimation;
    public List<HowManyObj> HowMany_Level_Objects = new List<HowManyObj>();
    public List<Container> Container_List;
    public List<HowManyObj> Target_Id_List = new List<HowManyObj>();
    public List<int> numberList = new List<int>();
    public List<Answer_Draggable> Answer_Tiles = new List<Answer_Draggable>();
    public int Score = 0;
    public GameObject LogoObj;
    public GameObject Object_Container;
    public GameObject AnswerContainer;
    public Button NextBtn;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void StartGamePlay()
    {
        StartCoroutine(Start_Level());
    }

    public IEnumerator Start_Level()
    {
        yield return new WaitForSeconds(0);
        Initialize_Level();
        Object_Container.SetActive(false);
        AnswerContainer.SetActive(false);
        yield return LoadingAnimation.Animate_Loading();
        yield return new WaitForSeconds(0.5f);
        Object_Container.SetActive(true);
        AnswerContainer.SetActive(true);
        SetLevel();
    }

    public void set_Level_Objects()
    {
        HowMany_Level_Objects = GameData.Instance.HowMany_Items.Shuffle();
    }

    public void Initialize_Level()
    {
        
        AudioManager.Instance.PlayNextLevelClip();
        Score = 0;
        Target_Id_List.Clear();
        numberList.Clear();
        HowMany_Level_Objects.Clear();
        UI_Manager.Instance.HowMany_UI_Screen.Disable_Next_Btn();

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
        AudioManager.Instance.Play_Correct_Answer_Clip();
        AnimateLogo();
        if (Score >= Target_Id_List.Count)
        {
            AudioManager.Instance.PlayLevelCompleteClip();
            Debug.Log("Level Completed Successfully");
            StartCoroutine(ActivateNextQuestion());
            // Initialize_Level();
            // SetLevel();
        }
        else
        {
            Debug.Log("Level NotCompleted ");
        }
    }

    public IEnumerator ActivateNextQuestion()
    {
        
        yield return new WaitForSeconds(1.0f);
        UI_Manager.Instance.HowMany_UI_Screen.Enable_Next_Button();
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

    public void DisableLevel()
    {
        LoadingAnimation.ResetLoading();
        Initialize_Level();
        this.gameObject.SetActive(false);
    }



  }
