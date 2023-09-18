using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // Use Unity's Random class if you're in a Unity project.


public static class Utilities
{
    public static List<T> Shuffle<T>(this List<T> list)
    {
        int n = list.Count;
        List<T> shuffledList = new List<T>(list); // Create a new list to hold the shuffled elements.

        for (int i = n - 1; i > 0; i--)
        {
            // Generate a random index between 0 and i (inclusive).
            int j = Random.Range(0, i + 1);

            // Swap elements at indices i and j.
            T temp = shuffledList[i];
            shuffledList[i] = shuffledList[j];
            shuffledList[j] = temp;
        }

        return shuffledList;
    }

    public static List<char> ShffleCharFromString(this string input)
    {
        List<char> charList = new List<char>(input.ToCharArray());
        return charList.Shuffle();
    }

    public static int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max+1);
    }
}
