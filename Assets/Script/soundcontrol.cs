using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class soundcontrol : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] Toggle toggle;

    private float value;

    // Start is called before the first frame update
    void Start()
    {
       // AudioListener audioListener = FindObjectOfType<AudioListener>();
        value = volumeSlider.value;
        AudioListener.volume = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeVolume()
    {
        if (toggle.isOn)
        {
            value = 0;

        }
        else
        {
            value = volumeSlider.value;
        }

        AudioListener.volume = value;

    }

    public void mute()
    {

        if (toggle.isOn)
        {
            value = 0;

        }
        else {
            value = volumeSlider.value;
        }
        AudioListener.volume = value;
    }



}
