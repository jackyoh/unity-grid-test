using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class TilemapCreator : MonoBehaviour {
    private bool isInitializationComplete = false;
    public TileBase tileToPlace;
    public TextMeshProUGUI text_dialog;
    private Tilemap tilemap;

    void Start() {
        tilemap = GetComponent<Tilemap>();
        StartCoroutine(CheckInitialization());   
    }

    void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                Debug.Log(touch.position);
                text_dialog.text = "(" + touch.position + ")";
            }
        }
    }

    private IEnumerator CheckInitialization() {
        yield return new WaitForSeconds(0.5f);
        for (int x = -6; x <= 5; x++) {
            for (int y = -4; y <= 3; y++) {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePosition, tileToPlace);
            }
        }
    }
}
