using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    public Slider musicSlider;
    public Text musicSliderValue;
    public Slider effectsSlider;
    public Text effectsSliderValue;

    public AudioMixerGroup audioMixer;

    public Image sound;
    public Image music;

    public Sprite soundSpriteOn;
    public Sprite soundSpriteOff;
    public Sprite musicSpriteOn;
    public Sprite musicSpriteOff;

    private void Awake()
    {
        if (Data.soundStatus == false)
        {
            sound.sprite = soundSpriteOff;
        }

        if (Data.musicStatus == false)
        {
            music.sprite = musicSpriteOff;
        }
        
        musicSlider.value = Data.musicVolume;
        effectsSlider.value = Data.effectsVolume;
    }

    public void ChangeMusicVolume()
    {
        audioMixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, musicSlider.value));
        Data.musicVolume = musicSlider.value;
    }

    public void ChangeEffectsVolume()
    {
        audioMixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, effectsSlider.value));
        Data.effectsVolume = effectsSlider.value;
    }

    public void ChangeEffects()
    {
        if (Data.soundStatus == false)
        {
            Data.soundStatus = true;
            sound.sprite = soundSpriteOn;
            effectsSlider.interactable = true;
            audioMixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, effectsSlider.value));
        }
        else
        {
            Data.soundStatus = false;
            sound.sprite = soundSpriteOff;
            effectsSlider.interactable = false;
            audioMixer.audioMixer.SetFloat("EffectsVolume", -80);
        }
    }

    public void ChangeMusic()
    {
        if (Data.musicStatus == false)
        {
            Data.musicStatus = true;
            music.sprite = musicSpriteOn;
            musicSlider.interactable = true;
            audioMixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, musicSlider.value));
        }
        else
        {
            Data.musicStatus = false;
            music.sprite = musicSpriteOff;
            musicSlider.interactable = false;
            audioMixer.audioMixer.SetFloat("MusicVolume", -80);
        }
    }
}
