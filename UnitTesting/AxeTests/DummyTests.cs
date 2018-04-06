// For successful use of NUnuit the following packages should be install through NuGet:
// Microsoft.Net.Test.Sdk
// NUnit
// Nunit3TestAdapter

using NUnit.Framework;
using System;

namespace Tests
{
    public class DummyTests
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
        public void DummyLosesHealthWhenAttacked()
        {
            axe.Attack(dummy);
            Assert.AreEqual(DummyHealth - AxeAttack, dummy.Health, "After receiving 10 points of damage, dummy health is not 10 points less");
        }

        [Test]
        public void AttackingWithDefaultAttackShouldKillDummy()
        {
            axe.Attack(dummy);
            Assert.That(dummy.IsDead() == true, "Dummy with 10 hitpoints should be dead after being attacked for 10");
        }

        [Test]
        public void DeadDummyThrowsExceptionWhenAttacked()
        {
            dummy.TakeAttack(dummy.Health);
            var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Attacking dead dummy doesn't throw an Invalid Operation Exception");
            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."), "Exception message is not 'Dummy is dead'");
        }

        [Test]
        public void DeadDummyGivesExperience()
        {
            dummy.TakeAttack(dummy.Health);
            int experience = dummy.GiveExperience();
            Assert.That(experience == DummyExperience, "Dead dummy does not give standart dummy experience");
        }

        [Test]
        public void AliveDummyGivesExperience()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Alive dummy trying to give experience doesn't throw an Invalid Operation Exception");
            Assert.That(ex.Message, Is.EqualTo("Target is not dead."), "Exception message is not 'Dummy is dead'");
        }
    }
}