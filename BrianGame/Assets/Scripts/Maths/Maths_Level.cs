using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maths_Level : MonoBehaviour
{
    public Math_Type mathType = Math_Type.Addition;
    public Addition_Level addition_Level;
    public Substraction substraction_Level;
    public Multiplication Multiplication_Level;


    public QuestionArea Question;
    public List<int> Question_Elements = new List<int>();
    public int Answer;
    public string MathType = "*";
    public AnswerContainer Answers_Container;
    public List<Math_Answer_Tile> Choice_Answer_Tiles = new List<Math_Answer_Tile>();
    public Result resultObj;

    public GameObject MathItem;
    public List<Math_Item> Items_List = new List<Math_Item>();
    public List<GameObject> SpawnedObjects = new List<GameObject>();

    float Max_Size = 0.6f;
    public GameObject GamePlayArea;

    private void Start()
    {
        addition_Level = FindAnyObjectByType(typeof(Addition_Level)) as Addition_Level;
        substraction_Level = FindAnyObjectByType(typeof(Substraction)) as Substraction;
        Multiplication_Level = FindAnyObjectByType(typeof(Multiplication)) as Multiplication;

        resultObj.ResetScreen();

        GenerateQuestion_Answer();

    }

    public void Get_Set_Answers_List(int ans)
    {
        Choice_Answer_Tiles.Clear();

        Choice_Answer_Tiles = Answers_Container.GetAnswerTiles();

        for (int i = 0; i < Choice_Answer_Tiles.Count; i++)
        {
            Choice_Answer_Tiles[i].ResetTile();
        }

        Choice_Answer_Tiles[0].SetText(Answer);
        Choice_Answer_Tiles[1].SetText(Answer + Utilities.GetRandomNumber(1, 5));
        Choice_Answer_Tiles[2].SetText(Answer + Utilities.GetRandomNumber(1, 5) + Utilities.GetRandomNumber(1, 3));


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
        Question_Elements.Add(num1);
        if (MathType == "+")
        {
            Question_Elements.Add(Utilities.GetRandomNumber(1, 9));
        }
        else if (MathType == "-")
        {
            Question_Elements.Add(Utilities.GetRandomNumber(1, num1));
        }else if (MathType == "*")
        {
            Question_Elements.Add(Utilities.GetRandomNumber(1, 9));
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


}

public enum Math_Type
{
    none,
    Addition,
    Subtraction,
    Multiplication,
    Division
}
