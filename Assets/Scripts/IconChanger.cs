using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IconChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Sprite defaultImg;
    public Sprite activeImage;
    public bool AutoMode = true;

    private bool isClicked =false;
    private Button thisBtn;

    void Start()
    {
        if (AutoMode)
        {
        thisBtn = GetComponent<Button>();
        GetComponent<Image>().sprite = activeImage;
        thisBtn.onClick.AddListener(TaskOnClick);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        isClicked = !isClicked;
        thisBtn.GetComponent<Image>().sprite = !isClicked ? activeImage : defaultImg;
    }
}
