using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenBtn : MonoBehaviour
{
    private IconChanger Icons;
    private Image currentIcon;
    private Button thisBtn;
    // Start is called before the first frame update
    void Start()
    {
        currentIcon = GetComponent<Image>();
        Icons = GetComponent<IconChanger>();
        thisBtn.onClick.AddListener(TaskOnClick);
        if (currentIcon.sprite == Icons.defaultImg)
        {
            Debug.Log("windowed mode");
        }else if (currentIcon.sprite == Icons.activeImage)
        {
            Debug.Log("full screen mode");
        }
    }


    void TaskOnClick()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Screen.fullScreenMode= FullScreenMode.ExclusiveFullScreen;
        thisBtn.GetComponent<Image>().sprite = !Screen.fullScreen ? Icons.activeImage : Icons.defaultImg;
    }
}
