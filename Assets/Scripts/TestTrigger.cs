using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
    }
}
