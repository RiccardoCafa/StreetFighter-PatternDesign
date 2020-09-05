using UnityEngine;

public class ChunLiTemplate : CharacterTemplate
{
    public ChunLiTemplate(GameObject prefab) : base(prefab) { }
    
    public override void LoadSounds()
    {
        PunchSound = Resources.Load<AudioClip>("Sounds/Characters/Chun-Li/Punch");
        KickSound = Resources.Load<AudioClip>("Sounds/Characters/Chun-Li/Kick");
    }

    public override CharacterGameStrategy Player01Strategy()
    {
        return new ChunLi(_fighter, new KeyboardActionStrategy(), PunchSound, KickSound);
    }

    public override CharacterGameStrategy Player02Strategy()
    {
        return new ChunLi(_fighter, new AIActionStrategy(), PunchSound, KickSound);
    }

    public override CharacterGameStrategy Player02LocalStrategy()
    {
        return new ChunLi(_fighter, new Keyboard2ActionStrategy(), PunchSound, KickSound);
    }
}
