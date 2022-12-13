using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public string morradi;
    public Text txt;

    public int garbage = 10;
    private void Start()
    {
        txt.text = morradi;
    }//ass fikser senere
}
