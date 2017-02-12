using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameObject particle;
    public AudioClip clip;

    [SerializeField]
    private float speed;

    private bool started;

    Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start() {
        started = false;
    }

    // Update is called once per frame
    void Update() {

        if (!started) {
            if (Input.GetMouseButtonDown(0)) {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.StartGame();
            }
        }

        if (!Physics.Raycast(transform.position, Vector2.down, 1f)) {

            rb.velocity = new Vector3(0, -25f, 0);
            GameManager.instance.EndGame();
        }

        if (Input.GetMouseButtonDown(0) && !GameManager.instance.gameOver) {
            SwitchDirection();
        }
    }

    void SwitchDirection() {
        if (rb.velocity.z > 0) {
            rb.velocity = new Vector3(speed, 0, 0);
        } else if (rb.velocity.x > 0) {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Diamond") {
            AudioSource.PlayClipAtPoint(clip, col.transform.position);
            GameObject part = Instantiate(particle, col.transform.position, transform.rotation);
            ScoreManager.instance.increaseScore(5);

            Destroy(col.gameObject);
            Destroy(part, 1f);
        }
    }
}
