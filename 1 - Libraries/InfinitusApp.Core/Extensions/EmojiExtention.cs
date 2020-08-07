using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Extensions
{
    public static class EmojiExtention
    {
        private static List<string> EmojiHappy => new List<string>
                {
                    "😀",
                    "😁",
                    "😉",
                    "🤩",
                    "😄",
                    "🙂",
                    "🎉",
                    "😎",
                    "😍",
                    "😝",
                    "👏",
                    "🤙"
                };

        private static List<string> EmojiMoney => new List<string>
                {
                    "🤑",
                    "💰",
                    "💵",
                    "💲",
                };

        private static List<string> EmojiHappyAndMoney
        {
            get
            {
                var l = new List<string>();

                l.AddRange(EmojiHappy);
                l.AddRange(EmojiMoney);

                return l;
            }
        }

        public static string GetARandomEmojiHappy => EmojiHappy.PickRandom();

        public static string GetARandomEmojiMoney => EmojiMoney.PickRandom();

        public static string GetARandomEmojiHappyAndMoney => EmojiHappyAndMoney.PickRandom();
    }
}
