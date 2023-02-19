using BikeRacerObservers;

namespace UnitTests
{
    // The purpose of these unit tests is to test primary elements 
    // of the observer pattern.

    // Note, this  test project is not a WinForms project, so access
    // to WinForms classes causes errors. Therefore, the only functionality
    // tested is that of Non-Winforms classes (this includes only classes without 
    // a form as a member). The functionality of observer pattern in the
    // BigScreenObserver and the Cheating Computer is the same, so testing the 
    // cheating computer effectively tests the BigScreenObserver
    [TestClass]
    public class BikeRacerObserversTests
    {

        // Tests the subscription functionality
        [TestMethod]
        public void TestSubscribing()
        {
            Racer testRacer = new Racer();
            testRacer.BibNumber = 1;
            testRacer.FirstName = "Test";
            testRacer.LastName = "Racer";

            CheatingComputer observer = new CheatingComputer();
            observer.Subscribe(testRacer);
            
            Assert.AreEqual(observer.GetRacers().Count(), 1);
            Assert.AreEqual(observer.GetRacers()[0], testRacer);
        }


        // Tests the unsubscribing functionality
        [TestMethod]
        public void TestUnSubscribing()
        {
            Racer testRacer = new Racer();
            testRacer.BibNumber = 1;
            testRacer.FirstName = "Test";
            testRacer.LastName = "Racer";

            Racer testRacer2 = new Racer();
            testRacer2.BibNumber = 2;
            testRacer2.FirstName = "Test";
            testRacer2.LastName = "Racer";

            CheatingComputer observer = new CheatingComputer();
            observer.Subscribe(testRacer);
            observer.Subscribe(testRacer2);
            observer.Unsubscribe(testRacer);

            Assert.AreEqual(observer.GetRacers().Count(), 1);
            Assert.AreEqual(observer.GetRacers()[0], testRacer2);
        }


        // Tests the updating of observers when the racer is updated.
        [TestMethod]
        public void TestUpdating()
        {
            Racer testRacer = new Racer();
            testRacer.BibNumber = 1;
            testRacer.FirstName= "Test";
            testRacer.LastName= "Racer";
            
            // Note, this is not critical, so just the millisecond component is alright
            testRacer.StartTime = DateTime.Now.Millisecond;
            
            testRacer.Update(0, (long)testRacer.StartTime);
            Assert.AreEqual(testRacer.CurrentSensorNumber, 0);
            Assert.AreEqual(testRacer.CurrentSensorTime, (long)testRacer.StartTime);
            
            CheatingComputer observer = new CheatingComputer();
            observer.Subscribe(testRacer);
            //
            testRacer.Update(1, (long)7327); // Note, there is no specific reason for 7327
            Assert.AreEqual(observer.GetRacers()[0].CurrentSensorNumber, 1);
            Assert.AreEqual(observer.GetRacers()[0].CurrentSensorTime, 7327);
        }


        // Tests the computation of the cheating computer
        [TestMethod]
        public void TestCheating()
        {
            Racer cheater1 = new Racer();
            cheater1.BibNumber = 1;
            cheater1.FirstName = "Cheater";
            cheater1.LastName = "One";
            cheater1.Group = 1;
            cheater1.StartTime = 0;

            Racer cheater2 = new Racer();
            cheater2.BibNumber = 100;
            cheater2.FirstName = "Cheater";
            cheater2.LastName = "Two";
            cheater2.Group = 2;
            cheater2.StartTime = 0;

            Racer nonCheater = new Racer();
            nonCheater.BibNumber = 200;
            nonCheater.FirstName = "Non";
            nonCheater.LastName = "Cheater";
            nonCheater.Group = 3;
            nonCheater.StartTime = 0;


            CheatingComputer observer = new CheatingComputer();
            observer.Subscribe(cheater1);
            observer.Subscribe(cheater2);
            observer.Subscribe(nonCheater);


            cheater1.Update(0, (long)cheater1.StartTime);
            cheater2.Update(0, (long)cheater1.StartTime);
            nonCheater.Update(0, (long)cheater1.StartTime);

            cheater1.Update(1, 3000);
            cheater2.Update(1, 3000);
            nonCheater.Update(1, 6001);


            observer.FinalizeRace();
            List<(Racer cheater, Racer cheatedWith)> cheaters = observer.getCheaters();

            Assert.AreEqual(cheaters.Count, 1);
            if ((cheaters[0].cheater == cheater1 && cheaters[0].cheatedWith == cheater2) || (cheaters[0].cheatedWith == cheater1 && cheaters[0].cheater == cheater2))
                Assert.AreEqual(true, true);
            else
                Assert.AreEqual(true, false);
        }
    }
}