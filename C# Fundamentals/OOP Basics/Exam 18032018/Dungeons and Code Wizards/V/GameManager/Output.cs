namespace DungeonsAndCodeWizards.GameManager
{
    public static class Output
    {
        public static string NameCannotBeNullOrWhitespace = "Name cannot be null or whitespace!";

        public static string MustBeAlive = "Must be alive to perform this action!";

        public static string BagIsFull = "Bag is full!";

        public static string BagIsEmpty = "Bag is empty!";

        public static string ItemDoesNotExist = "No item with name {0} in bag!";

        public static string CannotAttackSelf = "Cannot attack self!";

        public static string CannotAttackFaction = "Friendly fire! Both characters are from {0} faction!";

        public static string CannotHealEnemy = "Cannot heal enemy character!";

        public static string InvalidFaction = "Invalid faction \"{0}\"!";

        public static string InvalidCharType = "Invalid character type \"{0}\"!";

        public static string InvalidItemName = "Invalid item \"{0}\"!";

        public static string CharNotFound = "Character {0} not found!";

        public static string PoolEmpty = "No items left in pool!";

        public static string CannotAttack = "{0} cannot attack!";

        public static string CannotHeal = "{0} cannot heal!";
    }
}