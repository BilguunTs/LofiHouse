using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    public static EventInstance lofisongs;
    public static EventInstance rainSFX;

    [SerializeField] public Slider songVol;
    [SerializeField] public Slider rainVol;
    [SerializeField] public Button songBtn;
    [SerializeField] public Button rainBtn;
    [SerializeField] public Sprite inActiveSongImage;
    [SerializeField] public Sprite inActiveRainImage;

    
    public bool shouldPauseSong = false;
    public bool shouldPauseRainSFX = false;


    private Sprite ActiveSongImage;
    private Sprite ActiveRainImage;

    // Start is called before the first frame update
    void Start()
    {
        initTracks();
        initUI();
    }

  
    private void initUI()
    {
        if (songVol == null || rainVol == null||songBtn==null||rainBtn==null)    
        {
            UnityEditor.EditorApplication.isPlaying = false;
            throw new System.Exception("References to ui controllers are required !!");
        }
       songBtn.onClick.AddListener(delegate { onSongBtnClick(); });
       rainBtn.onClick.AddListener(delegate { onRainBtnClick(); });
       songVol.onValueChanged.AddListener(delegate { SongValueChangeCheck(); });
       rainVol.onValueChanged.AddListener(delegate { RainValueChangeCheck(); });

        ActiveRainImage = rainBtn.GetComponent<Image>().sprite;
        ActiveSongImage = songBtn.GetComponent<Image>().sprite;
    }

    private void SongValueChangeCheck()
    {
        lofisongs.setVolume(songVol.value);
    }
    private void RainValueChangeCheck() {
        rainSFX.setVolume(rainVol.value);
    }
    private void onSongBtnClick()
    {
        lofisongs.setPaused(!shouldPauseSong);
        shouldPauseSong = !shouldPauseSong;
        songBtn.GetComponent<Image>().sprite = shouldPauseSong ? inActiveSongImage : ActiveSongImage;
        
    }
    private void onRainBtnClick()
    {
        rainSFX.setPaused(!shouldPauseRainSFX);
        shouldPauseRainSFX = !shouldPauseRainSFX;
        rainBtn.GetComponent<Image>().sprite = shouldPauseRainSFX?inActiveRainImage:ActiveRainImage;
    
    }
    private void initTracks()
    {
        lofisongs = RuntimeManager.CreateInstance("event:/LofiSongs");
        rainSFX = RuntimeManager.CreateInstance("event:/RainSFX");
        lofisongs.setVolume(songVol.value);
        rainSFX.setVolume(rainVol.value);
        lofisongs.start();
        rainSFX.start();
    }
}
