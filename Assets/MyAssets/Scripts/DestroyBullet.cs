using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour
{


    public GameObject explosion;
    public bool hasExplosion;

    //Default unity function called when gameObject dissapears from view of the camera
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //Default unity function for when a rigidbody collides with another object with a collider
    void OnCollisionEnter(Collision col)
    {
       if (hasExplosion)
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
            Destroy(exp, 2.0f);
        }
        Destroy(gameObject);        //Destroy our bullet
    }
}