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

    public AudioClip BackgroundClip;
    public AudioClip ButtonClick;

    public AudioClip Move_Clip;
    public AudioClip SwishClip;
    public AudioClip Item_Flip;


    public List<AudioClip> AlphabetsAudioclips = new List<AudioClip>();
    public List<AudioClip> FailClips = new List<AudioClip>();
    public List<AudioClip> SuccessClips = new List<AudioClip>();
    public List<AudioClip> ScrambleWords_Obj_List = new List<AudioClip>();
    public List<AudioClip> NextLevelClips = new List<AudioClip>();
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
        PlayBackgroundMusic();
        SetBgVolume(backgroundMusicVolume);
    }

    public void SetBgVolume(float vol)
    {
        Background_AudioSource.volume = vol;
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



    public void PlayFailClip()
    {
        AudioClip clip = FailClips.GetRandomElement();
        PlayAudioClip(clip);
    }

    public void PlaySuccessClip()
    {
        AudioClip clip = SuccessClips.GetRandomElement();
        PlayAudioClip(clip);
    }

    public void PlayNextLevelClip()
    {
        AudioClip clip = NextLevelClips.GetRandomElement();
        PlayAudioClip(clip);
    }

    
}
