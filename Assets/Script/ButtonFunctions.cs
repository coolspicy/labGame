using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;

    [SerializeField]  TMP_Dropdown dropdown1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("directions");
    }

    public void PlayGame()
    {
        string s = nameInput.text + " ";
        Debug.Log("your name is: " + s);
        //store in persistent data
        PersistentData.Instance.SetName(s);


        string selectedOption = dropdown1.options[dropdown1.value].text;

        if (selectedOption == "level1")
        {
            SceneManager.LoadScene("level1");
        }
        else if (selectedOption == "level2")
        {
            SceneManager.LoadScene("level2");
        }
        else {
            SceneManager.LoadScene("level3");
        }
        Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("menuScene");
        PersistentData.Instance.cleanData();
    }

    public void HighScore() 
    {
        SceneManager.LoadScene("scores");
    }

    public void Setting()
    {
        SceneManager.LoadScene("setting");
    }

   
}
