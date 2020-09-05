using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Image Player01Image;
    public Image Player02Image;

    public TextMeshProUGUI winner;
    public GameObject gameCanvas;
    public GameObject menuCanvas;

    public float Width;
    public float Height;

    private void OnEnable()
    {
        Player01Image.rectTransform.sizeDelta = new Vector3(Width, Height, 1f);
        Player02Image.rectTransform.sizeDelta = new Vector3(Width, Height, 1f);
    }

    private void Awake()
    {
        Width = Player01Image.rectTransform.rect.width;
        Height = Player01Image.rectTransform.rect.height;
    }

    public void SetPlayer01DmgEvent(IGameStrategy Character)
    {
        Character.OnPlayerTakeDmg += (life, sender) =>
        {
            Player01Image.rectTransform.sizeDelta = new Vector3(Width * (life / 100f), Height, 1f);
            Debug.Log("Life p1 size: " + (life / 100f));
        };
    }

    public void SetPlayer02DmgEvent(IGameStrategy Character)
    {
        Character.OnPlayerTakeDmg += (life, sender) =>
        {
            Player02Image.rectTransform.sizeDelta = new Vector3(Width * (life / 100f), Height, 1f);
            Debug.Log("Life p2 size: " + (life / 100f));
        };
    }

    public void SetPlayerDeathEvent(IGameStrategy Character1, IGameStrategy Character2)
    {
        SubscribeDeathEvent(Character1);
        SubscribeDeathEvent(Character2);
    }

    private void SubscribeDeathEvent(IGameStrategy Character)
    {
        Character.OnPlayerDeath += (sender, args) =>
        {
            winner.text = $"Last winner: {args.Sender.Name}";
            winner.gameObject.SetActive(true);
            menuCanvas.SetActive(true);
            gameCanvas.SetActive(false);
        };
    }
}