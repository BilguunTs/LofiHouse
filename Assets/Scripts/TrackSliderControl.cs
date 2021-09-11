using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;
using FMODUnity;
public class TrackSliderControl : MonoBehaviour
{
	public Slider mainSlider;

    public EventInstance lofisongs;
	public EventInstance rainSFX;
	private bool shouldPauseSong;
	private bool shouldPauseRainSFX;
	public void Start()
	{
		mainSlider = GetComponent<Slider>();
		initTracks();		
		mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
	}
    public void Update()
    {
		handleEvents();
    }
	private void initTracks()
    {
		lofisongs = RuntimeManager.CreateInstance("event:/LofiSongs");
		rainSFX = RuntimeManager.CreateInstance("event:/RainSFX");

		lofisongs.start();
		rainSFX.start();
	}

	private void handleEvents()
    {
		lofisongs.setPaused(shouldPauseSong);
		rainSFX.setPaused(shouldPauseRainSFX);
	}
    
    public void ValueChangeCheck()
	{
	    lofisongs.setVolume(mainSlider.value);
	}
	public void PauseTrack()
    {
		shouldPauseSong = !shouldPauseSong;		
    }
	public void PauseRainSFX()
    {
		shouldPauseRainSFX = !shouldPauseRainSFX;
    }
	public bool isSongPlaying()
    {
		return !shouldPauseSong;
	}
	public bool isRainSFXPlaying()
    {
		return !shouldPauseRainSFX;

	}
}
