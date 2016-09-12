using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DifficulteManager : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Sprite b_play1 = GameObject.Find("Canvas/b_play1").GetComponent<Button>().GetComponent<Image>().overrideSprite;
        for (int i = 2; i <= PlayerPrefs.GetInt("p_levelMax"); i++)
        {
            Button b_play = GameObject.Find("Canvas/b_play" + i).GetComponent<Button>();
            b_play.GetComponent<Image>().overrideSprite = b_play1;
            GameObject.Find("Canvas/b_play" + i + "/Text").GetComponent<Text>().color = Color.white;
        }
	}
}
