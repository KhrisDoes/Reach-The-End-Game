using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour {

    public  GameObject bulletPrefab;
    public  Rigidbody player;
    public static float bulletSpeed = 50f;
    public static float bulletOffset = 3f;
    public static float NumOfBullets = 0;
    public Vector3 ZOffset = new Vector3(0, 0, bulletOffset);
    public Vector3 YOffset = new Vector3(0, -bulletOffset * 0.2f, 0);


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0) && hasBullets())
        {
            FireForward();
        }
        /*
        if(Input.GetKeyDown(KeyCode.Space) && hasBullets()) && !PlayerMovement.isGrounded)
        {
            FireDownward();
        }
        */
	}

    public static void AddBullet()
    {
        NumOfBullets += 1;
    }

    public void FireForward()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, player.position + ZOffset, player.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        if(bullet != null)
        {
            Destroy(bullet, 2f);
        }
        NumOfBullets -= 1;
    }

    public void FireDownward()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, player.position + YOffset, player.rotation);
        bullet.GetComponent<Rigidbody>().velocity = - bullet.transform.up * bulletSpeed * 0.2f;
        if (bullet != null)
        {
            Destroy(bullet, 2f);
        }
        NumOfBullets -= 1;
    }

    bool hasBullets()
    {
        return NumOfBullets != 0;
    }

}
