using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }

            return instance;
        }
    } // Sound를 관리해주는 스크립트는 하나만 존재해야하고 instance프로퍼티로 언제 어디에서나 불러오기위해 싱글톤 사용

    [Header("배경음악을 실행할 AudioSource와 효과음을 실행할 AudioSource를 SoundManager의 자식 오브젝트로 설정")]

    private AudioSource bgmPlayer;
    private AudioSource sfxPlayer;

    [SerializeField]
    private AudioClip mainSceneBgmAudioClip; //메인화면에서 사용할 BGM
    [SerializeField]
    private AudioClip gameSceneBgmAudioClip; //게임씬에서 사용할 BGM

    [SerializeField]
    private AudioClip[] sfxAudioClips; //효과음들 지정

    Dictionary<string, AudioClip> audioClipsDic = new Dictionary<string, AudioClip>(); //효과음 딕셔너리
    // AudioClip을 Key,Value 형태로 관리하기 위해 딕셔너리 사용

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject); //여러 씬에서 사용할 것.

        bgmPlayer = transform.GetChild(0).GetComponent<AudioSource>();
        sfxPlayer = transform.GetChild(1).GetComponent<AudioSource>();

        foreach (AudioClip audioclip in sfxAudioClips)
        {
            audioClipsDic.Add(audioclip.name, audioclip);
        }

        Screen.SetResolution(1920, 1080, true);
    }

    // 효과 사운드 재생 : 이름을 필수 매개변수, 볼륨을 선택적 매개변수로 지정
    public void PlaySFXSound(string name)
    {
        if (audioClipsDic.ContainsKey(name) == false)
        {
            Debug.Log(name + " is not Contained audioClipsDic");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[name]);
    }

    //BGM 사운드 재생 : 볼륨을 선택적 매개변수로 지정
    public void PlayBGMSound()
    {
        bgmPlayer.loop = true; //BGM 사운드이므로 루프설정

        //메인씬에서의 브금 재생
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            bgmPlayer.clip = mainSceneBgmAudioClip;
            bgmPlayer.Play();
        }
        //게임씬에서의 브금 재생
        else if (SceneManager.GetActiveScene().name == "NomalGameScene")
        {
            bgmPlayer.clip = gameSceneBgmAudioClip;
            bgmPlayer.Play();
        }
        else if (SceneManager.GetActiveScene().name == "ItemGameScene")
        {
            bgmPlayer.clip = gameSceneBgmAudioClip;
            bgmPlayer.Play();
        }
        //현재 씬에 맞는 BGM 재생
    }

    public void SetBgmVolume(float volume)
    {
        bgmPlayer.volume = volume;
    }

    public float GetBgmVolume()
    {
        return bgmPlayer.volume;
    }

    public void SetSfxVolume(float volume)
    {
        sfxPlayer.volume = volume;
    }

    public float GetSfxVolume()
    {
        return sfxPlayer.volume;
    }
}
