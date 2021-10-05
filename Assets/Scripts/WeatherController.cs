using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    float duration = 1f;
    Color32 dayColor = new Color32(255, 199, 88,255);
    Color32 nightColor = new Color32(88,203,255,255);
    
    [SerializeField] GameObject SFXinstance;
    [SerializeField] GameObject light;

    

    private SFXplayer sfxPlayer;
    private Light sun;
    private float sunRange;
    private Color32 sunColor;
    
    void Start()
    {
        init();
    }

    void Update()
    {
         ChangeWeather();
        
    }
    private void init()
    {
        //uiManager = uiController.GetComponent<UImanager>();
        sfxPlayer = SFXinstance.GetComponent<SFXplayer>();
        sun = light.GetComponent<Light>();
        sunRange = sun.range;
        sunColor = sun.color;
    }
    private void ChangeWeather()
    {
        // float t = Mathf.PingPong(Time.time, duration) / duration;
        
        if (sfxPlayer.getPlayerState()==true)
        {
            sunRange = 16.3f;
            sunColor= dayColor;
        }
        else if (sfxPlayer.getPlayerState()==false)
        {
            sunRange = 10f;
            sunColor = nightColor;
        }
        sun.range = Mathf.Lerp(sun.range, sunRange, 0.02f);
        sun.color = Color32.Lerp(sun.color, sunColor,  0.02f);
    }
}
