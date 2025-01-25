using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform settingRT;
    [SerializeField] private RectTransform makerRT;
    [SerializeField] private RectTransform gameChoiceRT;

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

    private bool settingImage = false;
    private bool makerImage = false;
    private bool gameChoiceImage = false;

    private void Start()
    {
        SoundManager.Instance.PlayBGMSound();
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (bgmBnt.image.sprite == bgmMuteSprite && bgmSlider.value != 0)
            {
                bgmBnt.image.sprite = bgmOnSprite;
            }
            if (sfxBnt.image.sprite == sfxMuteSprite && sfxSlider.value != 0)
            {
                sfxBnt.image.sprite = sfxOnSprite;
            }
        }
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
        else if(bgmBnt.image.sprite == bgmMuteSprite)
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

    public void LoadTitleScene()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        SceneManager.LoadScene("TitleScene");
    }

    public void LoadNomalGameScene()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        SceneManager.LoadScene("NomalGameScene");
    }

    public void LoadItemGameScene()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        SceneManager.LoadScene("ItemGameScene");
    }

    public void LoadNomalExplanationScene()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        SceneManager.LoadScene("NomalExplanationScene");
    }

    public void LoadItemExplanationScene()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        SceneManager.LoadScene("ItemExplanationScene");
    }

    public void GameExit()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        Application.Quit();
    }

    public void OpenSettingImage()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        settingImage = true;
        if (makerImage)
        {
            makerRT.DOAnchorPosY(-1200, 1).SetEase(Ease.OutQuint);
        }
        if (gameChoiceImage)
        {
            gameChoiceRT.DOAnchorPosY(-1200, 1).SetEase(Ease.OutQuint);
        }
        settingRT.DOAnchorPosY(0, 1).SetEase(Ease.OutQuint);
    }

    public void OpenGameChoiceImage()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        gameChoiceImage = true;
        if (makerImage)
        {
            makerRT.DOAnchorPosY(-1200, 1).SetEase(Ease.OutQuint);
        }
        if(settingImage)
        {
            settingRT.DOAnchorPosY(-1200, 1).SetEase(Ease.OutQuint);
        }
        gameChoiceRT.DOAnchorPosY(0, 1).SetEase(Ease.OutQuint);
    }

    public void CloseSettingImage()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        settingImage = false;
        settingRT.DOAnchorPosY(-1200, 1).SetEase(Ease.OutQuint);
    }

    public void CloseGameChoiceImage()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        gameChoiceImage = false;
        gameChoiceRT.DOAnchorPosY(-1200, 1).SetEase(Ease.OutQuint);
    }

    public void OpenMakerImage()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        makerImage = true;
        if (settingImage)
        {
            settingRT.DOAnchorPosY(-1200, 1).SetEase(Ease.OutQuint);
        }
        if (gameChoiceImage)
        {
            gameChoiceRT.DOAnchorPosY(-1200, 1).SetEase(Ease.OutQuint);
        }
        makerRT.DOAnchorPosY(0, 1).SetEase(Ease.OutQuint);
    }

    public void CloseMakerImage()
    {
        SoundManager.Instance.PlaySFXSound("ButtonPush");
        makerImage = false;
        makerRT.DOAnchorPosY(-1200, 1).SetEase(Ease.OutQuint);
    }
}
