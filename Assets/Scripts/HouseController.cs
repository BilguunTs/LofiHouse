using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    [SerializeField] GameObject deskLamp;
    [SerializeField] GameObject SFXinstance;
    private SFXplayer sfxPlayer;
    private Light lamplight;
    // Start is called before the first frame update
    void Start()
    {
      if(deskLamp!=null&&SFXinstance!=null)
      {
            lamplight = deskLamp.GetComponent<Light>();
            sfxPlayer= SFXinstance.GetComponent<SFXplayer>();

      }
    }

    // Update is called once per frame
    void Update()
    {
        if (sfxPlayer!=null)
        {
            lamplight.enabled = sfxPlayer.getPlayerState()?false : true;
        }
    }
}
