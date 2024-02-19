using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scores", menuName = "ScriptableObjects/Scores", order = 1)]
public class Scores: ScriptableObject
{
    public string username = "Random_User";
    public int currscore=0;
}
