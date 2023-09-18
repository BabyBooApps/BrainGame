using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Addition_Level : MonoBehaviour
{
    public QuestionArea Question;
    public List<int> Question_Elements = new List<int>();
    public int Answer;
    public string Math_Type = "+";
    public AnswerContainer Answers_Container;
    public List<Math_Answer_Tile> Choice_Answer_Tiles = new List<Math_Answer_Tile>();
    public Result resultObj;
    public DynamicGridManager LeftGrid;
    public DynamicGridManager Right_Grid;
    public GameObject MathItem;
    public List<Math_Item> Items_List = new List<Math_Item>();
    

    private void Start()
    {
        
        resultObj.ResetScreen();
    }

    public void Get_Set_Answers_List( int ans)
    {
        Choice_Answer_Tiles.Clear();

        Choice_Answer_Tiles = Answers_Container.GetAnswerTiles();

        for(int i = 0; i < Choice_Answer_Tiles.Count; i++)
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

        Answer = Perform_Addition(QuestionElements[0], QuestionElements[1]);

        Sprite sp = Items_List[0].Image;
        LeftGrid.SetGrid(QuestionElements[0],MathItem,sp);
        Right_Grid.SetGrid(QuestionElements[1], MathItem,sp);

        Populate_Question_Elements(QuestionElements, Answer, Math_Type);

        Get_Set_Answers_List(Answer);

        resultObj.SetResult(QuestionElements[0], QuestionElements[1], Math_Type, Answer);



    }
    public List<int> GenerateandGet_QuestionList()
    {
        Question_Elements.Clear();
        Question_Elements.Add(Utilities.GetRandomNumber(1, 9));
        Question_Elements.Add(Utilities.GetRandomNumber(1, 9));
        return Question_Elements;
    }

    public int Perform_Addition(int a , int b)
    {
        int c;
        c = a + b;

        return c;
    }

    public void Populate_Question_Elements(List<int> question , int answer , string math_type)
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
        LeftGrid.ResetGrid();
        Right_Grid.ResetGrid();
        GenerateQuestion_Answer();
    }

    public void setSprites()
    {
        Items_List.Clear();
        Items_List = GameData.Instance.Math_Level_Items.Shuffle();
    }

   
}
