using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;
    public UI_ScrambleWords ScrambleWords_Screen;
    public UI_HomeScreen HomeScreen;
    public UI_MenuScreen MenuScreen;
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
}
