using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour {

    [SerializeField] private float velocity = 3;
    [SerializeField] private float health = 1;

    private ObjectPool hitParticlesPool;
    private ObjectPool explosionPool;
    private float originalHealth;

    private void Awake()
    {
        originalHealth = health;
    }

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
            GameObject obj = explosionPool.GetObjectFromPool();
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            GameObject obj = hitParticlesPool.GetObjectFromPool();
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
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

    public void SetPools(ObjectPool hitparticle, ObjectPool explosion)
    {
        hitParticlesPool = hitparticle;
        explosionPool = explosion;
    }

    private void OnEnable()
    {
        health = originalHealth;
    }
}
