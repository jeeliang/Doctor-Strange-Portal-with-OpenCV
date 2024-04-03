using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    private bool ac;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if(ac)
        {
            t+=Time.deltaTime;
            if(t>1)
            {
                ac = false;
                deactivate();
                t=0;
            }
        }
    }

    public void activate()
    {
        gameObject.SetActive(true);
        ac=true;
    }

    public void deactivate()
    {
        gameObject.SetActive(false);
    }
}
