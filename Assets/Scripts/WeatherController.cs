using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    string WithoutRainColor = "#FFC758";
    string WithRainColor = "#58C1FF";

    float duration = 1f;
    Color dayColor = Color.yellow;
    Color nightColor = Color.blue;
    
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

             if (uiManager.shouldPauseRainSFX)
        {
            sun.color = Color.Lerp(dayColor, nightColor, duration*Time.deltaTime);
        }
        else if (!uiManager.shouldPauseRainSFX)
        {
            sun.color = Color.Lerp(nightColor, dayColor, duration * Time.deltaTime);
        }
    }
}
