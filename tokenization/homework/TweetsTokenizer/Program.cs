using System;
using System.Collections.Generic;

namespace TweetsTokenizer
{
    class Program
    {
        static List<string>[] Tokenizer(string tweet)
        {
            int i = 0;
            string current = "";
            List<string> usernames = new List<string>();
            List<string> hashtags = new List<string>();

            while (i < tweet.Length)
            {
                if (tweet[i] == '#')
                {
                    current += "#" + tweet[++i];
                    while (i < tweet.Length - 1 && Char.IsLetterOrDigit(tweet[i]) || tweet[i] == '_')
                    {
                        current += tweet[++i];
                    }

                    if (current.Length > 2) // hashtags must be at least 2 characters long
                    {
                        hashtags.Add(current);
                        current = "";
                    }
                    
                } if (tweet[i] == '@')
                {
                    current += "@" + tweet[++i];
                    while (i < tweet.Length - 1 && current.Length < 15 && Char.IsLetterOrDigit(tweet[i]) || tweet[i] == '_')
                    {
                        current += tweet[++i];
                    }

                    if (current.Length > 4) // usernames must be at least 4 characters long
                    {
                       usernames.Add(current);
                       current = ""; 
                    }
                    
                }
                
                i++;
            }
            
            return new List<string>[]{hashtags, usernames};
        }


        static void Main(string[] args)
        {
            string test_tweet =
                @"في كل موسم نرسم طريقا للأمل، تروي شخصياتنا جوانب ملهمة من القصة، ولا تزال قصصنا تتواصل؛ لتروي حصريا حكايات لن تشاهدها إلا في #اللقاء
                تابعونا على  #MBC1 في رمضان 
                @Mofeed_n
                #رمضان_يجمعنا
                ";
            List<string>[] result = Tokenizer(test_tweet);
            Console.WriteLine($"Number of hashtags in tweet: {result[0].Count}");
            foreach (var s in result[0])
            {
                Console.WriteLine(s);
            }

            Console.WriteLine($"Number of usernames in tweet: {result[1].Count}");
            foreach (var s in result[1])
            {
                Console.WriteLine(s);
            }
        }
    }
}