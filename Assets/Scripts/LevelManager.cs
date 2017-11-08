//using UnityEngine;
//using System.Collections;
//using UnityEngine.SceneManagement;
//using System.Collections.Generic;



//public class LevelManager : MonoBehaviour {

//	public void LoadLevel(string name){
//        //Debug.Log ("New Level load: " + name);
//        //Application.LoadLevel (name);

//        Debug.Log("try " + name);   // ispis na konzolu da vidimo ako se funkcija poziva
//        Brick.breakableCount = 0;
//        Application.LoadLevel(name); // idemo na drugu scenu
//    }

//	public void QuitRequest(){
//		Debug.Log ("Quit requested");
//		Application.Quit ();
//	}

//    public void LoadNextLevel()
//    {
//        Application.LoadLevel(Application.loadedLevel+1);
//    }

//    public void BrickDestoyed()
//    {
//        //kada je zadnji unisten onda mi napravi 
//        if (Brick.brekableCount<=0)
//        {
//            LoadNextLevel();
//        }

//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public void LoadLevel(string name)
    {
        Debug.Log("try " + name);   // ispis na konzolu da vidimo ako se funkcija poziva
        Brick.breakableCount = 0;
        Application.LoadLevel(name); // idemo na drugu scenu

    }


    public void QuitRequest()
    {
        Debug.Log("try Quit");   // ispis na konzolu da vidimo ako se funkcija poziva
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        Application.LoadLevel(Application.loadedLevel + 1);
    }


    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}