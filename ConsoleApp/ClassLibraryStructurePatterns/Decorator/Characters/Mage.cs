namespace ClassLibraryStructurePatterns.Decorator.Characters
{
    public class Mage : ICharacter
    {
        public string GetDescription() => "Маг";
        public int GetAttack() => 60;
    }
}
