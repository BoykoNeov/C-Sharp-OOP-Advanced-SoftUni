using NUnit.Framework;

namespace Tests
{
    public class AxeTests
    {
        private const int AxeDurability = 10;
        private const int AxeAttack = 10;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void CreateInitial()
        {
            this.dummy = new Dummy(DummyHealth, DummyExperience);
            this.axe = new Axe(AxeAttack, AxeDurability);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }
    }
}