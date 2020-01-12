using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WizKids
{
    class Program
    {
        static readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";
        static void Main(string[] args)
        {
            Alternatives();
        }



        private static void FooBar()
        {
            for(int i = 1; i <= 100; ++i)
            {
                if(i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FooBar");
                } else if(i % 5 == 0)
                {
                    Console.WriteLine("Bar");
                } else if(i % 3 == 0)
                {
                    Console.WriteLine("Foo");
                } else
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static void ReplaceEmail()
        {
            string text = @"Christian has the email address christian+123@gmail.com.
                        Christian's friend, John Cave-Brown, has the email address john.cave-brown@gmail.com.
                        John's daughter Kira studies at Oxford University and has the email adress Kira123@oxford.co.uk.
                        Her Twitter handle is @kira.cavebrown.";
            // not entirelly sure if the first email is correct.
            Regex regex = new Regex("([a-zA-Z0-9\\.\\-!\\+]+@[a-zA-Z0-9]+\\.[a-zA-Z\\.]+)", RegexOptions.Multiline);
            string textReplaced = regex.Replace(text,"EMAIL FOUND");
            Console.WriteLine(textReplaced);
        }

        private static void Palindrome()
        {
            string palindrome = "ABBA";
            string notAPalindrome = "Paulo";

            // cut the spaces
            palindrome.Trim();
            bool flag = CheckPalindromeAux(palindrome);
            checkPalindromeFlag(flag);
            flag = false;

            // test
            notAPalindrome.Trim();
            flag = CheckPalindromeAux(notAPalindrome);
            checkPalindromeFlag(flag);
            
        }

        // 4.1
        // assuming that every alternative is correct even if it is not a word. 

        private static void Alternatives()
        {
            string word = "test";
            List<string> swapLetters = SwapLetters(word);

            //
            List<string> deletedLetters = DeleteLetters(word);
            //
            List<string> replacedLetters = ReplacingALetter(word);
        }


        private static List<string> SwapLetters(string word)
        {
            List<string> words = new List<string>();
            for(int i = 1; i < word.Length; i++)
            {
                char leftLetter = word[i - 1];

                var leftBuilder = new StringBuilder(word);
                leftBuilder.Insert(i+1, leftLetter);
                leftBuilder.Remove(i-1,1);
                words.Add(leftBuilder.ToString());
            }
            return words;
        }

        private static List<string> DeleteLetters(string word)
        {
            List<string> words = new List<string>();
            for(int i = 0; i < word.Length; i++)
            {
                string delWord = word;
                words.Add(delWord.Substring(i, 1));
            }
            return words;
        }

        private static List<string> InsertLetter(string word)
        {
            List<string> words = new List<string>();
            for(int i= 0; i < word.Length; i++)
            {

            }
            return words;
        }

        private static List<string> ReplacingALetter(string word)
        {
            List<string> words = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    var aStringBuilder = new StringBuilder(word);
                    aStringBuilder.Remove(i, 1);
                    aStringBuilder.Insert(i, alphabet[j]);
                    words.Add(aStringBuilder.ToString());

                }
            }
            return words;
        }


        /* AUX METHODS */


        private static void checkPalindromeFlag(bool flag)
        {
            if (flag)
            {
                Console.WriteLine("not a palindrome");
            }
            else
            {
                Console.WriteLine("palindrome");
            }
        }

        private static bool CheckPalindromeAux(string word)
        {
            bool flag = false;
            int middle = word.Length / 2;
            for (int i = 0; i < middle; i++)
            {
                if (word[i] != word[word.Length - i - 1]) { flag = true; }
            }
            return flag;
        }
    }
}
