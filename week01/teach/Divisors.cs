public static class Divisors {
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run() {
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}"); // <List>{1, 2, 4, 5, 8, 10, 16, 20, 40}
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); // <List>{1}
    }

    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisor</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number) {
       
        List<int> results = new();

        if (number <= 1)
        {
            return results;
        }

        // STEP 2: Iterate through all candidate numbers starting from 1 up to (number - 1).
        // Note: The loop excludes the number itself per requirements.
        for (int i = 1; i < number; i++)
        {
            // STEP 3: Test divisibility using the modulo operator (%).
            // If 'number % i == 0', then 'i' divides 'number' evenly with no remainder.
            if (number % i == 0)
            {
                // STEP 4: Add the valid divisor to the results list.
                results.Add(i);
            }
        }

        // STEP 5: Return the populated list of proper divisors.    
        return results;
    }
}