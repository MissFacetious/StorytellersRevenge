using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour {

    public GameObject effect;
    bool held;

	// Use this for initialization
	void Start () {
        HideEffect();
        held = false;
	}
	
    public void ShowEffect()
    {
        if (!held)
        {
            held = true;
            effect.SetActive(true);
            StartCoroutine(WaitToStop());
        }
    }

    IEnumerator WaitToStop()
    {
        yield return new WaitForSeconds(5f);
        if (held)
        {
            HideEffect();
            held = false;
        }
    }

    public void HideEffect()
    {
        effect.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
