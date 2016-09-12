using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

    public void OnClick_MiniJeux()
    {
        SceneManager.LoadScene("mini-jeux");
    }

    public void OnClick_Penderie()
    {
        SceneManager.LoadScene("notYet");
    }

    public void OnClick_Boutique()
    {
        SceneManager.LoadScene("notYet");
    }

    public void OnClick_Classement()
    {
        SceneManager.LoadScene("notYet");
    }

    public void OnClick_Options()
    {
        SceneManager.LoadScene("options");
    }

    public void OnClick_Back()
    {
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
        SceneManager.LoadScene("menu");
    }

    public void OnClick_Essai()
    {
        SceneManager.LoadScene("notYet");
    }

    public void OnClick_Melee()
    {
        SceneManager.LoadScene("choix_niveau_melee");
    }

    public void OnClick_TirButs()
    {
        SceneManager.LoadScene("notYet");
    }

    public void OnClick_Difficulte(int i)
    {
        if (i <= PlayerPrefs.GetInt("p_levelMax"))
        {
            PlayerPrefs.SetInt("p_levelCur", i);
            SceneManager.LoadScene("melee");
        }
    }

    public void OnClick_Replay()
    {
        SceneManager.LoadScene("melee");
    }

    public void OnValueChange_Son(Object s_son)
    {
        Slider son = s_son as Slider;
        AudioListener.volume = son.value;
    }

    public void OnValueChange_Luminosite(Object s_luminosite)
    {
        Slider luminosite = s_luminosite as Slider;
        RenderSettings.ambientLight = new Color(luminosite.value, luminosite.value, luminosite.value, 1);
    }

    private void NotYet()
    {
        SceneManager.LoadScene("notYet");
    }
}
