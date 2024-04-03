﻿using UnityEngine;

public class MainCamera : MonoBehaviour {

    public Portal[] portals;

    void Update () {
        portals = FindObjectsOfType<Portal>();
    }

    void OnPreCull () {

        for (int i = 0; i < portals.Length; i++) {
            portals[i].PrePortalRender ();
        }
        for (int i = 0; i < portals.Length; i++) {
            portals[i].Render ();
        }

        for (int i = 0; i < portals.Length; i++) {
            portals[i].PostPortalRender ();
        }

    }

}