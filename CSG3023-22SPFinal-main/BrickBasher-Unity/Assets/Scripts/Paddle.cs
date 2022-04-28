/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Paddle controler on Horizontal Axis
****/

/*** Using Namespaces ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //public Rigidbody rb;
    public float speed = 10f; //speed of paddle
    private Vector2 moveDirection = Vector2.zero;

    void Start()
    {
        //rb.velocity = new Vector2(0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        transform.position = pos;

    }//end Update()
}
