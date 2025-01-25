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
    } // Sound�� �������ִ� ��ũ��Ʈ�� �ϳ��� �����ؾ��ϰ� instance������Ƽ�� ���� ��𿡼��� �ҷ��������� �̱��� ���

    [Header("��������� ������ AudioSource�� ȿ������ ������ AudioSource�� SoundManager�� �ڽ� ������Ʈ�� ����")]

    private AudioSource bgmPlayer;
    private AudioSource sfxPlayer;

    [SerializeField]
    private AudioClip mainSceneBgmAudioClip; //����ȭ�鿡�� ����� BGM
    [SerializeField]
    private AudioClip gameSceneBgmAudioClip; //���Ӿ����� ����� BGM

    [SerializeField]
    private AudioClip[] sfxAudioClips; //ȿ������ ����

    Dictionary<string, AudioClip> audioClipsDic = new Dictionary<string, AudioClip>(); //ȿ���� ��ųʸ�
    // AudioClip�� Key,Value ���·� �����ϱ� ���� ��ųʸ� ���

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject); //���� ������ ����� ��.

        bgmPlayer = transform.GetChild(0).GetComponent<AudioSource>();
        sfxPlayer = transform.GetChild(1).GetComponent<AudioSource>();

        foreach (AudioClip audioclip in sfxAudioClips)
        {
            audioClipsDic.Add(audioclip.name, audioclip);
        }

        Screen.SetResolution(1920, 1080, true);
    }

    // ȿ�� ���� ��� : �̸��� �ʼ� �Ű�����, ������ ������ �Ű������� ����
    public void PlaySFXSound(string name)
    {
        if (audioClipsDic.ContainsKey(name) == false)
        {
            Debug.Log(name + " is not Contained audioClipsDic");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[name]);
    }

    //BGM ���� ��� : ������ ������ �Ű������� ����
    public void PlayBGMSound()
    {
        bgmPlayer.loop = true; //BGM �����̹Ƿ� ��������

        //���ξ������� ��� ���
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            bgmPlayer.clip = mainSceneBgmAudioClip;
            bgmPlayer.Play();
        }
        //���Ӿ������� ��� ���
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
        //���� ���� �´� BGM ���
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
