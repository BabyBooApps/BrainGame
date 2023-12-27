using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_MenuScreen : UI_Screen
{
    public Image ToyImage;
    public Image TitleImage;
    public Vector3 ToyImageInitialPosition;
    public Vector3 ToyImageFinalPosition;
    public Vector3 TitleImageInitalPosition;
    public Vector3 TitleImageFinalPosition;
    public Vector3 ToyImageInitialSize;
    public Vector3 ToyImageFinalSize;
    public Vector3 TitleImageInitialSize;
    public Vector3 TitleImageFinalsize;

    public RectTransform Toy_Image_Target_Transform;
    public RectTransform Title_Image_Target_Transform;

    public List<MenuButton> Menu_Buttons_List = new List<MenuButton>();
        

    private void Awake()
    {
        ToyImageInitialPosition = ToyImage.transform.position;
        ToyImageInitialSize = ToyImage.transform.localScale;

        TitleImageInitalPosition = TitleImage.transform.position;
        TitleImageInitialSize = TitleImage.transform.localScale;
    }
    private void Start()
    {
        
    }

    public void InitializeMenuScreen()
    {
        StartCoroutine(AnimateToyandTitle());
    }
    IEnumerator AnimateToyandTitle()
    {
        DisableButtons();
        yield return new WaitForSeconds(0.5f);
        AnimateTitle();
        AnimateToy();
        yield return new WaitForSeconds(0.2f);
        AudioManager.Instance.Play_Move_Clip();
        yield return new WaitForSeconds(1.0f);
        yield return EnableButtons();
    }

    void AnimateTitle()
    {
        RectTransform rectTransform = TitleImage.GetComponent<RectTransform>();

        

        // Define the animation for position.
        LeanTween.move(rectTransform, Title_Image_Target_Transform.anchoredPosition, 1.0f)
            .setEase(LeanTweenType.easeInOutSine);

        // Define the animation for scale.
        LeanTween.scale(rectTransform, TitleImageFinalsize, 1.0f)
            .setEase(LeanTweenType.easeInOutSine);
    }

    void AnimateToy()
    {
        RectTransform rectTransform = ToyImage.GetComponent<RectTransform>();

        // Define the animation for position.
        LeanTween.move(rectTransform, Toy_Image_Target_Transform.anchoredPosition, 1.0f)
            .setEase(LeanTweenType.easeInOutSine);

        // Define the animation for scale.
        LeanTween.scale(rectTransform, ToyImageFinalSize, 1.0f)
            .setEase(LeanTweenType.easeInOutSine);
    }

    public void DisableButtons()
    {
        for(int i = 0; i < Menu_Buttons_List.Count; i++)
        {
            Menu_Buttons_List[i].gameObject.SetActive(false);
        }
    }

    public IEnumerator EnableButtons()
    {
       
        for (int i = 0; i < Menu_Buttons_List.Count; i++)
        {
            AudioManager.Instance.Play_CardFlip_Clip();
            Menu_Buttons_List[i].gameObject.SetActive(true);
            Menu_Buttons_List[i].EnableButton();
            yield return new WaitForSeconds(0.2f);
           
        }
    }

    public void OnScrambleWordsButtonClick()
    {
        AudioManager.Instance.Play_Btn_CLick();
        UI_Manager.Instance.InitializeScrambleWordsLevel();
    }

    public void OnMatchingSceneButtonClick()
    {
        AudioManager.Instance.Play_Btn_CLick();
        UI_Manager.Instance.InitializeMatchingLevel();
    }

    public void OnHowManySceneClick()
    {
        AudioManager.Instance.Play_Btn_CLick();
        UI_Manager.Instance.InitializeHowManyLevel();
    }

    public void OnPuzzleSceneClick()
    {
        AudioManager.Instance.Play_Btn_CLick();
        UI_Manager.Instance.ActivatePuzzleSelection();
    }

    public void OnMathSceneClick()
    {
        AudioManager.Instance.Play_Btn_CLick();
        UI_Manager.Instance.ActivateMathSelectionScreen();
    }

    public void ResetToy()
    {
        ToyImage.transform.position = ToyImageInitialPosition;
        ToyImage.transform.localScale = ToyImageInitialSize;

        TitleImage.transform.position = TitleImageInitalPosition;
        TitleImage.transform.localScale = TitleImageInitialSize;
    }

    public void OnHomeButtonClick()
    {
        AudioManager.Instance.Play_Btn_CLick();
        ResetToy();
        UI_Manager.Instance.BackToHome();
        this.gameObject.SetActive(false);
    }
}
