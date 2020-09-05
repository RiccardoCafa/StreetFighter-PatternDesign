using UnityEngine;

public abstract class CharacterTemplate
{
    public CharacterTemplate(GameObject prefab)
    {
        MyPrefab = prefab;
    }

    public CharacterGameStrategy Strategy;

    protected GameObject MyPrefab;
    protected GameObject _fighter;
    protected AudioClip PunchSound;
    protected AudioClip KickSound;

    public GameObject Build(bool IsPlayer)
    {
        _fighter = InstantiatePrefab();

        LoadSounds();

        CharacterGameStrategy GameStrategy;

        if (IsPlayer)
        {
            _fighter.name = "Player1";
            GameStrategy = Player01Strategy();
        }
        else
        {
            _fighter.name = "Player2";
            GameStrategy = Player02Strategy();
            _fighter.transform.localScale = new Vector3(-_fighter.transform.localScale.x, _fighter.transform.localScale.y, _fighter.transform.localScale.z);
        }

        _fighter.GetComponent<Fighter>().StrategyFighter = GameStrategy;

        return _fighter;
    }

    public GameObject InstantiatePrefab() => GameObject.Instantiate(MyPrefab);

    public abstract void LoadSounds();

    public abstract CharacterGameStrategy Player01Strategy();

    public abstract CharacterGameStrategy Player02Strategy();

    public abstract CharacterGameStrategy Player02LocalStrategy();
}
