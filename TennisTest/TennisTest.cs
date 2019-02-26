using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisTest
{
    [TestClass]
    public class TennisTest
    {
        private Tennis _tennis = new Tennis("AA", "BB");

        [TestMethod]
        public void Love_All()
        {
            ScoreShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            GivenFirstPlayerScore(1);
            ScoreShouldBe("Fifteen Love");
        }

        [TestMethod]
        public void Thirty_Love()
        {
            GivenFirstPlayerScore(2);
            ScoreShouldBe("Thirty Love");
        }

        [TestMethod]
        public void Forty_Love()
        {
            GivenFirstPlayerScore(3);
            ScoreShouldBe("Forty Love");
        }

        [TestMethod]
        public void Love_Fifteen()
        {
            GivenSecondPlayerScore(1);
            ScoreShouldBe("Love Fifteen");
        }

        [TestMethod]
        public void Love_Thirty()
        {
            GivenSecondPlayerScore(2);
            ScoreShouldBe("Love Thirty");
        }

        [TestMethod]
        public void Love_Forty()
        {
            GivenSecondPlayerScore(3);
            ScoreShouldBe("Love Forty");
        }

        [TestMethod]
        public void Fifteen_All()
        {
            GivenFirstPlayerScore(1);
            GivenSecondPlayerScore(1);
            ScoreShouldBe("Fifteen All");
        }

        [TestMethod]
        public void Thirty_All()
        {
            GivenFirstPlayerScore(2);
            GivenSecondPlayerScore(2);
            ScoreShouldBe("Thirty All");
        }

        [TestMethod]
        public void Deuce()
        {
            GivenDeuce();
            ScoreShouldBe("Deuce");
        }

        [TestMethod]
        public void FirstPlayer_Adv()
        {
            GivenDeuce();
            GivenFirstPlayerScore(1);
            ScoreShouldBe("AA Adv");
        }

        [TestMethod]
        public void SecondPlayer_Adv()
        {
            GivenDeuce();
            GivenSecondPlayerScore(1);
            ScoreShouldBe("BB Adv");
        }

        [TestMethod]
        public void FirstPlayer_Win()
        {
            GivenDeuce();
            GivenFirstPlayerScore(2);
            ScoreShouldBe("AA Win");
        }

        [TestMethod]
        public void SecondPlayer_Win()
        {
            GivenDeuce();
            GivenSecondPlayerScore(2);
            ScoreShouldBe("BB Win");
        }

        private void GivenDeuce()
        {
            GivenFirstPlayerScore(3);
            GivenSecondPlayerScore(3);
        }

        private void GivenSecondPlayerScore(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _tennis.SecondPlayerScore();
            }
        }

        private void GivenFirstPlayerScore(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _tennis.FirstPlayerScore();
            }
        }

        private void ScoreShouldBe(string expected)
        {
            Assert.AreEqual(expected, _tennis.Score());
        }
    }
}