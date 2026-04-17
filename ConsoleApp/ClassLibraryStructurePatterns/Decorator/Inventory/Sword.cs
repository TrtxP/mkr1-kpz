using ClassLibraryStructurePatterns.Decorator.Characters;

namespace ClassLibraryStructurePatterns.Decorator.Inventory
{
    public class Sword : InventoryDecorator
    {
        public Sword(ICharacter character) : base(character) { }

        public override string GetDescription() => _character.GetDescription() + " з мечем";
        public override int GetAttack() => _character.GetAttack() + 20;
    }
}
