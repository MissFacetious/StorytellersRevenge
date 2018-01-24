using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactive360;

public class Credits : MonoBehaviour {

    public bool ready;
    // Use this for initialization
    void Start () {
        // remove any buttons you don't want
        ready = false;
        StartCoroutine(ShowCreditsForABit());
    }

    IEnumerator ShowCreditsForABit()
    {
        // wait 10 seconds
        for (int i = 0; i < 100; i++)
        {
            if (ready) break;
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("done");
        GameObject.Find("VideoManager").GetComponent<GameManager>().LoadIntro();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("VideoManager").GetComponent<GameManager>().LoadIntro();
        }
    }
}
