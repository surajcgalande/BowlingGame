using NUnit.Framework;

namespace BowlingGame.Test
{
    public class BowlingGameTests
    {
        private BowlingGame game;

        [SetUp]
        public void setUp()
        {
            game = new BowlingGame();
        }

        [TestCase]
        public void Check_Score_When_No_Spare_Or_Strike()
        {
            game.Roll(1);
            game.Roll(3);

            int score = game.Score();
            Assert.AreEqual(4, score);
        }

        [TestCase]
        public void Check_Score_When_Frame_Has_Spare()
        {
            game.Roll(4);
            game.Roll(6);

            int score = game.Score();
            Assert.AreEqual(10, score);

            game.Roll(5);
            game.Roll(0);

            score = game.Score();
            Assert.AreEqual(20, score);
        }

        [TestCase]
        public void Check_Score_When_Frame_Has_Strike()
        {
            game.Roll(10);
            game.Roll(0);

            int score = game.Score();
            Assert.AreEqual(10, score);

            game.Roll(5);
            game.Roll(4);

            score = game.Score();
            Assert.AreEqual(28, score);
        }

        [TestCase]
        public void Check_Score_When_Last_Frame_Is_Spare()
        {
            for (int i = 0; i < 10; i++)
            {
                game.Roll(5);
                game.Roll(5);
            }

            game.Roll(5);

            int score = game.Score();
            Assert.AreEqual(15, score);
        }

        [TestCase]
        public void Check_Score_When_Last_Frame_Is_Strike()
        {
            for (int i = 0; i < 10; i++)
            {
                game.Roll(10);
                game.Roll(0);
            }

            game.Roll(3);

            int score = game.Score();
            Assert.AreEqual(13, score);
        }
    }
}