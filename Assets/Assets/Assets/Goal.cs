using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    public ScoreScript scoreScript;
    public Transform ballGenerator;
    public GameObject Ball;
    public GoalPoint gpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            scoreScript.incrementScore();
            destroyBall(other.gameObject);
            gpoint.activate();
        }
    }

    public void destroyBall(GameObject obj) {
        Destroy(obj);
        Instantiate(Ball, ballGenerator.position, Quaternion.identity);
    }
}