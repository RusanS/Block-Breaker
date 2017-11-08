using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    //private int maxHits;
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

    // Use this for initialization
    void Start()
    {
        isBreakable = (this.tag == "Breakable");
        //one koje se lome 
        if (isBreakable)
        {
            breakableCount++;
            /*print(breakableCount)*/            
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // timesHit++;
        // //SimulateWin();
        //int maxHits = hitSprites.Length + 1;

        // //unistavanje objekata lopticom po udarcima
        // if (timesHit>=maxHits)
        // {
        //     Destroy(gameObject);
        // }
        // else
        // {
        //     LoadSprites();
        // }
        AudioSource.PlayClipAtPoint(crack, transform.position,0.8f);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        //SimulateWin();
        int maxHits = hitSprites.Length + 1;

        //unistavanje objekata lopticom po udarcima
        if (timesHit >= maxHits)
        {
            breakableCount--;
            //Debug.Log(breakableCount);
            //print(breakableCount);
            levelManager.BrickDestroyed();
            //GameObject smokePuff=Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
            //smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }
    void PuffSmoke()
    {
        GameObject smokePuff = Object.Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
        ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = this.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]!= null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }
    }

    //Metodu je moguce maknuti kada ce se zaista moci pobjediti 
    void SimulateWin()
    {
        levelManager.LoadNextLevel();


    }
}

