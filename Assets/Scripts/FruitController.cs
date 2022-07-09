using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class FruitController : MonoBehaviour
{
    public GameObject fruitCuttedPrefab;
    public Rigidbody[] fruitCuttedRbs;
    public GameObject tempFruit;
    public float explosionRadius=5f;
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateCutFruit();
        }
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
   

}
