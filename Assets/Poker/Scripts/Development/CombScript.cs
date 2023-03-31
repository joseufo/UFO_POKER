using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombScript : MonoBehaviour
{
    public string[] arr;
    public int k;

    private List<List<string>> combinations;

    void Start()
    {
        combinations = GenerateCombinations(arr, k);
        Debug.Log(combinations.Count);
        foreach (var combo in combinations)
        {
            Debug.Log(string.Join(" ", combo));
        }
    }

    public static List<List<string>> GenerateCombinations(string[] arr, int k)
    {
        var result = new List<List<string>>();

        if (k > arr.Length)
        {
            return result;
        }

        // Initialize the first combination with indexes in ascending order
        var combination = new List<int>();
        for (int i = 0; i < k; i++)
        {
            combination.Add(i);
        }

        while (combination.Count > 0)
        {
            // Generate the current combination
            var current = new List<string>();
            foreach (int index in combination)
            {
                current.Add(arr[index]);
            }
            result.Add(current);

            // Find the rightmost element that can be incremented
            int i = k - 1;
            while (i >= 0 && combination[i] == arr.Length - k + i)
            {
                i--;
            }

            if (i < 0)
            {
                // No more combinations
                break;
            }

            // Increment the element
            combination[i]++;

            // Set all following elements to the value of their previous neighbor plus 1
            for (int j = i + 1; j < k; j++)
            {
                combination[j] = combination[j - 1] + 1;
            }
        }

        return result;
    }
}