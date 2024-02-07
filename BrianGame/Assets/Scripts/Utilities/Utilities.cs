using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // Use Unity's Random class if you're in a Unity project.


public static class Utilities
{
    private static System.Random random = new System.Random();
    public static List<T> Shuffle<T>(this List<T> list)
    {
        int n = list.Count;
        List<T> shuffledList = new List<T>(list);

        System.Random rand = new System.Random();

        for (int i = n - 1; i > 0; i--)
        {
            // Generate a random index between 0 and i (inclusive).
            int j = rand.Next(0, i + 1);

            // Swap elements at indices i and j.
            T temp = shuffledList[i];
            shuffledList[i] = shuffledList[j];
            shuffledList[j] = temp;
        }

        return shuffledList;
    }

    public static T GetRandomElement<T>(this List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            throw new ArgumentException("The list is null or empty.");
        }

        int randomIndex = random.Next(list.Count);
        return list[randomIndex];
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
