using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class FruitController : MonoBehaviour
{
    public GameObject fruitCuttedPrefab;
    public float explosionRadius = 5f;
    private Rigidbody[] fruitCuttedRbs;
    private GameObject tempFruit;
    
    private void Start()
    {
        Destroy(gameObject, 5f);
    }    
    public void CreateCutFruit()
    {
        tempFruit = Instantiate(fruitCuttedPrefab, transform.position, transform.rotation);
        fruitCuttedRbs = tempFruit.GetComponentsInChildren<Rigidbody>();
        AddForceToRigidbodies();

        Destroy(tempFruit, 5f);
        Destroy(gameObject);
    }
    private void AddForceToRigidbodies()
    {
        foreach(Rigidbody fruitCuttedRb in fruitCuttedRbs)
        {
            fruitCuttedRb.transform.rotation = Random.rotation;
            fruitCuttedRb.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionRadius);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == GameTags.Player)
        {
            GameManager.Instance.IncreaseScore();
            CreateCutFruit();
        }
    }

}
