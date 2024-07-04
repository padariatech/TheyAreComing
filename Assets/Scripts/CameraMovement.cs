using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Mover();
    }

    private void Mover(){
        Vector3 Horizontal = -transform.forward * Time.deltaTime * speed;
        transform.Translate(Horizontal);
    }

}