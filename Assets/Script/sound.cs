using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sound : MonoBehaviour
{


    [SerializeField] AudioSource audio1;

    // Start is called before the first frame update
    private static sound instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (audio1 == null)
        {
            audio1 = GetComponent<AudioSource>();
        }


    }

    // Update is called once per frame
    void Update()
    {
    
    }



}
