using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFruitsController : MonoBehaviour
{
    [Header("Prefabs Refereces")]
    public GameObject[] fruitThrowed;
    public GameObject bombPrefab;

    [Header("Values")]
    public float minWaitTime = .3f;
    public float maxWaitTime = 1f;
    public float minImpulseMultiplier = 12f;
    public float maxImpulseMultiplier = 17f;
    private float impulseMultiplier;

    [Header("Fruit origins references")]
    public Transform[] throwFruitOrigins;
    private Transform throwFruitOrigin;
    private GameObject fruit;
    private GameObject selectedPrefab;

    private int selectedFruitIndex;

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

            int tempProbabillity = Random.Range(0,100);
            if (tempProbabillity < 10)
            {
                selectedPrefab = bombPrefab;
            }
            else
            {
                selectedFruitIndex = Random.Range(0, fruitThrowed.Length);
                selectedPrefab = fruitThrowed[selectedFruitIndex];
            }            
            fruit = Instantiate(selectedPrefab, throwFruitOrigin.position, throwFruitOrigin.rotation);

            impulseMultiplier = Random.Range(minImpulseMultiplier, maxImpulseMultiplier);
            fruit.GetComponent<Rigidbody2D>().AddForce(throwFruitOrigin.transform.up * impulseMultiplier, ForceMode2D.Impulse);            
        }
    }
}
