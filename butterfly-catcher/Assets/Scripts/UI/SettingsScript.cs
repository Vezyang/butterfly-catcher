using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Slider speedSlider;
    public Text speedSliderValue;

    public Image sound;
    public Image music;

    public Sprite soundSpriteOn;
    public Sprite soundSpriteOff;
    public Sprite musicSpriteOn;
    public Sprite musicSpriteOff;

    private void Awake()
    {
        speedSlider.value = Data.butterfliesSpeed;
        speedSliderValue.text = $"{speedSlider.value}";
        
        if (Data.soundStatus == false)
        {
            sound.sprite = soundSpriteOff;
        }

        if (Data.musicStatus == false)
        {
            music.sprite = musicSpriteOff;
        }
    }

    public void ChangeSpeed()
    {
        Data.butterfliesSpeed = speedSlider.value;
        speedSliderValue.text = $"{speedSlider.value}";
    }

    public void ChangeSound()
    {
        if (Data.soundStatus == false)
        {
            Data.soundStatus = true;
            sound.sprite = soundSpriteOn;
        }
        else
        {
            Data.soundStatus = false;
            sound.sprite = soundSpriteOff;
        }
    }

    public void ChangeMusic()
    {
        if (Data.musicStatus == false)
        {
            Data.musicStatus = true;
            music.sprite = musicSpriteOn;
        }
        else
        {
            Data.musicStatus = false;
            music.sprite = musicSpriteOff;
        }
    }
}
