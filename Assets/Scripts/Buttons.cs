using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

    public Sprite layer_off, layer_on;

    void OnMouseDown () {
        GetComponent <SpriteRenderer> ().sprite = layer_on;
    }

    void OnMouseUp () {
        GetComponent <SpriteRenderer> ().sprite = layer_off;
    }

    void OnMouseUpAsButton () {
        switch (gameObject.name) {
            case "btnPlay":
                SceneManager.LoadScene ("Play");
                break;
            case "btnBack":
                SceneManager.LoadScene ("Menu");
                break;   
        }
    }
}
