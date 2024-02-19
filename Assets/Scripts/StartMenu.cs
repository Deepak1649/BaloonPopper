using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Scores score;
    
    public TMP_Text inputusername;
    public void onStart(){
        score.username = inputusername.text;
        SceneManager.LoadScene(1);
    }
}
