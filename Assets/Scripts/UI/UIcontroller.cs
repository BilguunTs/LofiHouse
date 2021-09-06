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

    private EventInstance lofisongs;
    private PLAYBACK_STATE lofisongsSTATE;
    private bool shouldPauseSong;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        lofisongs = RuntimeManager.CreateInstance("event:/LofiSongs");
        lofisongs.start();
        
        trackButton = root.Q<Button>("track-btn");
        ambientButton = root.Q<Button>("ambient-btn");
        trackVolSlider = root.Q<Slider>("track-ctrl");
        ambientVolSlider = root.Q<Slider>("ambient-ctrl");

        trackButton.clicked += trackButtonPressed;
        ambientButton.clicked += ambientButtonPressed;
        trackVolSlider.RegisterCallback<MouseCaptureEvent>(evt =>
        {
            Debug.Log(trackVolSlider.value);
        });    
    }

    private void Update()
    {
        handleEventEmmiter();               
    }

    private void handleEventEmmiter()
    {
        if (shouldPauseSong)
        {
            lofisongs.setPaused(true);
        }
        else if (shouldPauseSong == false)
        {
            lofisongs.setPaused(false);
        }
    }

    void trackButtonPressed() {

        shouldPauseSong = !shouldPauseSong;        
    }

    void ambientButtonPressed() { }

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
