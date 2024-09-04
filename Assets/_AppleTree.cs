using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _AppleTree : MonoBehaviour
{
    [Header("Inscribed")] public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;


    // Start is called before the first frame update
    void Start()
    {
        // Start dropping apples
        Invoke(nameof(DropApple), 2f); // a
    }
    void DropApple() { // b
        GameObject apple = Instantiate<GameObject>(applePrefab); // c
        apple.transform.position = transform.position; // d
        Invoke (nameof(DropApple), appleDropDelay);

    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Changing direction
        if (pos.x < -leftAndRightEdge)
        {
            //a
            speed = Mathf.Abs(speed); // Move right // b
        }
        else if (pos.x > leftAndRightEdge)
        {
            // c
            speed = -Mathf.Abs(speed); // Move left // c
            // } else if (Random.value < changeDirChance) {
            //     speed *= -1; // Change direction
        }
    }

    void FixedUpdate()
    {
        //b
        //Random direction changes are not time-based due to FixedUpdate()
        if (Random.value < changeDirChance)
        {
            //b
            speed *= -1; // Change Direction 
        }
    }
}
