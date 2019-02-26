using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTest
{
 

    /// <summary>
    ///1[4]|4[5]|6/|5◢| ■|0[1]|7◢|6◢|■  |2◢6
    ///  5 |  14|29|49|60| 61 |77|97|117|133
    /// role
    /// 1場保齡球共用十局
    /// 前9局每局有2個球數
    /// 每局共用10個球瓶
    /// 每局的分數為當局擊倒瓶數加上Bonus
    /// 每局第一球全倒下strike
    /// 每局第二球才全倒稱為spare
    /// 第十局如果有strike或spare就可以打第三球
    ///
    /// Bonus
    /// Spare-下一球擊倒的瓶數
    /// Strike-下兩球擊倒的瓶數
    /// 第十局沒有bonus
    /// </summary>
    [TestClass]
    public class BowlingGameTest
    {
        private Game _game = new Game();

        [TestMethod]
        public void testAllZeros()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, _game.Score());
        }

        [TestMethod]
        public void testAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, _game.Score());
        }

        [TestMethod]
        public void testOneSpare()
        {
            rollSpare();
            _game.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, _game.Score());
        }

        [TestMethod]
        public void testOneStrike()
        {
            rollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, _game.Score());
        }

        [TestMethod]
        public void testPerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, _game.Score());
        }

        private void rollStrike()
        {
            _game.Roll(10);
        }

        private void rollSpare()
        {
            _game.Roll(3);
            _game.Roll(7);
        }

        private void RollMany(int n, int points)
        {
            for (int j = 0; j < n; j++)
            {
                _game.Roll(points);
            }
        }
    }
}
