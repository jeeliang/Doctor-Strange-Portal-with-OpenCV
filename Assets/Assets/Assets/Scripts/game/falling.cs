using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour
{
    public float dropSpeed;
    private string gestureCode;
    private HandGestureTracking hand;
    public ScoreScript scoreScript;
    public lifeScript lifeScripts;
    // Start is called before the first frame update
    void Start()
    {
        hand = FindObjectOfType<HandGestureTracking>();
        scoreScript = FindObjectOfType<ScoreScript>();
        lifeScripts = FindObjectOfType<lifeScript>();
        dropSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        gestureCode = hand.getGestureCode();
        if(this != null){
            this.transform.position += -Vector3.up * Time.deltaTime * dropSpeed;
            if (this.transform.position.y < 0f) {
                Destroy(this.gameObject);
                lifeScripts.decreaseLives();
            }
        }
        if (gestureCode == "01000") {
            if(this.CompareTag("RedBall")){
                Destroy(this.gameObject);
                scoreScript.incrementScore();
            }
        }
        if (gestureCode == "01100") {
            if(this.CompareTag("BlueBall")){
                Destroy(this.gameObject);
                scoreScript.incrementScore();
            }
        }
        if (gestureCode == "01110") {
            if(this.CompareTag("YellowBall")){
                Destroy(this.gameObject);
                scoreScript.incrementScore();
            }
        }
    
        dropSpeed = dropSpeed + 0.1f;
    }

}
