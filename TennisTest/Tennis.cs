using System;
using System.Collections.Generic;

namespace TennisTest
{
    public class Tennis
    {
        private readonly string _firstPlayerName;
        private readonly string _secondPlayerName;
        private int _firstPlayerScoreTimes;

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0,"Love" },
            {1,"Fifteen" },
            {2,"Thirty" },
            {3,"Forty" }
        };

        private int _secondPlayerScoreTimes;

        public Tennis(string firstPlayerName, string secondPlayerName)
        {
            _firstPlayerName = firstPlayerName;
            _secondPlayerName = secondPlayerName;
        }

        public string Score()
        {
            if (IsScoreDiff())
            {
                if (IsReadyForGamePoint())
                {
                    return AdvStatus();
                }

                return ScoreLookup();
            }
            if (IsDecue())
            {
                return Deuce();
            }
            return SameScore();
        }

        private string AdvStatus()
        {
            return IsAdv() ? $"{AdvPlayer()} Adv" : $"{AdvPlayer()} Win";
        }

        private bool IsAdv()
        {
            return Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) == 1;
        }

        private bool IsReadyForGamePoint()
        {
            return _firstPlayerScoreTimes > 3 || _secondPlayerScoreTimes > 3;
        }

        private string AdvPlayer()
        {
            return _firstPlayerScoreTimes > _secondPlayerScoreTimes
                ? _firstPlayerName
                : _secondPlayerName;
        }

        private string SameScore()
        {
            return $"{_scoreLookup[_firstPlayerScoreTimes]} All";
        }

        private static string Deuce()
        {
            return "Deuce";
        }

        private bool IsDecue()
        {
            return _firstPlayerScoreTimes >= 3 && _firstPlayerScoreTimes == _secondPlayerScoreTimes;
        }

        private string ScoreLookup()
        {
            return $"{_scoreLookup[_firstPlayerScoreTimes]} {_scoreLookup[_secondPlayerScoreTimes]}";
        }

        private bool IsScoreDiff()
        {
            return _firstPlayerScoreTimes != _secondPlayerScoreTimes;
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScoreTimes++;
        }

        public void SecondPlayerScore()
        {
            _secondPlayerScoreTimes++;
        }
    }
}