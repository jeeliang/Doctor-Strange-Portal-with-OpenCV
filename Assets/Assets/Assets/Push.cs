using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public float forceMultiplier = 100;
    public float vectorUp = 10;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Kick"))
        {
            print("Finger Hit");
            Camera mainCam = Camera.main;
            Vector3 forwardDir = mainCam.transform.forward;
            Vector3 forwardUpDir = forwardDir + new Vector3(0f, vectorUp, 0f);
            this.GetComponent<Rigidbody>().AddForce(forwardUpDir * forceMultiplier);
            // Transform fingerTransform = other.gameObject.GetComponent<Transform>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
