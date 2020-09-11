using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //Variables
    public float speed = .01f;
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            transform.position += moveDirection * speed * Time.deltaTime;
    }
}
