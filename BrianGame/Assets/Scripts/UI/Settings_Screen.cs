using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings_Screen : MonoBehaviour
{
    public Button BG_Music_On_Btn;
    public Button BG_Music_Off_Btn;

    public Button SoundEffects_On_Btn;
    public Button SoundEffects_Off_Btn;
    // Start is called before the first frame update
    void Start()
    {
        Set_Volume_Buttons();
    }

   

    public void Set_Volume_Buttons()
    {

        if (PlayerPrefs.GetInt("BgSoundsON") == 1)
        {
            BG_Music_Off_Btn.gameObject.SetActive(true);
            BG_Music_On_Btn.gameObject.SetActive(false);
        }
        else
        {
            BG_Music_Off_Btn.gameObject.SetActive(false);
            BG_Music_On_Btn.gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("SoundEffectsOn") == 1)
        {
            SoundEffects_Off_Btn.gameObject.SetActive(true);
            SoundEffects_On_Btn.gameObject.SetActive(false);
        }
        else
        {
            SoundEffects_Off_Btn.gameObject.SetActive(false);
            SoundEffects_On_Btn.gameObject.SetActive(true);
        }
    }

    public void On_BG_Music_Off_Btn_Click()
    {
        PlayerPrefs.SetInt("BgSoundsON", 0);
        Set_Volume_Buttons();
        AudioManager.Instance.SetAudioVolumes();

        AudioManager.Instance.Play_Btn_CLick();
    }
    public void On_BG_Music_On_Btn_Click()
    {
        PlayerPrefs.SetInt("BgSoundsON", 1);
        Set_Volume_Buttons();
        AudioManager.Instance.SetAudioVolumes();

        AudioManager.Instance.Play_Btn_CLick();
    }
    public void On_Sound_Effects_Off_Btn_Click()
    {
        PlayerPrefs.SetInt("SoundEffectsOn", 0);
        Set_Volume_Buttons();
        AudioManager.Instance.SetAudioVolumes();

        AudioManager.Instance.Play_Btn_CLick();
    }
    public void On_Sound_Effects_On_Btn_Click()
    {
        PlayerPrefs.SetInt("SoundEffectsOn", 1);
        Set_Volume_Buttons();
        AudioManager.Instance.SetAudioVolumes();

        AudioManager.Instance.Play_Btn_CLick();
    }

    public void OnClose_Button_Click()
    {
        this.gameObject.SetActive(false);

        AudioManager.Instance.Play_Btn_CLick();
    }
}
