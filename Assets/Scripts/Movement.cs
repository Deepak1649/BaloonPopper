using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = System.Random;


public class Movement : MonoBehaviour
{

    // Start is called before the first frame update
    
    public Scores playerscore;
    public int point;
    public int speed;
    void Start()
    {
        
        var rand = new Random();
        float x_axis = rand.Next(-9,9);
        this.transform.position = new Vector3(x_axis,-7);
        string color = gameObject.tag;
        if(color == "Green"){
            point = 1;
        }
        else if (color == "Yellow"){
            point = 2;
        }
        else{point = 3;}
   
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.up * 0.02f;
    }
    private void OnMouseDown()
    {
        playerscore.currscore += point;
        Debug.Log(playerscore.currscore);
        Destroy(gameObject);
    }
}
