using BikeRacerObservers;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
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

            BigScreenObserver observer = new BigScreenObserver();
            //TODO: Finish this unit test
        }
    }
}