namespace ClassLibraryStructurePatterns.Decorator.Characters
{
    public class Palladin : ICharacter
    {
        public string GetDescription() => "Паладин";
        public int GetAttack() => 45;
    }
}
