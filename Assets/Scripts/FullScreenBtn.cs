using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenBtn : MonoBehaviour
{
    private IconChanger Icons;
    private Image currentIcon;
    private Button thisBtn;
    private bool isFullScreen;
    // Start is called before the first frame update
    void Start()
    {
        currentIcon = GetComponent<Image>();
        Icons = GetComponent<IconChanger>();
        thisBtn = GetComponent<Button>();
        isFullScreen = Screen.fullScreen;
        thisBtn.onClick.AddListener(delegate { TaskOnClick(); });
        if (!isFullScreen)
        {
            Debug.Log("windowed mode");
            currentIcon.sprite = Icons.defaultImg;
        }else if (isFullScreen)
        {
            Debug.Log("full screen mode");
            currentIcon.sprite = Icons.activeImage;
        }
    }


    void TaskOnClick()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
       //Screen.fullScreenMode= FullScreenMode.ExclusiveFullScreen;
        currentIcon.sprite= !isFullScreen? Icons.defaultImg : Icons.activeImage;
    }
}
