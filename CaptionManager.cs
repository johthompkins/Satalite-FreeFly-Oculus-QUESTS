using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptionManager : MonoBehaviour {

    public GameObject captionManager;
    public GameObject captionBTNText;
	
	public void CaptionSwitch()
    {
        if(captionManager.tag == "on")
        {
            captionManager.tag = "off";
            //captionManager.SetActive(false);
            captionText();
        }
       else if(captionManager.tag == "off")
        {
            captionManager.tag = "on";
           // captionManager.SetActive(true);
            captionText();
        }
    }
    public void captionText()
    {
        if (captionManager.tag == "off")
        {
            captionBTNText.GetComponentInChildren<Text>().text = "Captions Are Off";
        }
        else if (captionManager.tag == "on")
        {
            captionBTNText.GetComponentInChildren<Text>().text = "Captions Are On";
        }
    }

}