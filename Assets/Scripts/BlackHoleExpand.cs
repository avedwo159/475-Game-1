using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleExpand : MonoBehaviour
{
    public GameManager gameManager;
    private Vector3 grow;
    public float growFactor = 1;

    // Start is called before the first frame update
    void Start()
    {
        var rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.black);

        grow = new Vector3(growFactor, growFactor, growFactor);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += grow;
    }

    // Triggers when the player enters the water
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //var rend = GetComponent<Renderer>();
            //rend.material.SetColor("_Color", Color.red);

            gameManager.Dead();
        }
    }
}
