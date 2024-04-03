using System;
using System.Collections.Generic;

// IMPORTANT: with_distance_version
[Serializable]
public class Hand
{
    public List<int> lmList;
    public List<int> center;

    public float distance;
    public List<int> fingersUp;

    public string type;

    public Hand(List<int> landmarks, List<int> cp, float dist, List<int> fingers, string handType) {
        this.lmList = landmarks;
        this.center = cp;
        this.distance = dist;
        this.fingersUp = fingers;
        this.type = handType;
    }
}

// IMPORTANT: no_distance_version
// [Serializable]
// public class Hand
// {
//     public List<int> lmList;
//     public List<int> bbox;

//     public List<int> cp;

//     public string type;

//     public Hand(List<int> landmarks, List<int> boundingBox, List<int> centralPoint, string handType) {
//         this.lmList = landmarks;
//         this.bbox = boundingBox;
//         this.cp = centralPoint;
//         this.type = handType;
//     }
// }

[Serializable]
public class Hands {
    public List<Hand> hands;
    public Hands(List<Hand> parameter){
        this.hands = parameter;
    }
}
