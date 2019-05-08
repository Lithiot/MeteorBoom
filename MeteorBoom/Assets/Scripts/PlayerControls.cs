using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Gun gunObject;
    private float rateOfFire;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && rateOfFire <= 0)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hitInfo;
                hitInfo = Physics2D.Raycast(Camera.main.transform.position, touchPos, 10);

                if (hitInfo)
                    if (hitInfo.transform.CompareTag("Asteroid"))
                        hitInfo.transform.GetComponent<AsteroidBehaviour>().reduceHealth(gunObject.damage);

                rateOfFire = gunObject.rateOfFire;
            }
        }
        rateOfFire -= Time.deltaTime;
    }

    public Gun GetGun()
    {
        return gunObject;
    }
}
