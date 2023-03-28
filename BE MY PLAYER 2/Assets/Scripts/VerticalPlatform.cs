using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effect;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        effect = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            /*this.waitTime = 0.5f;
            effect.rotationalOffset = 0f;*/

            StartCoroutine(resetVP());
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            effect.rotationalOffset = 180f;
            this.waitTime = 0.5f;
        }
        else
        {
            this.waitTime -= Time.deltaTime;
        }
        if (Input.GetButton("Jump"))
        {
            effect.rotationalOffset = 0f;
        }

    }
    private IEnumerator resetVP()
    {
        yield return new WaitForSeconds(0.1f);
        effect.rotationalOffset = 0f;
    }
}