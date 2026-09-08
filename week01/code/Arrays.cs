public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.


        // Create an array of doubles with the specified length, this will hold the multiples of the number
        // will be used to store the multiples of the number and returned at the end of the function
        double[] result = new double[length];

        // Loop through the array from 0 to length - 1
        // For each index, calculate the multiple of the number by multiplying the number by (index + 1)
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        // Return the array of multiples
        return result ?? []; // if the result is null, return an empty array instead
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Check if the data is null, has 1 or fewer elements, or if the amount is a multiple of the data count
        // If any of these conditions are true, return early as no rotation is needed
        if (data == null || data.Count <= 1 || amount % data.Count == 0)
        {
            return;
        }

        // Calculate the effective amount to rotate by using modulo operation
        // This handles cases where the amount is greater than the size of the list
        int effectiveAmount = amount % data.Count;
        // Calculate the index where the list will be split for rotation
        // The split index is determined by subtracting the effective amount from the total count of the list
        int splitIndex = data.Count - effectiveAmount;
        // Create a new list to hold the elements that will be moved to the front of the list
        List<int> tailSlice = data.GetRange(splitIndex, effectiveAmount);
        // Remove the elements from the original list that are being moved to the front
        data.RemoveRange(splitIndex, effectiveAmount);
        // Insert the elements from the tailSlice at the beginning of the original list
        // This effectively rotates the list to the right by the specified amount
        data.InsertRange(0, tailSlice);
    }
}
