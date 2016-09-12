using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniJeuxManager : MonoBehaviour {

    public Text t_roubiffs;

	// Use this for initialization
	void Start () {
        t_roubiffs.text = t_roubiffs.text.Replace("%roubiffs%", PlayerPrefs.GetInt("p_roubiffs").ToString());
	}
}
