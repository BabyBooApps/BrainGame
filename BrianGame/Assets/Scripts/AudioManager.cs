using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource[] Audiosources;
    public AudioSource Background_AudioSource;
    public AudioSource SoundClip_AudioSource;

    public float backgroundMusicVolume;
    public float SoundEffectsVolume;

    public AudioClip BackgroundClip;
    public AudioClip ButtonClick;

    public AudioClip Move_Clip;
    public AudioClip SwishClip;
    public AudioClip Item_Flip;


    public List<AudioClip> AlphabetsAudioclips = new List<AudioClip>();
    public List<AudioClip> FailClips = new List<AudioClip>();
    public List<AudioClip> SuccessClips = new List<AudioClip>();
    public List<AudioClip> Level_Complete_Clips = new List<AudioClip>();
    public List<AudioClip> ScrambleWords_Obj_List = new List<AudioClip>();
    public List<AudioClip> NextLevelClips = new List<AudioClip>();

    public AudioClip Addition_Clip;
    public AudioClip Substraction_Clip;
    public AudioClip Multiplication_Clip;

    public AudioClip CheeringClip;

    public List<AudioClip> Num_Clip = new List<AudioClip>();
    public List<AudioClip> GameAudioClips = new List<AudioClip>();

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      
        GetandSetAudioSources();
        SetAudioVolumes();
        PlayBackgroundMusic();
        
    }

    public void SetAudioVolumes()
    {

        // Check if the key has been set
        if (PlayerPrefs.HasKey("BgSoundsON"))
        {
            if (PlayerPrefs.GetInt("BgSoundsON") == 1)
            {
                SetBgVolume(backgroundMusicVolume);
            }
            else
            {
                SetBgVolume(0);
            }
        }
        else
        {
            UI_Manager.Instance.settings_Screen.On_BG_Music_On_Btn_Click();
        }


        if (PlayerPrefs.HasKey("SoundEffectsOn"))
        {
            if (PlayerPrefs.GetInt("SoundEffectsOn") == 1)
            {
                SetSoundEffectsVolume(SoundEffectsVolume);
            }
            else
            {
                SetSoundEffectsVolume(0);
            }
        }else
        {
            UI_Manager.Instance.settings_Screen.On_Sound_Effects_On_Btn_Click();
        }
            
    }

    public void SetBgVolume(float vol)
    {
        Background_AudioSource.volume = vol;
    }

    public void SetSoundEffectsVolume(float vol)
    {
        SoundClip_AudioSource.volume = vol;
    }

    public void GetandSetAudioSources()
    {
        Audiosources = Camera.main.GetComponents<AudioSource>() as AudioSource[];

        Background_AudioSource = Audiosources[0];
        SoundClip_AudioSource = Audiosources[1];
    }

    public void PlayBackgroundMusic()
    {
        Background_AudioSource.Stop();
        Background_AudioSource.clip = BackgroundClip;
        Background_AudioSource.loop = true;
        Background_AudioSource.Play();
    }

    public void PlayAudioClip(AudioClip clip)
    {
        SoundClip_AudioSource.Stop();
        SoundClip_AudioSource.clip = clip;
        SoundClip_AudioSource.loop = false;
        SoundClip_AudioSource.Play();
    }

    public void Play_Btn_CLick()
    {
        PlayAudioClip(ButtonClick);
    }

    public void Play_Move_Clip()
    {
        PlayAudioClip(Move_Clip);
    }

    public void Play_CardFlip_Clip()
    {
        PlayAudioClip(SwishClip);
    }

    public void Play_ItemFlipClip()
    {
        PlayAudioClip(Item_Flip);
    }

    public void Play_Alphabet_Audio_Clip(string name)
    {
        AudioClip clip = null;

        for(int i = 0; i < AlphabetsAudioclips.Count; i++)
        {
            if(AlphabetsAudioclips[i].name == name)
            {
                clip = AlphabetsAudioclips[i];
            }
        }

        PlayAudioClip(clip);
    }

    public void Play_ScrambleWord_Item_Clip(string name)
    {
        AudioClip clip = null;

        for (int i = 0; i < ScrambleWords_Obj_List.Count; i++)
        {
            if (ScrambleWords_Obj_List[i].name.ToLower() == name.ToLower())
            {
                clip = ScrambleWords_Obj_List[i];
            }
        }

        PlayAudioClip(clip);
    }


   public void Play_Cheering_Clip()
    {
        PlayAudioClip(CheeringClip);
    }

    public void PlayFailClip()
    {
        AudioClip clip = FailClips.GetRandomElement();
        PlayAudioClip(clip);
    }

    public void PlayLevelCompleteClip()
    {
        AudioClip clip = Level_Complete_Clips.GetRandomElement();
        PlayAudioClip(clip);
    }

    public void Play_Correct_Answer_Clip()
    {
        AudioClip clip = SuccessClips.GetRandomElement();
        PlayAudioClip(clip);
    }

    public void PlayNextLevelClip()
    {
        AudioClip clip = NextLevelClips.GetRandomElement();
        PlayAudioClip(clip);
    }

    public void Play_Addition_Clip()
    {
        PlayAudioClip(Addition_Clip);
    }

    public void Play_Substraction_Clip()
    {
        PlayAudioClip(Substraction_Clip);
    }

    public void Play_multipplication_clip()
    {
        PlayAudioClip(Multiplication_Clip);
    }

    public void Play_Num_Clip(int num)
    {
        AudioClip clip = null;

        for(int i = 0;  i < Num_Clip.Count; i++)
        {
            if(num.ToString() == Num_Clip[i].name)
            {
                clip = Num_Clip[i];
            }
        }

        PlayAudioClip(clip);
    }

    public void Play_Game_AudioClip(string id)
    {
        for(int i = 0; i < GameAudioClips.Count; i++)
        {
            if(GameAudioClips[i].name.ToUpper() == id.ToUpper())
            {
                PlayAudioClip(GameAudioClips[i]);
            }
        }
    }

    
}
