using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

// for changing the speed dynamically
// use {speed=FLOAT} in the lines string to change the dialogue speed from that point
public static class DialogueSpeed
{
    private static readonly Regex speedRegex = new Regex(@"\{speed=(.*?)\}");
    public static List<(char, float)> Parse(string line, float defaultSpeed)
    {
        List<(char, float)> parsedText = new List<(char, float)>();
        float currentSpeed = defaultSpeed;
        int i = 0;

        while (i < line.Length)
        {
            if (line[i] == '{' && line.Substring(i).StartsWith("{speed="))
            {
                int end = line.IndexOf('}', i);
                if (end != 1)
                {
                    string speedValue = line.Substring(i + 7, end - (i + 7));
                    if (float.TryParse(speedValue, out float newSpeed))
                    {
                        currentSpeed = newSpeed;
                    }
                    i = end + 1;
                    continue;
                }
            }

            parsedText.Add((line[i], currentSpeed));
            i++;
        }

        return parsedText;
    }

    // Cleans the tags in dialogue so that they wont appear in runtime
    public static string RemoveTags(string line)
    {
        return speedRegex.Replace(line, "");
    }
}
