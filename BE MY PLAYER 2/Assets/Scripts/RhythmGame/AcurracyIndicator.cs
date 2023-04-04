using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcurracyIndicator : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private float fadeDelay = 0.2f;
    [SerializeField] private float descendSpeed = 2;

    private float curTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;

        if (curTime >= fadeDelay)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if (objectColor.a <= 0)
            {
                Destroy(this.gameObject);
            }

            transform.position -= new Vector3(0f, descendSpeed * Time.deltaTime, 0f);
        }
    }
}
