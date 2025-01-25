using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSlider : MonoBehaviour
{
    public Slider bgmSlider;

    private void Start()
    {
        bgmSlider.value = SoundManager.Instance.GetBgmVolume();
    }

    // Update is called once per frame
    void Update()
    {
        SoundManager.Instance.SetBgmVolume(bgmSlider.value);
    }
}
