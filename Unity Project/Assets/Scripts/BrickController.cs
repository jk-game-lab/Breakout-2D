using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

    public int maxHits = 1;

    private int timesHit;

    void Start () {
        timesHit = 0;
    }

    void Update () {

    }

    void OnCollisionEnter2D(Collision2D col){
        timesHit++;
        if (timesHit >= maxHits) {
            Destroy(this.gameObject);
        }
    }

}