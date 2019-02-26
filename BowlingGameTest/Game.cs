using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameTest
{
    public class Game
    {
        private int score = 0;
        private int[] rolls = new int[21];
        private int rollCount = 0;

        public void Roll(int pins)
        {
            rolls[rollCount] = pins;
            rollCount++;
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumInThisFrame(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int SumInThisFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }
    }
}
