/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Controls the ball and sets up the intial game behaviors. 
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    // [Header("General Settings")]
    public AudioClip projectSound;
    AudioSource audioSourse;
    public float score;
    public Text scoreText;
    public float speed;
    public float gameRestartDelay = 2f;

    // [Header("Ball Settings")]
    public Text ballTxt;
    public float initialForce;
    public bool isInPlay;
    public int numberOfBalls;
    private GameObject paddle;
    public Rigidbody rb;

    
    


    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        rb.GetComponent<Rigidbody>();

    }//end Awake()


        // Start is called before the first frame update
        void Start()
    {
        SetStartingPos(); //set the starting position

        AudioSource audioSoure = GetComponent<AudioSource>(); //GET ADUIO CONPOMENT 

        isInPlay = false;

        paddle.GetComponent<Paddle>();

    }//end Start()


    // Update is called once per frame
    void Update()
    {
        ballTxt.text = "Balls: " + numberOfBalls;
        scoreText.text = "Score: " + score;

        if (isInPlay == false) //ball move with paddle 
        {
            //Transform rb = paddle.gameObject.transform;
        }

        if (Input.GetButton("Jump"))
        {
            if (isInPlay == false)
            {
                isInPlay = true;
                move();
            }
        }

    }//end Update()


    private void LateUpdate()
    {
        if (isInPlay)
        {
           // speed = speed * speed.normalized;
        }

    }//end LateUpdate()

    private void move() //move method 
    {
        rb.AddForce(transform.up * initialForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // audioSourse.playOnShot(projectSound);
            if (gameObject.tag == "Brick")
            {
                score += 100;
                Destroy(gameObject);
            }
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "OutBounds")
        {
            numberOfBalls--;
        }

        if(numberOfBalls < 0)
        {
            Invoke("SetStartingPos", gameRestartDelay);
        }
    }

    void SetStartingPos()
    {
        isInPlay = false;//ball is not in play
        rb.velocity = Vector3.zero;//set velocity to keep ball stationary

        Vector3 pos = new Vector3();
        pos.x = paddle.transform.position.x; //x position of paddel
        pos.y = paddle.transform.position.y + paddle.transform.localScale.y; //Y position of paddle plus it's height

        transform.position = pos;//set starting position of the ball 
    }//end SetStartingPos()

    

   





}
