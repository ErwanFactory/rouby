using UnityEngine;
using System.IO;
using System.Text;

public class Player {

    private string pseudo;
    public string Pseudo
    {
        get { return pseudo; }
        set { pseudo = value; }
    }

    private int roubifs;
    public int Roubifs
    {
        get { return roubifs; }
        set { roubifs = value; }
    }

    private string sprite;
    public string Sprite
    {
        get { return sprite; }
        set { sprite = value; }
    }

    public Player() {
	    try
        {
            string fileName = Application.persistentDataPath + "/player.info";
            using(StreamReader stream = new StreamReader(fileName, Encoding.Default))
            {
                string line = stream.ReadLine();
                string[] infos = line.Split(';');
                pseudo = infos[0];
                roubifs = int.Parse(infos[1]);
                sprite = infos[2];
            }
        } catch (IOException e)
        {
            Debug.Log(e.Message);
        }
	}
}
