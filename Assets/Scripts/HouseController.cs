using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    [SerializeField] GameObject deskLamp;
    [SerializeField] GameObject uiController;
    private UImanager uiManager;
    private Light lamplight;
    // Start is called before the first frame update
    void Start()
    {
      if(deskLamp!=null&&uiController!=null)
      {
            lamplight = deskLamp.GetComponent<Light>();
            uiManager = uiController.GetComponent<UImanager>();

      }
    }

    // Update is called once per frame
    void Update()
    {
        if (uiManager!=null)
        {
            lamplight.enabled = uiManager.shouldPauseRainSFX ?false : true;
        }
    }
}
