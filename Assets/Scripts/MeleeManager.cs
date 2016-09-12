using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MeleeManager : MonoBehaviour {

    public GameObject go_ligne_blanche;
    public GameObject go_melee; 

    public Text niveauText; //Texte à afficher pour annoncer le niveau
    public Text gainText; //Texte à afficher lorsque le joueur gagne
    public Text introText; //Texte à afficher pour le niveau 0

    //Différents écrans du jeu
    public GameObject screen_win;
    public GameObject screen_lose;
    public GameObject screen_melee;

    public int level; //Niveau actuel

    private Melee melee;
    private bool ending;

	// Use this for initialization
	void Start () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        level = PlayerPrefs.GetInt("p_levelCur");
        ending = false;
        melee = go_melee.GetComponent<Melee>();
        StartCoroutine(Load_level());
    }
	
	// Update is called once per frame
	void Update () {
        //Vérification de fin de jeu
        if (go_melee.transform.position.y >= go_ligne_blanche.transform.position.y)
        {
            gainText.gameObject.SetActive(true);
            gainText.enabled = true;
            if (level < 8)
            {
                level++;
                StartCoroutine(Load_level());
            }
            else if (!ending)
            {
                melee.GetComponent<Melee>().Stop();
                StartCoroutine(End(true));
            }
        }
        else if (go_melee.transform.position.y <= this.transform.position.y - 10 && !ending)
        {
            melee.GetComponent<Melee>().Stop();
            StartCoroutine(End(false));
        } 

        //Interactions avec le joueur
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            melee.Avancer();
        }
        else
        {
            melee.Reculer();
        }
    }

    private IEnumerator End(bool win)
    {
        ending = true;
        
        //Affichage de l'écran de victoire ou de défaite
        screen_win.SetActive(win);
        screen_lose.SetActive(!win);
        screen_melee.SetActive(false);

        //Calcul des gains du joueur
        int level_debut = PlayerPrefs.GetInt("p_levelCur");
        int gain = 0;
        gain += (level - level_debut >= 3 ? 5 : 0);
        gain += (level - level_debut >= 6 ? 10 : 0);
        gain += (level - level_debut >= 8 ? 15 : 0);
        gain += level - 1;

        //Affichage du nombre de roubiffs gagnés
        yield return new WaitForSeconds(1f);
        gainText.text = "0 roubiff !";
        gainText.rectTransform.anchoredPosition = new Vector2(0, -417);
        gainText.gameObject.SetActive(true);
        gainText.enabled = true;
        for (int i = 1; i <= gain; i++)
        {
            gainText.text = i + " roubiffs !";
            yield return new WaitForSeconds(0.01f);
        }

        if (level > PlayerPrefs.GetInt("p_levelMax"))
        {
            PlayerPrefs.SetInt("p_levelMax", level - 1);
        }
        
        //Ajout des roubiffs gagné au porte-monnaie du joueur
        int roubiffs = PlayerPrefs.GetInt("p_roubiffs");
        PlayerPrefs.SetInt("p_roubiffs", roubiffs + gain);
    }

    private IEnumerator Load_level()
    {
        niveauText.text = niveauText.text.Replace("%lvl%", level.ToString());
        niveauText.gameObject.SetActive(true);
        niveauText.enabled = true;

        melee.Stop();
        Difficulty();
        yield return new WaitForSeconds(1f);
        melee.Reprendre();

        niveauText.enabled = false;
        niveauText.text = "Manche %lvl% !";
        introText.enabled = false;
        gainText.enabled = false;
    }

    private void Difficulty()
    {
        melee.Speed = 0.9f / level;
        melee.EnemyForce = 0.0025f * level;
        go_ligne_blanche.transform.position = new Vector3(0, level, -1);
        go_melee.transform.position = new Vector3(0, -level, -2);
    }
}

