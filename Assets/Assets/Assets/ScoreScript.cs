using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;
    public TMP_Text score;
    [SerializeField] private AudioSource breakSound;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
    }

    public void incrementScore() {
        scoreValue++;
        breakSound.Play();
    }

    public void resetScore(){
        scoreValue = 0;
    }
}
