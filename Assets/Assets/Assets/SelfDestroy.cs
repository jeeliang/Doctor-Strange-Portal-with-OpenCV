using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private Goal goalController;
    void Start() {
        goalController = FindObjectOfType<Goal>();
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -50f) {
            goalController.destroyBall(this.gameObject);
        }
    }
}
