using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;


    //otkrivanje udarca(dodira_sudara)
    void OnTriggerEnter2D(Collider2D trigger)
    {
        //print("Trigerr");
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Loose Screen");

    }

    //okidac u Unity na BoxCollider 2D --> Is Trigger +
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collistion");
    }

}
