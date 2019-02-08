using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;


    public List<GameObject> BasketList;
    // Start is called before the first frame update
    void Start()
    {
        BasketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            BasketList.Add(tBasketGO);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AppleDestroyed()
    {
        // Destroy all of the falling Apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        // Destroy one of the baskets
        // Get the index of the last basket in basketList
        int basketIndex = BasketList.Count-1;
        // Get a reference to that basket's gameObject
        GameObject tBasketGO = BasketList[basketIndex];
        BasketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        // Restart our game, which does not affect our high score
        if (BasketList.Count == 0)
        {
            //Application.LoadLevel("_Scene_0");
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
