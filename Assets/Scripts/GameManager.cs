using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        PlayerPrefs.DeleteAll();

        instance = this;
        SceneManager.sceneLoaded += LoadState;
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> mapSprite;

    //References
    public Player player;
    public FloatingTextManager floatingTextManager;

    // Logic
    public int map;

    //Floating Text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Save state
    /*
     * INT preferedSkin
     * INT map
     */
    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += map.ToString() + "|";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //change player skin
        map = int.Parse(data[1]);

        Debug.Log("LoadState");
    }
}
