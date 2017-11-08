using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        //print(paddleToBallVector.y);
        //GetComponent<AudioSource>().Play();//pusti zvuk loptice odma na pocetku reprodukcije scene


    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            //zakljucamo loptu na podlogu
            this.transform.position = paddle.transform.position + paddleToBallVector;

            //kada se pritisne tipka na misu pokrece se
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked, launch ball");
                hasStarted = true;
                //zastarjela metoda
                //this.rigidbody2D.velocity = new Vector2(2f, 10f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
	}

    //kada udari loptica pusti zvuk
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f,0.2f), Random.Range(0f, 0.2f));
        //print(tweak);
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }

}
