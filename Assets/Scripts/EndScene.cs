using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayfabScript playfabScript;

    public Scores score;
    public void submitScore(){
        playfabScript.SendLeaderBoard(score.currscore);
    }
}
