using UnityEngine;

public class Parallax : MonoBehaviour {

    [SerializeField] private float parallaxSpeed;
    private float spriteHeight;
    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        startPosition = transform.position;

        Debug.Log(spriteHeight);
        Debug.Log(startPosition);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.down * parallaxSpeed * Time.deltaTime);

        // Child completely in Scene -> Move parent back at start -> looping continues
        if (transform.position.y < startPosition.y - spriteHeight) {
            transform.position = startPosition;
        }
    }
}
