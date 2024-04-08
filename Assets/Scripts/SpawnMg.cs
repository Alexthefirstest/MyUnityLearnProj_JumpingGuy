using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMg : MonoBehaviour
{

    public GameObject obsPrefab;

    public PlayerController plCtrl;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1, 2);
        plCtrl = GameObject.Find("MyPlayer").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        if (!plCtrl.gameOver)
        {
            Instantiate(obsPrefab, new Vector3(35, 0, 0), obsPrefab.transform.rotation);
        }
    }
}
