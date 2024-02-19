using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using Random = System.Random;
public class gameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] baloons;
    public Timer timer;
    Random rand = new Random();
    public bool gameEnd= false;
    public Scores score;
    
  
    void Start()
    {
        score.currscore = 0;
        InvokeRepeating("createBaloon",1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd){
            CancelInvoke("createBaloon");
            Debug.Log("Final score");
            Debug.Log(score.currscore);
            gameEnd = false;
        }
        
    }

    void createBaloon(){
        int item = rand.Next(0,3);
        Instantiate(baloons[item]);
    }

    
}
