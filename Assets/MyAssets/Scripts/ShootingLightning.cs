using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLightning : MonoBehaviour
{
    public bool canShoot;
    public int gunDamage = 1;
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    Transform player;
    PlayerAttributes playerMana;
    public int manaCost;


    private Camera fpsCam;
    //private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private float nextFire;

    public float speed;         //Making things public makes them accessible in the editor
    public float bulletSpeed;

    public GameObject bullet;   //Assign the bullet prefab in the editor

    // Use this for initialization
    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMana = player.GetComponentInParent<PlayerAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        //my stuff
        if (Input.GetKeyDown(KeyCode.E) && canShoot && Time.time > nextFire && playerMana.enoughMana(manaCost))
        {   //if key is pressed down ONCE not is continuous press
            //Ray interactionRay = fpsCam.ScreenPointToRay(Input.mousePosition);
            nextFire = Time.time + fireRate;

            playerMana.UseMana(manaCost);

            GameObject bull = Instantiate(bullet, gunEnd.position, player.rotation) as GameObject;   //Create a bullet as gameobject to reference it
            Vector3 dir = fpsCam.transform.forward;
            bull.gameObject.GetComponent<BulletAttributes>().direction = dir;
            bull.GetComponent<Rigidbody>().velocity = new Vector3(dir.x * bulletSpeed, dir.y * bulletSpeed, dir.z * bulletSpeed);
        }
    }
}
