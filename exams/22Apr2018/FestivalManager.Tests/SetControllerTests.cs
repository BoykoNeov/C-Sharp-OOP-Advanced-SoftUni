// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
	using NUnit.Framework;

    [TestFixture]
	public class SetControllerTests
    {
        [Test]
        public void Test()
        {
            try
            {
                IStage stage = new Stage();
                ISet set = new Medium("MediumSet");
                stage.AddSet(set);
                SetController setController = new SetController(stage);
                string result = setController.PerformSets();
                Assert.That(result.Contains("MediumSet"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Test2()
        {
            try
            {
                IStage stage = new Stage();
                ISet set = new Medium("MediumSet");
                stage.AddSet(set);
                SetController setController = new SetController(stage);
                string result = setController.PerformSets();
                Assert.That(result.Contains("-- Did not perform"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Test3()
        {
            try
            {
                IStage stage = new Stage();
                ISet set = new Medium("MediumSet");
                set.AddSong(new Song("newSong", new System.TimeSpan(0, 5, 0)));
                Performer peso = new Performer("Pesho", 50);
                peso.AddInstrument(new Drums());
                set.AddPerformer(peso);

                stage.AddSet(set);
                SetController setController = new SetController(stage);
                string result = setController.PerformSets();
                Assert.That(result.Contains("-- Set Successful"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Test4()
        {
            try
            {
                IStage stage = new Stage();
                ISet set = new Medium("MediumSet");
                set.AddSong(new Song("newSong", new System.TimeSpan(0, 5, 0)));

                Performer peso = new Performer("Pesho", 50);
                peso.AddInstrument(new Drums());
                set.AddPerformer(peso);
                stage.AddSet(set);
                SetController setController = new SetController(stage);
                string result = setController.PerformSets();
                Assert.That(result.Contains("newSong"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Test5()
        {
            try
            {
                IStage stage = new Stage();
                ISet set = new Medium("MediumSet");
                set.AddSong(new Song("newSong", new System.TimeSpan(0, 5, 0)));

                Performer peso = new Performer("Pesho", 50);
                peso.AddInstrument(new Drums());
                set.AddPerformer(peso);
                stage.AddSet(set);
                SetController setController = new SetController(stage);
                string result = setController.PerformSets();
                Assert.That(result.Contains("(05:00)"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Test6()
        {
            try
            {
                IStage stage = new Stage();
                ISet set = new Medium("MediumSet");
                set.AddSong(new Song("newSong", new System.TimeSpan(0, 5, 0)));

                Performer peso = new Performer("Pesho", 50);
                set.AddPerformer(peso);
                stage.AddSet(set);
                SetController setController = new SetController(stage);
                string result = setController.PerformSets();
                Assert.That(result.Contains("-- Did not perform"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Test7()
        {
            try
            {
                IStage stage = new Stage();
                ISet set = new Medium("MediumSet");
                set.AddSong(new Song("newSong", new System.TimeSpan(0, 5, 0)));

                Performer peso = new Performer("Pesho", 50);
                set.AddPerformer(peso);
                stage.AddSet(set);
                SetController setController = new SetController(stage);
                string result = setController.PerformSets();
                Assert.That(!result.Contains("-- Set Successful"));
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}