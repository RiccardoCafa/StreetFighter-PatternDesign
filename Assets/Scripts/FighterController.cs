using System.Collections;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    public GameObject ChunLiPrefab;
    public GameObject BisonPrefab;

    public Transform SpawnPlayer01;
    public Transform SpawnPlayer02;

    public GameUI GameUILogic;
    
    private GameObject player1;
    private GameObject player2;

    private void OnEnable()
    {
        Application.targetFrameRate = 60;

        var player = PlayerPrefs.GetString(HeroChooser.PLAYER_KEY);

        GameUILogic.gameObject.SetActive(true);

        if(player == "ChunLi")
        {
            player1 = new ChunLiTemplate(ChunLiPrefab).Build(true);
            player2 = new BisonTemplate(BisonPrefab).Build(false);
        }
        else
        {
            player1 = new BisonTemplate(BisonPrefab).Build(true);
            player2 = new ChunLiTemplate(ChunLiPrefab).Build(false);
        }

        IActionStrategy actionStrategy = ((CharacterGameStrategy)player2.GetComponent<Fighter>().StrategyFighter).strategyAction;
        
        if (actionStrategy is AIActionStrategy)
        {
            (actionStrategy as AIActionStrategy).SetFighters(player2, player1);
            print("Action Strategy Fighters sat to IA");
        }

        player1.transform.position = SpawnPlayer01.position;
        player2.transform.position = SpawnPlayer02.position;

        var strategyFighter = player1.GetComponent<Fighter>().StrategyFighter;
        var strategyFighter2 = player2.GetComponent<Fighter>().StrategyFighter;

        GameUILogic.SetPlayer01DmgEvent(strategyFighter);
        GameUILogic.SetPlayer02DmgEvent(strategyFighter2);
        GameUILogic.SetPlayerDeathEvent(strategyFighter, strategyFighter2);

        DestroyAfterDeath(strategyFighter);
        DestroyAfterDeath(strategyFighter2);

        HitEffect(player1);
        HitEffect(player2);
    }

    private void DestroyAfterDeath(IGameStrategy strategyFighter)
    {
        strategyFighter.OnPlayerDeath += (sender, args) => {
            Destroy(player1);
            Destroy(player2);

            gameObject.SetActive(false);
        };
    }

    private void HitEffect(GameObject player)
    {
        var strategyFighter = player.GetComponent<Fighter>().StrategyFighter;

        strategyFighter.OnPlayerTakeDmg += (sender, args) =>
        {
            player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
            StartCoroutine(HitCoroutine(player));
        };
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.F2))
        {
            ((CharacterGameStrategy)player2.GetComponent<Fighter>().StrategyFighter).strategyAction = new Keyboard2ActionStrategy();
        }
    }

    private IEnumerator HitCoroutine(GameObject player)
    {
        yield return new WaitForSeconds(0.3f);

        if(player != null)
        {
            player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        }
    }
}
