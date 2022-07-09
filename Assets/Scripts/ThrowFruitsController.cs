using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFruitsController : MonoBehaviour
{
    public GameObject fruitThrowed;
    public float minWaitTime = .3f;
    public float maxWaitTime = 1f;
    public float minImpulseMultiplier = 12f;
    public float maxImpulseMultiplier = 17f;
    public Transform[] throwFruitOrigins;
    private Transform throwFruitOrigin;
    private GameObject fruit;
    private float impulseMultiplier;
    private void Start()
    {
        StartCoroutine(FruitThrower());
    }
    private IEnumerator FruitThrower()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            throwFruitOrigin = throwFruitOrigins[Random.Range(0, throwFruitOrigins.Length)];
            fruit = Instantiate(fruitThrowed, throwFruitOrigin.position, throwFruitOrigin.rotation);
            impulseMultiplier = Random.Range(minImpulseMultiplier, maxImpulseMultiplier);
            fruit.GetComponent<Rigidbody2D>().AddForce(throwFruitOrigin.transform.up * impulseMultiplier, ForceMode2D.Impulse);            
        }
    }
}
