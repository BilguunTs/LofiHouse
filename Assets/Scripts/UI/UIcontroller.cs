using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class UIcontroller : MonoBehaviour
{
    public Button trackButton;
    public Button ambientButton;
    public Slider trackVolSlider;
    public Slider ambientVolSlider;


    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        trackButton = root.Q<Button>("song-btn");
        ambientButton = root.Q<Button>("ambient-btn");
        trackVolSlider = root.Q<Slider>("track-vol-ctrl");
        ambientVolSlider = root.Q<Slider>("ambient-ctrl");

        trackButton.clicked += trackButtonPressed;
        ambientButton.clicked += ambientButtonPressed;
    }

    void trackButtonPressed() {
        Debug.Log("Hey I am song button what do you want");
    }

    void ambientButtonPressed() { }


}
