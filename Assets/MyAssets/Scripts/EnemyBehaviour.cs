using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

    public int health;

    public bool isBoss;
    public string[] dialogue;
    private int level = 0;

    //Default unity function for when a rigidbody collides with another object with a collider
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.name == "Bullet(Clone)")
        {   //Check if collided object is a bullet

            int damage = col.gameObject.GetComponent <BulletAttributes> ().bulletDamage;
            float force = col.gameObject.GetComponent<BulletAttributes>().hitForce;
            Vector3 norm = col.gameObject.GetComponent<BulletAttributes>().direction;

            gameObject.GetComponent<Rigidbody>().AddForce(norm * force);
            Destroy(col.gameObject);        //Destroy our bullet

            health -= damage;
            if (health <= 0) {

                /*
                for (int i = 0; i < 3; i++)
                {   //create 3 debrie pieces
                    GameObject deb = Instantiate(debrie, transform.position, Quaternion.identity) as GameObject;    //Instantiate debrie at gameobject position
                    deb.GetComponent<Rigidbody>().velocity = Random.onUnitSphere * 10;                          //Apply random vector velocity
                    deb.GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * 10, ForceMode.Impulse);       //Apply random torque impulse force
                }
                */

                if (isBoss)
                {
                    DialogueManager.Instance.AddNewDialogue(dialogue, level);
                    GameObject e1 = GameObject.FindGameObjectWithTag("Finish");
                    GameObject e2 = GameObject.FindGameObjectWithTag("Respawn");
                    Destroy(e1);
                    Destroy(e2);
                }  
            
                Destroy(gameObject);        //Finally destroy the enemy spaceship
                return;
            }
        }

        if (col.transform.name == "Lightning(Clone)")
        {   //Check if collided object is a bullet

            int damage = col.gameObject.GetComponent<BulletAttributes>().bulletDamage;
            float force = col.gameObject.GetComponent<BulletAttributes>().hitForce;
            Vector3 norm = col.gameObject.GetComponent<BulletAttributes>().direction;

            gameObject.GetComponent<Rigidbody>().AddForce(norm * force);
            Destroy(col.gameObject);        //Destroy our bullet

            health -= damage;
            if (health <= 0)
            {

                /*
                for (int i = 0; i < 3; i++)
                {   //create 3 debrie pieces
                    GameObject deb = Instantiate(debrie, transform.position, Quaternion.identity) as GameObject;    //Instantiate debrie at gameobject position
                    deb.GetComponent<Rigidbody>().velocity = Random.onUnitSphere * 10;                          //Apply random vector velocity
                    deb.GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * 10, ForceMode.Impulse);       //Apply random torque impulse force
                }
                */
                if (isBoss)
                {
                    DialogueManager.Instance.AddNewDialogue(dialogue, level);
                    GameObject e1 = GameObject.FindGameObjectWithTag("Finish");
                    GameObject e2 = GameObject.FindGameObjectWithTag("Respawn");
                    Destroy(e1);
                    Destroy(e2);
                }
                Destroy(gameObject);        //Finally destroy the enemy spaceship
                return;
            }
        }


        if (col.transform.name == "PushAwayAttack(Clone)")
        {   //Check if collided object is a bullet

            int damage = col.gameObject.GetComponent<BulletAttributes>().bulletDamage;
            float force = col.gameObject.GetComponent<BulletAttributes>().hitForce;
            Vector3 norm = col.gameObject.GetComponent<BulletAttributes>().direction;

            gameObject.GetComponent<Rigidbody>().AddForce(norm * force);
            //Destroy(col.gameObject);        //Destroy our bullet

            health -= damage;
            if (health <= 0)
            {

                /*
                for (int i = 0; i < 3; i++)
                {   //create 3 debrie pieces
                    GameObject deb = Instantiate(debrie, transform.position, Quaternion.identity) as GameObject;    //Instantiate debrie at gameobject position
                    deb.GetComponent<Rigidbody>().velocity = Random.onUnitSphere * 10;                          //Apply random vector velocity
                    deb.GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * 10, ForceMode.Impulse);       //Apply random torque impulse force
                }
                */
                if (isBoss)
                {
                    DialogueManager.Instance.AddNewDialogue(dialogue, level);
                    GameObject e1 = GameObject.FindGameObjectWithTag("Finish");
                    GameObject e2 = GameObject.FindGameObjectWithTag("Respawn");
                    Destroy(e1);
                    Destroy(e2);
                }
                Destroy(gameObject);        //Finally destroy the enemy spaceship
                return;
            }
        }

    }
}
