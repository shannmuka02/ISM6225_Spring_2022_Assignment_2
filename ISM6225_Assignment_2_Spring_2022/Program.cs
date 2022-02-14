/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Collections.Generic;

namespace Shannmuka
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {


                int low, high;

                low = 0;
                high = nums.Length - 1;

                int mid = (low + high) / 2;         // get the mid value
                while (low <= high)
                {       // run within low and high

                    if (nums[mid] > target)          // our target is less than where we are, then search left 
                        high = mid - 1;

                    else if (nums[mid] < target)       // our target is greater than where we are, then search right 
                        low = mid + 1;

                    if (nums[mid] == target)         // return the mid when we found the target
                        return mid;

                    mid = (low + high) / 2;            // get the mid value
                }
                // if target not found, then return low/high based on where the mid is
                if (target < nums[mid])
                    return high;
                return low;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                // trim string of punctuations. ALso make the paragraph lower case
                paragraph = paragraph.Replace(".", "");
                paragraph = paragraph.Replace(",", "");
                paragraph = paragraph.ToLower();

                string[] sa = paragraph.Split();                // split the string into string array


                Dictionary<string, int> fd = new Dictionary<string, int>();         // dictionary with values as frequency and keys as strings

                for (int i = 0; i < sa.Length; i++)
                {
                    if (Array.IndexOf(banned, sa[i]) == -1)
                    {     // checks if the word is banned or not
                        if (fd.ContainsKey(sa[i]) == true)
                            fd[sa[i]] += 1;                                         // increment the frequency counter if presnet else, just add it.
                        else
                            fd.Add(sa[i], 1);
                    }
                }
                string fin = "";
                int maxcnter = -1;



                foreach (KeyValuePair<string, int> temp in fd)
                {         // iterate through the dictionary
                    if (temp.Value >= maxcnter)
                    {                        // if the curr value is greater than maxcnter then update it and fin
                        fin = temp.Key;
                        maxcnter = temp.Value;
                    }
                }
                return fin;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {

                Dictionary<int, int> fd = new Dictionary<int, int>();   // dict for keeping track of frequency of numbers

                for (int i = 0; i < arr.Length; i++)
                {   // populate the dictionary

                    if (fd.ContainsKey(arr[i]) == false)
                    {
                        fd.Add(arr[i], 1);
                    }
                    else
                    {
                        fd[arr[i]] += 1;
                    }

                }

                int result = -1;


                foreach (KeyValuePair<int, int> temp in fd)
                {

                    if (temp.Value == temp.Key)
                    {         // if val and key match, its a lucky number 
                        if (result < temp.Key)           // we check if it s greater than the one we already have and update it if needd
                            result = temp.Key;
                    }

                }
                return result;       // return the number
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int length = secret.Length;


                Dictionary<char, int> fd = new Dictionary<char, int>();  // frequency storing dictionary

                for (int i = 0; i < length; i++)
                {       // map the elements to their counts

                    if (fd.ContainsKey(secret[i]) == false)
                    {
                        fd.Add(secret[i], 1);
                    }
                    else
                    {
                        fd[secret[i]] += 1;
                    }

                }

                int b, c;
                b = 0;
                c = 0;

                for (int i = 0; i < length; i++)
                {           // this loop checks adn counts the bulls

                    if (secret[i] == guess[i])
                    {
                        b++;
                        fd[guess[i]] -= 1;          // decrement the freq in fd
                    }
                }

                for (int i = 0; i < length; i++)
                {             // this loop checks and counts the number of cows

                    if (secret[i] != guess[i])
                    {

                        if (fd.ContainsKey(guess[i]) == true)
                        {               // if char is present in secret but in wrong position in guess, then increment c
                            if (fd[guess[i]] > 0)
                                c++;
                        }

                    }
                }
                string bs = b.ToString() + "A";
                string cs = c.ToString() + "B";
                return bs + cs;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                List<int> final_list = new List<int>();
                int len = s.Length;
                int partition = 0;

                Dictionary<char, int> fd = new Dictionary<char, int>();    // dictionary for storing last position of chars 

                int last = 0;  // helps calculate size

                for (int i = 0; i < len;)
                {

                    char starting = s[i];  // stores the starting char for this partittion

                    for (int j = i; j < len; j++)
                    {

                        if (fd.ContainsKey(s[j]) == true)
                        {
                            if (fd[s[j]] <= partition || s[j] == starting)   // checks if the char already occured in this partition before,
                                partition = j;        // extend the partition limit
                            fd[s[j]] = j;
                        }
                        else
                        {
                            fd.Add(s[j], j);         // add to the dictionary
                        }

                    }
                    int add = partition + 1;
                    if (i != 0)
                        add = add - last;           // calculates the size of the partition
                    final_list.Add(add);                // add to the list final list
                    i = partition + 1;                 // change the value of i to new partition's first index
                    last = partition + 1;
                }
                return final_list;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.



         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {

                Dictionary<char, int> fd = new Dictionary<char, int>();      // dictionary for mapping letters to pixels

                for (int i = 0; i < widths.Length; i++)      // populate the dictionary
                    fd.Add((char)((int)'a' + i), widths[i]);


                int val, lin;
                val = lin = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (i == 0) lin++;
                    if (val + fd[s[i]] > 100)
                    {       // exceeding 100 pixels per line limit
                        val = fd[s[i]];             // soo increment the line and just refill hte val
                        lin++;
                    }
                    else
                        val += fd[s[i]];	        // within limit, so just add it
                }

                return new List<int>() { lin, val };
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {

                int len = bulls_string10.Length;
                // these variables keep track of the opening and closing brackets incrementing when open, decrementing when close
                int v1, v2, v3;
                v1 = 0;
                v2 = 0;
                v3 = 0;

                // if we come across an open bracket, then increment the counter, or else just decrement. IF at end, the value is 0, then it's balanced

                for (int i = 0; i < len; i++)
                {
                    if (bulls_string10[i] == '(')            // increment
                        v1++;
                    else if (bulls_string10[i] == ')')       // decrement
                        v1--;
                    else if (bulls_string10[i] == '[')           // increment
                        v2++;
                    else if (bulls_string10[i] == ']')           // ddecrement
                        v2--;
                    else if (bulls_string10[i] == '{')           // increment
                        v3++;
                    else if (bulls_string10[i] == '}')       // decremtn
                        v3--;
                }

                if (v3 == 0 && v1 == 0 && v2 == 0)
                {       // if all vals are 0, then the string is valid or else invalid 
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {

                // write the morse codes for all letters
                string[] mco = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };



                Dictionary<char, string> md = new Dictionary<char, string>();      // dictionary for mapping chars to morse codees

                for (int i = 0; i < mco.Length; i++)
                {     // populate the dictionary
                    md.Add((char)((int)'a' + i), mco[i]);
                }


                // dict for uniq morse codes

                Dictionary<string, int> nd = new Dictionary<string, int>();


                for (int i = 0; i < words.Length; i++)
                {

                    string word = words[i].ToLower();   // lowercase


                    string temp = "";

                    for (int j = 0; j < word.Length; j++)    // get the morse code for the final word using individual chars
                        temp += md[word[j]];


                    if (nd.ContainsKey(temp) == true)        // nd keeps track of all the morse codes and the keys of nd give the transformations
                        nd[temp] += 1;
                    else
                        nd.Add(temp, 1);

                }

                return nd.Count;  // count return the numbr of keys
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                // Approach : Binary search + BFS

                int n = grid.Length; // get the length of the grid (n x n) 
                int size = (int)Math.Sqrt(n);  // get n 
                int first, last;        // define variables for binary searching the values in the grid: boundaries
                first = grid[0, 0];         // the low value is the starting value
                last = (size * size) - 1;             // the high value is the highest val possible in the grid
                int result = -1;            // result variable for finally storing the result
                while (first <= last)
                {          // start binary seach
                    int mid = (first + last) / 2;   // get the mid val
                    bool ispath = false;        // declare a var for knowing whether there will be a path from (0,0) to (n-1,n-1) with the current mid as depth

                    int[] a = new int[2] { -0, -1 };   // initializing the possible directions we can traverse: up, down, left, right
                    int[] b = new int[2] { 1, 0 };
                    int[] c = new int[2] { 0, 1 };
                    int[] ds = new int[2] { -1, 0 };
                    int[][] dir = new int[][] { a, b, c, ds };  // store them in a jagged array (but uniform in this case)
                    Queue<Tuple<int, int>> points_q = new Queue<Tuple<int, int>>();  // declare a tuple queue for storing neighbouring points when we perform BFS
                    points_q.Enqueue(Tuple.Create(0, 0));        // first point being the grid[0][0]
                    bool[][] visited = new bool[size][];       // declare visited array
                    for (int i = 0; i < size; i++)
                        visited[i] = new bool[size];
                    visited[0][0] = true;       // make first node visited
                    int f = 0;          // flag for when to break out of loop :  0 - path not found,  1 - because, path found
                    while (points_q.Count > 0)
                    {          // while the queue has neighbours
                        int neighbours = points_q.Count;
                        for (int i = 0; i < neighbours; i++)
                        {       // for all neighbours 
                            var pnt = points_q.Dequeue();       // pop the next point
                            int X = pnt.Item1;          // get the co-ordinates
                            int Y = pnt.Item2;

                            if (X == size - 1 && Y == size - 1)
                            {  // if we reach the end point, then make ispath true and f=1, and break;
                                ispath = true;
                                //Console.WriteLine("SD");
                                f = 1;
                                break;
                            }
                            foreach (var d in dir)
                            {   // add the neighbours in all respective directions to the queue
                                int nX = X + d[0];
                                int nY = Y + d[1];
                                if (nX >= 0 && nX < size && nY >= 0 && nY < size && !visited[nX][nY] && grid[nX, nY] <= mid)
                                {  // boundary conditions, check if already visited, and make sure the next nodes' height atmost mid:(depth)
                                    points_q.Enqueue(Tuple.Create(nX, nY));  // add to queue
                                    visited[nX][nY] = true;     // make it visited
                                }
                            }
                        }
                        if (f == 1)      // if we break out due to path being found
                            break;
                    }
                    if (f == 0)            // meaning: path not found
                        ispath = false;

                    if (ispath)
                    {   // path found case:
                        result = mid;           // store the current depth in result
                        last = mid - 1;         // for checking if any other depth which is minimum has path. : so trim the search space acc. to binary search
                    }
                    else            // path not found case:
                        first = mid + 1;        // trim the search space
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                int wl1 = word1.Length;                    // get respective lengths
                int wl2 = word2.Length;
                //Dynamic programming : bottom up approach

                int[,] dp = new int[wl1 + 1, wl2 + 1];

                for (int i = 0; i <= wl1; i++)
                {              // this loop and the inner loop start filling the DP array from bottom up

                    for (int j = 0; j <= wl2; j++)
                    {

                        if (i == 0 && j == 0)            // case 1 : i=0,j=0 meaning string lens are 0, so dp[i,j] = 0
                            dp[i, j] = 0;
                        else if (i == 0)                 // case 2 : i = 0 meaning j insert operations min req for changing w1 to w2
                            dp[i, j] = j;
                        else if (j == 0)                 // case 3 : j = 0 meaning i remove operations min req for changing w1 to w2
                            dp[i, j] = i;
                        else if (word1[i - 1] == word2[j - 1])  // case 4: if last chars same, then meaning dp[i-1,j-1]
                            dp[i, j] = dp[i - 1, j - 1];
                        else                               //case 5: get the minimum value from doing all the three ops on word1 for i,j
                            dp[i, j] = 1 + Math.Min(dp[i - 1, j], Math.Min(dp[i - 1, j - 1], dp[i - 1, j]));
                    }
                }
                // return the respective min operations for word1 and word2
                return dp[wl1, wl2];
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
