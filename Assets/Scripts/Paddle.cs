using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private Ball ball;
    public float minX, maxX;

    //Use this for initialization

    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        // print (ball);
    }

    // Update is called once per frame
    void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
        //Vector3 paddlesPoss = new Vector3(0.5f, this.transform.position.y, 0f);
        ////pozicija pokazivaca kordinate //relativna pozicija 
        ////print(Input.mousePosition.x/Screen.width *16);


        //float mousePosInBlocks=Input.mousePosition.x / Screen.width * 16;
        //paddlesPoss.x = Mathf.Clamp(mousePosInBlocks,0.5f,15.5f);


        //// print(mousePosInBlocks);

        //this.transform.position = paddlesPoss;

    }

    void AutoPlay()
    {
        Vector3 paddlesPoss = new Vector3(0.5f, this.transform.position.y, 0f);

        Vector3 ballPos = ball.transform.position;
        paddlesPoss.x = Mathf.Clamp(ballPos.x, minX, maxX);
        
        this.transform.position = paddlesPoss;
    }

    void MoveWithMouse()
    {
        Vector3 paddlesPoss = new Vector3(0.5f, this.transform.position.y, 0f);

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlesPoss.x = Mathf.Clamp(mousePosInBlocks, minX ,maxX);

        this.transform.position = paddlesPoss;
    }
}
