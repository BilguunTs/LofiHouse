using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
public class SFXplayer : MonoBehaviour
{
    // Start is called before the first frame update
    [FMODUnity.EventRef]
    public string fmodPath;

    private bool shouldPlaySFX;
    private EventInstance instance;

    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodPath);
        shouldPlaySFX = ShufflePlaylist.IsPlaying(instance);
        instance.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseSFX()
    {
        shouldPlaySFX =!shouldPlaySFX;
        instance.setPaused(shouldPlaySFX);
    }

    public void setVolume(float vol)
    {
        instance.setVolume(vol);
    }
    public bool getPlayerState()
    {
        return shouldPlaySFX;
    }

}
