using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayController : MonoBehaviour {

	Text txt;
    string story;

    void Awake()
    {
        txt = GetComponent<Text>();
        story = txt.text;
        txt.text = "";

        // TODO: add optional delay when to start
        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        var numberOfChar = story.Length;

        for (int i = 0; i < numberOfChar; i++)
        {
            txt.text += story[i];
            yield return new WaitForSeconds(0.03f);
            if (i == (numberOfChar - 1))
            {
                yield return new WaitForSeconds(3f);
                Destroy(txt);
            }
        }

    }

}
