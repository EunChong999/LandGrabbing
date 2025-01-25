using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxSlider : MonoBehaviour
{
    public Slider sfxSlider;

    private void Start()
    {
        sfxSlider.value = SoundManager.Instance.GetSfxVolume();
    }

    // Update is called once per frame
    void Update()
    {
        SoundManager.Instance.SetSfxVolume(sfxSlider.value);
    }
}
