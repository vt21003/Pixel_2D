using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform postA;
    [SerializeField] private Transform postB;
    [SerializeField] private float speed = 2f;

    private Vector3 target;
    private Vector3 lastPos;
    private Transform player;

    void Start()
    {
        target = postA.position;
        lastPos = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 oldPos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
        Vector3 delta = transform.position - oldPos;

        if (player != null)
            player.position += delta;

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == postA.position) ? postB.position : postA.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }
}

