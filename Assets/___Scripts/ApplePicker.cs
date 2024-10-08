using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // b

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")] public GameObject basketPrefab;

    public int numBaskets = 3;

    public float basketBottomY = -14f;

    public float basketSpacingY = 2f;
    public List<GameObject> basketList; // c

    void Start()
    {
        basketList = new List<GameObject>(); // d
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO); // e
        }
    }

    public void AppleMissed()
    {
        //
        // Destroy all of the falling apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple"); // b
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        // Destroy one of the Baskets // f
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        // Get a reference to the Basket GameObject 
        GameObject basketGO = basketList[basketIndex];
        // Remove the Basket fromthe list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        // If there are no baskets left, restart the game
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("ApplePicker"); // g
        }
    }
}
