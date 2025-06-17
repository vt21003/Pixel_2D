using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float distance = 5f;
    private Vector3 startPos;
    private bool moveright = true;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float left = startPos.x - distance;
        float right = startPos.x + distance;
        if (moveright)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= right)
            {
                moveright = false;
                flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= left)
            {
                moveright = true;
                flip();
            }
        }
    }
    void flip()
    {
        Vector3 scaler =transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
