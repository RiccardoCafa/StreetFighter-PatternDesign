using UnityEngine;

public class BisonTemplate : CharacterTemplate
{
    public BisonTemplate(GameObject prefab) : base(prefab) { }

    public override void LoadSounds()
    {
        PunchSound = Resources.Load<AudioClip>("Sounds/Characters/Bison/Punch");
        KickSound = Resources.Load<AudioClip>("Sounds/Characters/Bison/Kick");
    }

    public override CharacterGameStrategy Player01Strategy()
    {
        return new Bison(_fighter, new KeyboardActionStrategy(), PunchSound, KickSound);
    }

    public override CharacterGameStrategy Player02Strategy()
    {
        return new Bison(_fighter, new AIActionStrategy(), PunchSound, KickSound);
    }

    public override CharacterGameStrategy Player02LocalStrategy()
    {
       return new Bison(_fighter, new Keyboard2ActionStrategy(), PunchSound, KickSound);
    }
}
