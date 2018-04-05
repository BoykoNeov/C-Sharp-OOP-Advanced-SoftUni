public abstract class Gem : IWeaponSocketInsertable
{
    private int vitalityBonus;
    private int agilityBonus;
    private int strengthBonus;

    protected Gem(int strengthBonus, int agilityBonus, int vitalityBonus, GemClarity clarity)
    {
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.VitalityBonus = vitalityBonus;

        this.Clarity = clarity;
    }

    public GemClarity Clarity { get; private set; }

    public int StrengthBonus
    {
        get
        {
            return this.strengthBonus + (int)this.Clarity;
        }
        private set => strengthBonus = value;
    }

    public int AgilityBonus
    {
        get
        {
            return this.agilityBonus + (int)this.Clarity;
        }
        private set => agilityBonus = value; }

    public int VitalityBonus
    {
        get
        {
            return this.vitalityBonus + (int)this.Clarity;
        }
        private set => vitalityBonus = value; }
}