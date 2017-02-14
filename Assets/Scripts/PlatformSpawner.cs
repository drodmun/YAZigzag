using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform;
    public GameObject diamond;

    Vector3 lastPos;
    float size;

	// Use this for initialization
	void Start () {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++) {
            SpawnPlatforms();
        }

        InvokeRepeating("SpawnPlatforms", 2f, .2f);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.gameOver) {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnPlatforms() {
        Vector3 pos = lastPos;

        if (Random.Range(0, 6) < 3) {
            pos.x += size;
        } else {
            pos.z += size;
        }

        SpawnPlantform(pos);
    }

    void SpawnPlantform(Vector3 pos) {
        lastPos = pos;
        GameObject newPlatform = Instantiate(platform, pos, Quaternion.identity);

        if (Random.Range(0, 4) == 0) {
            GameObject newDiamond = SpawnDiamond(pos);
            newDiamond.transform.parent = newPlatform.transform;
        }
    }

    GameObject SpawnDiamond(Vector3 pos) {
        pos.y += 1.5f;

        return Instantiate(diamond, pos, diamond.transform.rotation);
    }
}
