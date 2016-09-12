using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public Text t_salut;

	void Start () {
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        if (!PlayerPrefs.HasKey("p_pseudo"))
        {
            PlayerPrefs.SetString("p_pseudo", "Tony");
        }
        if (!PlayerPrefs.HasKey("p_roubiffs"))
        {
            PlayerPrefs.SetInt("p_roubiffs", 0);
        }
        if (!PlayerPrefs.HasKey("p_skin"))
        {
            PlayerPrefs.SetString("p_skin", "");
        }
        if (!PlayerPrefs.HasKey("p_levelMax"))
        {
            PlayerPrefs.SetInt("p_levelMax", 1);
        }
        t_salut.text = t_salut.text.Replace("%pseudo%", PlayerPrefs.GetString("p_pseudo"));
	}
}
