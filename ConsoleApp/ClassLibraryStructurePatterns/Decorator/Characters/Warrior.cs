namespace ClassLibraryStructurePatterns.Decorator.Characters
{
    public class Warrior : ICharacter
    {
        public string GetDescription() => "Воїн";
        public int GetAttack() => 20;
    }
}
