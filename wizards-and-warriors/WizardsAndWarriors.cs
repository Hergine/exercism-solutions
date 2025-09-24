abstract class Character
{
    string _characterType;
    protected Character(string characterType)
    {
        this._characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {_characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if(target.Vulnerable())
        {
            return 10;
        }
        else
        {
            return 6;
        }
    }
}

class Wizard : Character
{
    private bool _spellPower;
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if(target.Vulnerable())
        {
            return 3;
        }
        else
        {
            return 12;
        }
    }

    public void PrepareSpell()
    {
        _spellPower = true;
    }

    public override bool Vulnerable()
    {
        if (_spellPower)
        {
            return false;
        }
        else 
        {
            return true;
        }
    }
}
