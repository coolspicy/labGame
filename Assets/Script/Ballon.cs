using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    public float minX = 0f;
    public float maxX = 15.0f;
    public float minY = -3.0f;
    public float maxY = 7.0f;


    public float speed = 3.0f;
    private Vector3 targetPosition;

    [SerializeField] float currentSize = 1f;
    [SerializeField] float levelSize = 5f;
    [SerializeField] float maxSize = 6f;
    [SerializeField] float sizeIncreaseRate = 0.1f;
    [SerializeField] public int maxscore = 100;
    [SerializeField] public int score;

    [SerializeField] AudioSource audio1;
    [SerializeField] GameObject controller;
  

    // Start is called before the first frame update
    void Start()
    {
        // set a random pos
        SetRandomTargetPosition();

        if (audio1 == null)
        {
            audio1 = GetComponent<AudioSource>();
        }
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

    
    }

    // Update is called once per frame
    void Update()
    {
        score = maxscore;


        // use Lerp to move
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        // use Lerp to change size
        currentSize = Mathf.Lerp(currentSize, maxSize, sizeIncreaseRate * Time.deltaTime);

        // calc the point
        if (score >= maxscore)
        {
            float decayedScore = Mathf.Lerp(100f, 0f, currentSize / maxSize);
            score = Mathf.RoundToInt(decayedScore);
        }

        //reset level
        if (currentSize >= levelSize) {
            //Destroy(gameObject);
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);

            ResetLevel();
        }

        // upadte size
        transform.localScale = new Vector3(currentSize, currentSize, 1f);


        // if obj closed to target pos, update new pos
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
           // UpdateScore();
        }



    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // check hit the by bullet
        if (other.CompareTag("bullet"))
        {
            Destroy(gameObject);

            AudioSource.PlayClipAtPoint(audio1.clip, transform.position);
            //add points
            controller.GetComponent<Scorekeeper>().AddPoints(score);
        }
    }



    public void ResetLevel()
    {
        // reset and update new point gain
        currentSize = 1f;
        if (maxscore > 20)
        {
            //score -= 20;
            maxscore -= 10;
        }
    }



    void SetRandomTargetPosition()
    {
        //  get new random taeget pos
        targetPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
    }
   

}
