using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lifeScript : MonoBehaviour
{

    public static int lives = 3;
    public bool gameStart = false;
    [SerializeField] private AudioSource explodeSound;

    public int returnLives(){
        return lives;
    }

    public void decreaseLives() {
        if(lives > 0 && gameStart){
            lives--;
            explodeSound.Play();
        }
    }

    public void resetLives(){
        lives = 3;
        gameStart = true;
    }

}
