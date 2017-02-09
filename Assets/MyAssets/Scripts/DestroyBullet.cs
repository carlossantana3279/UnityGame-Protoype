using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour
{

    //Default unity function called when gameObject dissapears from view of the camera
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //Default unity function for when a rigidbody collides with another object with a collider
    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);        //Destroy our bullet
    }
}