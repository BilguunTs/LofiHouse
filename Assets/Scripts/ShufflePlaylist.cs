using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using TMPro;
public class ShufflePlaylist : MonoBehaviour
{
    [SerializeField]
    public TMP_Text songTitle;
    [FMODUnity.EventRef]
    public string[] fmodPaths;


    private EventInstance instance;
    private bool shouldPause;
    
    private string artistName, songName;
    // Start is called before the first frame update
    void Start()
    {
        ShuffleMusic(fmodPaths);
        shouldPause = IsPlaying(instance);
    }
   
    void ShuffleMusic(string[] a)
    {
        for (int i = a.Length - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i);

            string temp = a[i];

            a[i] = a[rnd];
            a[rnd] = temp;
        }

        for (int i = 0; i < a.Length; i++)
        {
            Debug.Log(a[i]);
        }

        StartCoroutine(PlayMusic(a));
    }
    IEnumerator PlayMusic(string[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            instance = FMODUnity.RuntimeManager.CreateInstance(a[i]);

            if (PlaybackState(instance) != PLAYBACK_STATE.PLAYING)
            {
                EventDescription eD;
                instance.getDescription(out eD);

                int userPropertyCount;
                eD.getUserPropertyCount(out userPropertyCount);

                USER_PROPERTY[] userProperties = new USER_PROPERTY[userPropertyCount];

                for (int j = 0; j < userPropertyCount; j++)
                {
                    eD.getUserPropertyByIndex(j, out userProperties[j]);
                }

                artistName = userProperties[0].stringValue();
                songName = userProperties[1].stringValue();

                songTitle.text = artistName+" - "+songName;


                instance.start();
                instance.release();

                while (PlaybackState(instance) != PLAYBACK_STATE.STOPPED)
                {
                    yield return null;
                }

                instance.clearHandle();

                while (instance.isValid())
                {
                    yield return null;
                }
            }
        }
     
    }
  
    PLAYBACK_STATE PlaybackState(EventInstance instance)
    {
        PLAYBACK_STATE pS;
        instance.getPlaybackState(out pS);
        return pS;
    }
    public static bool IsPlaying(EventInstance instance)
    {
        PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        return state != PLAYBACK_STATE.STOPPED;
    }
    public void PauseSong()
    {
        shouldPause = !shouldPause;
        instance.setPaused(!shouldPause);       
    }
    public void setVolume(float vol)
    {
       instance.setVolume(vol);
    }

   
}
