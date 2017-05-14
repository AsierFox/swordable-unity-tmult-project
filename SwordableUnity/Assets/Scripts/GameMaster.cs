using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public int score = 0;

    public Text scoreText;
    public Text inputinfoText;

    private void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
