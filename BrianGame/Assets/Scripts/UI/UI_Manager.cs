using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;
    public UI_ScrambleWords ScrambleWords_Screen;
    public UI_HomeScreen HomeScreen;
    public UI_MenuScreen MenuScreen;
    public UI_HowMany HowMany_UI_Screen;
    public UI_Puzzle Puzzle_UI_Screen;
    public UI_Math Math_UI_Screen;
    public UI_Matching Matching_UI_Screen;
    private void Awake()
    {
        // Ensure that there's only one instance of GameManager.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make the GameObject persistent across scenes.
        }
        else
        {
            // If another GameManager exists, destroy this one.
            Destroy(gameObject);
        }

        // Add any initialization code you need here.
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("InitializeScreens", 1.0f);
       // InitializeScreens();
    }

   void InitializeScreens()
    {
        ScrambleWords_Screen.SetScreen();
    }

    public void MoveToMenuScreen()
    {
        HomeScreen.gameObject.SetActive(false);
        MenuScreen.gameObject.SetActive(true);
        MenuScreen.InitializeMenuScreen();
    }

    //public void StartScreenTransition(UI_Screen currentScreen , UI_Screen NextScreen)
    //{

    //    NextScreen.gameObject.SetActive(true);
    //   // Define the initial positions of the screens.
    //    Vector2 initialCurrentScreenPosition = currentScreen.GetComponent<RectTransform>().anchoredPosition;
    //    Vector2 initialNextScreenPosition = NextScreen.GetComponent<RectTransform>().anchoredPosition;

    //    // Calculate the target positions for both screens.
    //    Vector2 targetCurrentScreenPosition = new Vector2(-Screen.width, 0);
    //    Vector2 targetNextScreenPosition = Vector2.zero;

    //    // Move both screens simultaneously using LeanTween.
    //    LeanTween.value(gameObject, 0f, 1f, 1.0f)
    //        .setOnUpdate((float progress) =>
    //        {
    //            // Update the positions of the screens based on the progress.
    //            currentScreen.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(initialCurrentScreenPosition, targetCurrentScreenPosition, progress);
    //            NextScreen.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(initialNextScreenPosition, targetNextScreenPosition, progress);
    //        })
    //        .setEase(LeanTweenType.easeInOutSine);
    //}

    public void InitializeScrambleWordsLevel()
    {
        GamePlayManager.Instance.InitializeScrambleWordsLevel();
        ScrambleWords_Screen.gameObject.SetActive(true);
        MenuScreen.HideScreen();

    }

    public void InitializeMatchingLevel()
    {
        GamePlayManager.Instance.InitializeMatchingLevel();
        Matching_UI_Screen.gameObject.SetActive(true);
        MenuScreen.HideScreen();
    }

    public void InitializeHowManyLevel()
    {
        GamePlayManager.Instance.InitializeHowManyLevel();
        MenuScreen.HideScreen();
        HowMany_UI_Screen.ShowScreen();
    }

    public void ActivatePuzzleSelection()
    {
        //GamePlayManager.Instance.InitializePuzzleLevel();
        Puzzle_UI_Screen.gameObject.SetActive(true);
        MenuScreen.HideScreen();
        Puzzle_UI_Screen.Activate_Puzzle_Selection_Screen();
    }

    public void InitializePuzzleLevel(int cardsCount , int severtity)
    {
        GamePlayManager.Instance.InitializePuzzleLevel(cardsCount ,severtity);
        Puzzle_UI_Screen.Activate_Puzzle_Game_Screen();
    }

    public void ActivateMathSelectionScreen()
    {
        Math_UI_Screen.gameObject.SetActive(true);
        Math_UI_Screen.ActivateMathSelectionScreen();
        MenuScreen.HideScreen();
    }

    public void Activate_Multiplcation_SelectionPopUp()
    {
        Math_UI_Screen.multiplication_PopUp.gameObject.SetActive(true);
    }

    public  void initializeMathLevel(Math_Type type)
    {
        GamePlayManager.Instance.InitializeMathLevel(type);
        Math_UI_Screen.DeactivateMathSelectionScreen();
        Math_UI_Screen.multiplication_PopUp.gameObject.SetActive(false);
        MenuScreen.HideScreen();
    }

    public void BackToHome()
    {
        HomeScreen.gameObject.SetActive(true);
    }

    public void BackToMenu()
    {
        MenuScreen.gameObject.SetActive(true);
    }
}
