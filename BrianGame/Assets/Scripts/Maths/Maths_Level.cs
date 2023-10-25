using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maths_Level : MonoBehaviour
{
    public Loading_Animation loadingAnimation;

    public Math_Type mathType = Math_Type.Addition;
    public Addition_Level addition_Level;
    public Substraction substraction_Level;
    public Multiplication Multiplication_Level;


    public QuestionArea Question;
    public List<int> Question_Elements = new List<int>();
    public int Answer;
    [SerializeField]
    public string MathType = "*";
    public AnswerContainer Answers_Container;
    public List<Math_Answer_Tile> Choice_Answer_Tiles = new List<Math_Answer_Tile>();
    public Result resultObj;

    public GameObject MathItem;
    public List<Math_Item> Items_List = new List<Math_Item>();
    public List<GameObject> SpawnedObjects = new List<GameObject>();

    float Max_Size = 0.5f;
    public GameObject GamePlayArea;

    private void Start()
    {
       // addition_Level = FindAnyObjectByType(typeof(Addition_Level)) as Addition_Level;
       // substraction_Level = FindAnyObjectByType(typeof(Substraction)) as Substraction;
       // Multiplication_Level = FindAnyObjectByType(typeof(Multiplication)) as Multiplication;

        resultObj.ResetScreen();

       

    }

    public void Get_Set_Answers_List(int ans)
    {
        Choice_Answer_Tiles.Clear();

        Choice_Answer_Tiles = Answers_Container.GetAnswerTiles();

        for (int i = 0; i < Choice_Answer_Tiles.Count; i++)
        {
            Choice_Answer_Tiles[i].ResetTile();
        }

        int[] distractors = GenerateDistractors(Answer);

        /*Choice_Answer_Tiles[0].SetText(Answer);
        Choice_Answer_Tiles[1].SetText(Answer + Utilities.GetRandomNumber(1, 5));
        Choice_Answer_Tiles[2].SetText(Answer + Utilities.GetRandomNumber(1, 5) + Utilities.GetRandomNumber(1, 3));*/

        // Set the text for the choice answer tiles
        Choice_Answer_Tiles[0].SetText(Answer); // Correct answer
        Choice_Answer_Tiles[1].SetText(distractors[0]); // Distractor 1
        Choice_Answer_Tiles[2].SetText(distractors[1]); // Distractor 2

    }

    // Function to generate distractors
    int[] GenerateDistractors(int answer)
    {
        int[] distractors = new int[2];

        // Generate the first distractor using addition
        distractors[0] = answer + Utilities.GetRandomNumber(1, 5);

        // Generate the second distractor using subtraction
        distractors[1] = answer - Utilities.GetRandomNumber(1, answer - 1);

        // Ensure that distractors are different from each other and not equal to the correct answer
        while (distractors[0] == distractors[1] || distractors[0] == answer || distractors[1] == answer)
        {
            distractors[0] = answer + Utilities.GetRandomNumber(1, 5);
            distractors[1] = answer - Utilities.GetRandomNumber(1, answer-1);
        }

        return distractors;
    }

    public void GenerateQuestion_Answer()
    {
        setSprites();

        List<int> QuestionElements = new List<int>();
        QuestionElements = GenerateandGet_QuestionList();

        if (MathType == "+")
        {
            Answer = addition_Level.Perform_Addition(QuestionElements[0], QuestionElements[1]);
        }
        else if (MathType == "-")
        {
            Answer = substraction_Level.Perform_Substraction(QuestionElements[0], QuestionElements[1]);
        }
        else if (MathType == "*")
        {
            Answer = Multiplication_Level.Perform_Multiplication(QuestionElements[0], QuestionElements[1]);
        }




        Debug.Log(QuestionElements[0] + " , " + QuestionElements[1]);
        Populate_Question_Elements(QuestionElements, Answer, MathType);

        Get_Set_Answers_List(Answer);

        resultObj.SetResult(QuestionElements[0], QuestionElements[1], MathType, Answer);

        PopulateObjects(QuestionElements);


    }

    public void PopulateObjects(List<int> questionElement)
    {
        Sprite sp = Items_List[0].Image;

        if (MathType == "+")
        {
            List<Vector3> PosList = addition_Level.Get_Obj_Positions(questionElement);

            for (int i = 0; i < PosList.Count; i++)
            {
                float objectSize = Max_Size / Mathf.Sqrt(questionElement[0]);
                GameObject currentGrid = Instantiate(MathItem, Vector3.zero, Quaternion.identity);
                // currentGrid.transform.parent = LeftGrid.transform;
                currentGrid.transform.localPosition = PosList[i];
                currentGrid.transform.localScale = new Vector3(objectSize, objectSize, 1);
                currentGrid.GetComponent<SpriteRenderer>().sprite = sp;
                SpawnedObjects.Add(currentGrid);
            }

            PosList.Clear();
        }
        else if (MathType == "-")
        {
            List<Vector3> PosList = substraction_Level.Get_Obj_Positions(questionElement);

            for (int i = 0; i < PosList.Count; i++)
            {
                float objectSize = Max_Size / Mathf.Sqrt(questionElement[0]);
                GameObject currentGrid = Instantiate(MathItem, Vector3.zero, Quaternion.identity);
                // currentGrid.transform.parent = LeftGrid.transform;
                currentGrid.transform.localPosition = PosList[i];
                currentGrid.transform.localScale = new Vector3(objectSize, objectSize, 1);
                currentGrid.GetComponent<SpriteRenderer>().sprite = sp;
                SpawnedObjects.Add(currentGrid);
            }

            for (int i = 0; i < SpawnedObjects.Count; i++)
            {
                if (i >= (SpawnedObjects.Count - questionElement[1]))
                {
                    Color col = SpawnedObjects[i].GetComponent<SpriteRenderer>().color;
                    col.a = 0.3f;
                    SpawnedObjects[i].GetComponent<SpriteRenderer>().color = col;

                    // SpawnedObjects[i].SetActive(false);
                }
            }
        }
        else if (MathType == "*")
        {
            List<Vector3> PosList = Multiplication_Level.Get_Obj_Positions(questionElement);

            for (int i = 0; i < PosList.Count; i++)
            {
                float objectSize = Max_Size / Mathf.Sqrt(questionElement[0] * 2);
                objectSize = Mathf.Clamp(objectSize, 0.05f, Max_Size);
                GameObject currentGrid = Instantiate(MathItem, Vector3.zero, Quaternion.identity);
                // currentGrid.transform.parent = LeftGrid.transform;
                currentGrid.transform.localPosition = PosList[i];
                currentGrid.transform.localScale = new Vector3(objectSize, objectSize, 1);
                currentGrid.GetComponent<SpriteRenderer>().sprite = sp;
              
                currentGrid.transform.localScale = Vector3.zero;
                iTween.ScaleTo(currentGrid, new Vector3(objectSize, objectSize, 1), 1.0f);
                iTween.PunchRotation(currentGrid, new Vector3(0, 0, 360), 1.0f);
                SpawnedObjects.Add(currentGrid);
            }
        }

    }
    public List<int> GenerateandGet_QuestionList()
    {
        Question_Elements.Clear();
        int num1 = Utilities.GetRandomNumber(1, 9);
        int num2 = 0;
       
        if (MathType == "+")
        {
            num2 = Utilities.GetRandomNumber(1, 9);
            Question_Elements.Add(num1);
            Question_Elements.Add(num2);
           
            //Question_Elements.Add(Utilities.GetRandomNumber(1, 9));
        }
        else if (MathType == "-")
        {
            num1 = Utilities.GetRandomNumber(4, 9);
            num2 = Utilities.GetRandomNumber(1, num1-1);
            Question_Elements.Add(num1);
            Question_Elements.Add(num2);
            
            //Question_Elements.Add(Utilities.GetRandomNumber(1, num1));
        }else if (MathType == "*")
        {
            num2 = Multiplication_Level.Multiplier;
            Question_Elements.Add(num2);
            Question_Elements.Add(num1);
           // Question_Elements.Add(Multiplication_Level.Multiplier);
        }

            return Question_Elements;
    }



    public void Populate_Question_Elements(List<int> question, int answer, string math_type)
    {
        Question.set_Question_Seg1(question[0].ToString());
        Question.set_Question_Seg2(question[1].ToString());

        Question.set_Answer(answer.ToString());

        Question.set_MathType(math_type);

        Question.TargetAnswer.SetId(answer);

    }

    public void OnAnswerValidated()
    {
        resultObj.gameObject.SetActive(true);
        StartCoroutine(AnimateResult());


    }

    public IEnumerator AnimateResult()
    {
        yield return resultObj.AnimateResult();
        clearSpawnedObjects();
        GenerateQuestion_Answer();
    }

    public void clearSpawnedObjects()
    {
        for (int i = 0; i < SpawnedObjects.Count; i++)
        {
            Destroy(SpawnedObjects[i].gameObject);
        }

        SpawnedObjects.Clear();
    }

    public void setSprites()
    {
        Items_List.Clear();
        Items_List = GameData.Instance.Math_Level_Items.Shuffle();
    }

    public void SetMathType(Math_Type type)
    {
        mathType = type;

        addition_Level.gameObject.SetActive(false);
        substraction_Level.gameObject.SetActive(false) ;
        Multiplication_Level.gameObject.SetActive(false);

        if (type == Math_Type.Addition)
        {
            addition_Level.gameObject.SetActive(true);
            MathType = "+";
        }
        else if (type == Math_Type.Subtraction)
        {
            substraction_Level.gameObject.SetActive(true);
            MathType = "-";
        }
        else if (type == Math_Type.Multiplication)
        {
            Multiplication_Level.gameObject.SetActive(true);
            MathType = "*";
        }
    }

    public IEnumerator Start_Math_Level(Math_Type type)
    {
        Answers_Container.gameObject.SetActive(false);
        Question.gameObject.SetActive(false);
        yield return loadingAnimation.Animate_Loading();
        yield return new WaitForSeconds(0.5f);
        Answers_Container.gameObject.SetActive(true);
        Question.gameObject.SetActive(true);
        SetMathType(type);
        GenerateQuestion_Answer();
    }

    public void Start_Level(Math_Type type)
    {
        StartCoroutine(Start_Math_Level(type));
    }

    public void DisableLevel()
    {
        loadingAnimation.ResetLoading();
        resultObj.ResetScreen();
        clearSpawnedObjects();
        Answers_Container.gameObject.SetActive(false);
        Question.gameObject.SetActive(false);

        this.gameObject.SetActive(false);
    }


}

public enum Math_Type
{
    none,
    Addition,
    Subtraction,
    Multiplication,
    Division
}
