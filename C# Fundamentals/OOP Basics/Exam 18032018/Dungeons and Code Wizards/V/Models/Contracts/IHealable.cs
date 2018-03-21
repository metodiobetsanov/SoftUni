using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Contracts
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}