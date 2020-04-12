using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    [SerializeField] float rizeWater = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float risePerTimeUnit = rizeWater * Time.deltaTime;
        transform.Translate(new Vector2(0f, risePerTimeUnit));
    }
}
