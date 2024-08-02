using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour
{
    public Transform playerPos;
    public Transform offscreenPos;
    public float speed;

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, offscreenPos.position, speed * Time.deltaTime);
        }
    }

}
