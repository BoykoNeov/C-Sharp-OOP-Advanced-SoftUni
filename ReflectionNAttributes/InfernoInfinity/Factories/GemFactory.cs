using System;

public class GemFactory
{
    public Gem CreateGem(string gemTypeName, string gemClarityString)
    {
        Type gemType = Type.GetType(gemTypeName);
        GemClarity gemClarity = (GemClarity)Enum.Parse(typeof(GemClarity), gemClarityString);
        Gem newGem = (Gem)Activator.CreateInstance(gemType, new object[] {gemClarity});
        return newGem;
    }
}