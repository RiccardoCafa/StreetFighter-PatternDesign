using UnityEngine;
using UnityEngine.UI;

public class HeroChooser : MonoBehaviour
{
    public static readonly string PLAYER_KEY = "PLAYER";
    public static readonly string IA_KEY = "IA";
    public static readonly string ChunLiKey = "ChunLi";
    public static readonly string BisonKey = "Bison";

    public Button Bison;
    public Button ChunLi;

    public GameObject fighterController;
    
    void Start()
    {
        Bison.onClick.AddListener(() =>
        {
            PlayerPrefs.SetString(PLAYER_KEY, BisonKey);
            PlayerPrefs.SetString(IA_KEY, ChunLiKey);
            StartGame();
        });
        ChunLi.onClick.AddListener(() =>
        {
            PlayerPrefs.SetString(PLAYER_KEY, ChunLiKey);
            PlayerPrefs.SetString(IA_KEY, BisonKey);
            StartGame();
        });
    }

    public void StartGame()
    {
        fighterController.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log($"Player selecionado: {PlayerPrefs.GetString(PLAYER_KEY)}");
        Debug.Log($"IA selecionada: {PlayerPrefs.GetString(IA_KEY)}");
        var fightSound = Resources.Load<AudioClip>("Sounds/Menu/fight");
        Viola.Instance.Source.PlayOneShot(fightSound);
    }
}
