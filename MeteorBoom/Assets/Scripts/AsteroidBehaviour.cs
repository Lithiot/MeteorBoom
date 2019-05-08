using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour {

    [SerializeField] private float velocity = 3;
    [SerializeField] private float health = 1;

    void Update ()
    {
        transform.Translate(new Vector3(0, -velocity * Time.deltaTime, 0));
	}

    public void reduceHealth(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameManager.instance.AddMoney();
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("City"))
        {
            GameManager.instance.CityDamaged();
            gameObject.SetActive(false);
        }
    }
}
