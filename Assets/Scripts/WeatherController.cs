using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    float duration = 1f;
    Color32 dayColor = new Color32(255, 199, 88,255);
    Color32 nightColor = new Color32(88,203,255,255);
    
    [SerializeField] GameObject uiController;
    [SerializeField] GameObject light;
    
    
    private UImanager uiManager;
    private Light sun;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = uiController.GetComponent<UImanager>();
        sun = light.GetComponent<Light>();
   
    }

    // Update is called once per frame
    void Update()
    {
         ChangeWeather();
        
    }
    private void ChangeWeather()
    {
        // float t = Mathf.PingPong(Time.time, duration) / duration;
        Color32 localCol = new Color32();
        if (uiManager.shouldPauseRainSFX)
        {
            sun.range = 16.3f;
            localCol = dayColor;
        }
        else if (!uiManager.shouldPauseRainSFX)
        {
            sun.range = 12f;
            localCol = nightColor;
        }
       
        sun.color = Color32.Lerp(sun.color, localCol,  0.02f);
    }
}
