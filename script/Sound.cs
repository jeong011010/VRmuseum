using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Slider backVolume;

    private float backVol = 1f;
    // Start is called before the first frame update
    void Start()
    {
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        backVolume.value = backVol;
        AudioListener.volume = backVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }
    public void SoundSlider()
    {
        AudioListener.volume = backVolume.value;

        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
    }
}
