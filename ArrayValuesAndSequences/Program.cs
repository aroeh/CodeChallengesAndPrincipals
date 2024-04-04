namespace DotnetPrincipals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FindNumberPattern();

            Console.ReadLine();
        }

        /// <summary>
        /// Goal is to enumerate through a collection identifying a single value that meets at least one of the following rules
        /// 1. Has 4 instances of the same value anywhere in the element
        /// 2. Has 3 consecutive instances of the same value in the element
        /// </summary>
        static void FindNumberPattern()
        {
            // static inputs
            string[] inputs = ["9088897541", "9087837541", "9077837547"];

            Dictionary<int, string> matchingValues = [];

            for (int i = 0; i < inputs.Length; i++)
            {
                bool has4 = HasFourValues(inputs[i]);
                bool has3InARow = HasThreeInARow(inputs[i]);

                if (has4 || has3InARow)
                {
                    matchingValues.Add(i, inputs[i]);
                }
            }

            Console.WriteLine("The following values matched at least one of the following rules");
            Console.WriteLine("1. There are 4 of the same character in the number");
            Console.WriteLine("2. There same character appears consecutively in the number at least 3 time: eg 111");
            Console.WriteLine(Environment.NewLine);
            foreach (var val in matchingValues)
            {
                Console.WriteLine(val.Value);
            }
        }

        /// <summary>
        /// The goal is to find 4 matching values in the element without using additional libraries like linq
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        static bool HasFourValues(string val)
        {
            bool has4 = false;

            // split the string into a char array for checking values
            char[] valArray = val.ToArray();

            // Track the value and number of times it appears in the value
            // The Key will represent the value
            // The Value will represent the count 
            Dictionary<char, int> valueCount = [];

            for (int i = 0; i < valArray.Length; i++)
            {
                // check if the Dictionary contains the key
                if (valueCount.ContainsKey(valArray[i]))
                {
                    // if the key is in the dictionary, then increment the value
                    valueCount[valArray[i]]++;
                }
                else
                {
                    // if the key is not in the dictionary then add with a value of 1
                    valueCount.Add(valArray[i], 1);
                }
            }

            // loop through the dictionary to determine if there are any elements with a value of at least 4
            foreach (var count in valueCount)
            {
                if (count.Value >= 4)
                {
                    has4 = true;
                }
            }

            return has4;
        }

        /// <summary>
        /// The goal here is to find 3 consecutive values in the element without using additional libraries like linq
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        static bool HasThreeInARow(string val)
        {
            bool has3InARow = false;

            // split the string into a char array for checking values
            char[] valArray = val.ToArray();

            // for tracking the number of instances in a sequence
            // increment if matches are found
            // reset to 0 if the current value does not match the previous value
            int sequenceCount = 1;

            // set an initial value to the first element
            // this should guarantee that sequenceCount should be incremented at the start
            char prevValue = valArray[0];

            for (int i = 0; i < valArray.Length; i++)
            {
                // check if the current iteration value matches the previous value and increment if a match
                if (valArray[i] == prevValue)
                {
                    sequenceCount++;
                }

                // check if the current iteration value does not matches the previous value then reset to 1
                if (valArray[i] != prevValue)
                {
                    sequenceCount = 1;
                }

                // if the count reaches 3, then set has3 to true and stop the loop
                if (sequenceCount == 3)
                {
                    has3InARow = true;
                    break;
                }

                // set the previous value before the next iteration starts
                prevValue = valArray[i];
            }

            return has3InARow;
        }
    }
}
