using ClassLibraryStructurePatterns.Decorator.Characters;

namespace ClassLibraryStructurePatterns.Decorator.Inventory
{
    public class Armor : InventoryDecorator
    {
        public Armor(ICharacter character) : base(character) { }

        public override string GetDescription() => _character.GetDescription() + " з бронею";
        public override int GetAttack() => _character.GetAttack();
    }
}
