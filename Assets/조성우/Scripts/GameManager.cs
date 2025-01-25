using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int folkloreScore = 0;
    public int modernityScore = 0;

    [SerializeField] private GameObject resultObj;
    [SerializeField] private RectTransform victoryImage;
    [SerializeField] private GameObject drawObj;
    [SerializeField] private GameObject pauseMenuObj;
    [SerializeField] private GameObject settingMenuObj;

    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private Button bgmBnt;
    [SerializeField] private Button sfxBnt;

    [SerializeField] private Sprite bgmOnSprite;
    [SerializeField] private Sprite bgmMuteSprite;
    [SerializeField] private Sprite sfxOnSprite;
    [SerializeField] private Sprite sfxMuteSprite;

    private float bgmVolume;
    private float sfxVolume;

    public bool GameIsPaused = false;

    private bool settingMenuOpened = false;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SoundManager.Instance.PlayBGMSound();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingMenuOpened)
            {
                settingMenuOpened = false;
                pauseMenuObj.SetActive(true);
                settingMenuObj.SetActive(false);
            }
            else if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        pauseMenuObj.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuObj.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OpenSettingMenu()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        settingMenuOpened = true;
        pauseMenuObj.SetActive(false);
        settingMenuObj.SetActive(true);
    }

    public void CloseSettingMenu()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        settingMenuOpened = false;
        pauseMenuObj.SetActive(true);
        settingMenuObj.SetActive(false);
    }

    public void BgmMuteON()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        if (bgmBnt.image.sprite == bgmOnSprite)
        {
            bgmBnt.image.sprite = bgmMuteSprite;
            bgmVolume = bgmSlider.value;
            bgmSlider.value = 0;
        }
        else if (bgmBnt.image.sprite == bgmMuteSprite)
        {
            bgmBnt.image.sprite = bgmOnSprite;
            bgmSlider.value = bgmVolume;
        }
    }

    public void SfxMuteON()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        if (sfxBnt.image.sprite == sfxOnSprite)
        {
            sfxBnt.image.sprite = sfxMuteSprite;
            sfxVolume = sfxSlider.value;
            sfxSlider.value = 0;
        }
        else if (sfxBnt.image.sprite == sfxMuteSprite)
        {
            sfxBnt.image.sprite = sfxOnSprite;
            sfxSlider.value = sfxVolume;
        }
    }

    public void LoadResult()
    {
        if(folkloreScore > modernityScore)
        {
            victoryImage.anchoredPosition = new Vector2(-510, -245);
        }
        else if(folkloreScore < modernityScore)
        {
            victoryImage.anchoredPosition = new Vector2(510, -245);
        }
        else if(folkloreScore == modernityScore)
        {
            victoryImage.gameObject.SetActive(false);
            drawObj.SetActive(true);
        }

        SoundManager.Instance.PlaySFXSound("Win");

        resultObj.SetActive(true);
    }
    
    public void LoadNomalRestart()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene("NomalGameScene");
    }

    public void LoadItemRestart()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene("ItemGameScene");
    }

    public void LoadTitleScene()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene("TitleScene");
    }
}
