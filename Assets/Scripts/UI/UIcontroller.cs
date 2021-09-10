using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class UIcontroller : MonoBehaviour
{
    public Button trackButton;
    public Button ambientButton;
  
    public TrackSliderControl track;

    public void Start()
    {                  
        if(track == null)
        {
            track = FindObjectOfType<TrackSliderControl>();
        }
        initUI();
    }

    void Update()
    {
        handleEventEmmiter();               
    }
    private void initUI()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        trackButton = root.Q<Button>("track-btn");
        ambientButton = root.Q<Button>("ambient-btn");
      
        
        trackButton.clicked += trackButtonPressed;
        ambientButton.clicked += ambientButtonPressed;       

    }
   
   
    private void handleEventEmmiter()
    {
        handleButtonStyle();
    }

    private void handleButtonStyle()
    {        
        trackButton.style.backgroundColor = track.isSongPlaying() ? Color.gray: Color.clear;
        ambientButton.style.backgroundColor=track.isRainSFXPlaying()? Color.gray : Color.clear;
    }
    void trackButtonPressed() {
        track.PauseTrack();
    }

    void ambientButtonPressed() {
        track.PauseRainSFX();
    }
 

}
