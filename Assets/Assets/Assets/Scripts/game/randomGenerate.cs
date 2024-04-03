using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomGenerate : MonoBehaviour
{

    public Transform ballGenerator1;
    public Transform ballGenerator2;
    public Transform ballGenerator3;
    public GameObject ballRed;
    public GameObject ballBlue;
    public GameObject ballYellow;
    public float time;
    public lifeScript life;
    private int lives;
    [SerializeField] private AudioSource bgm;
    private bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        life = FindObjectOfType<lifeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        lives = life.returnLives();
        if(lives > 0 && life.gameStart) {
        if(playing == false){
            playing = true;
            bgm.Play();
        }
        time = time + Time.deltaTime;
        if(time > 1){
            time--;
            int x = Random.Range(1,9);
            if(x == 1){
                Instantiate(ballRed, ballGenerator1.position, Quaternion.identity);
            }
            else if (x == 2){
                Instantiate(ballRed, ballGenerator2.position, Quaternion.identity);
            }
            else if (x == 3){
                Instantiate(ballRed, ballGenerator3.position, Quaternion.identity);
            }
            else if (x == 4){
                Instantiate(ballBlue, ballGenerator1.position, Quaternion.identity);
            }
            else if (x == 5){
                Instantiate(ballBlue, ballGenerator2.position, Quaternion.identity);
            }
            else if (x == 6){
                Instantiate(ballBlue, ballGenerator3.position, Quaternion.identity);
            }
            else if (x == 7){
                Instantiate(ballYellow, ballGenerator1.position, Quaternion.identity);
            }
            else if (x == 8){
                Instantiate(ballYellow, ballGenerator2.position, Quaternion.identity);
            }
            else if (x == 9){
                Instantiate(ballYellow, ballGenerator3.position, Quaternion.identity);
            }

        }
        }
        else{
            playing = false;
            bgm.Stop();
        }
    }

}
