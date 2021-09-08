using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using FMODUnity;
using FMOD.Studio;
public class UIcontroller : MonoBehaviour
{
    public Button trackButton;
    public Button ambientButton;
    public Slider trackVolSlider;
    public Slider ambientVolSlider;
    public float trackVol = 80f;
    public float ambientVol = 70f;

    private EventInstance lofisongs;
    private EventInstance rainSFX;

    private PLAYBACK_STATE lofisongsSTATE;
    
    private bool shouldPauseSong;
    private bool shouldPauseRain;


    private void Start()
    {
        initSounds();
        initUI();
    }

    private void Update()
    {
        handleEventEmmiter();               
    }
    private void initUI()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        trackButton = root.Q<Button>("track-btn");
        ambientButton = root.Q<Button>("ambient-btn");
        trackVolSlider = root.Q<Slider>("track-ctrl");
        ambientVolSlider = root.Q<Slider>("ambient-ctrl");

        trackButton.clicked += trackButtonPressed;
        ambientButton.clicked += ambientButtonPressed;
        trackVolSlider.RegisterCallback<MouseCaptureEvent>(evt =>
        {          
            lofisongs.setVolume( trackVolSlider.value/100);
        });
        ambientVolSlider.RegisterCallback<MouseCaptureEvent>(evt => {
         
            rainSFX.setVolume(ambientVolSlider.value / 100);
        });

    }
    private void initSounds()
    {
        lofisongs = RuntimeManager.CreateInstance("event:/LofiSongs");
        rainSFX = RuntimeManager.CreateInstance("event:/RainSFX");

        rainSFX.start();
        lofisongs.start();
    }
   
    private void handleEventEmmiter()
    {      
        lofisongs.setPaused(shouldPauseSong);
        rainSFX.setPaused(shouldPauseRain);
    }

    void trackButtonPressed() {
        shouldPauseSong = !shouldPauseSong;        
    }

    void ambientButtonPressed() {
        shouldPauseRain = !shouldPauseRain;
    }

    void onAmbientVolSlide()
    {

    }
    void onTrackVolSlide()
    {

    }

    private bool IsPlaying(EventInstance instance)
    {
        
        instance.getPlaybackState(out lofisongsSTATE);
        return lofisongsSTATE != PLAYBACK_STATE.STOPPED;
    }

}
