using Microsoft.AspNetCore.Mvc;
using System;

public class WheelController : ControllerBase
{
    private readonly Random _random = new Random();

    [HttpPost("getWheelValues")]
    public IActionResult GetWheelValues([FromBody] UserRequestModel request)
    {
        DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

        if (currentTime.Minute % 2 == 0)
        {
            // Logic to return a set of random integers in dollars between $0 and $500
            var numberOfSegments = /* Determine the number of segments based on your wheel */;
            var randomValues = GenerateRandomValues(numberOfSegments);
            return Ok(randomValues);
        }
        else
        {
            // Return a suitable response indicating the wheel may not be spun on odd-numbered minutes
            return Ok("Wheel may not be spun on odd-numbered minutes.");
        }
    }

    [HttpPost("spinWheel")]
    public IActionResult SpinWheel([FromBody] UserRequestModel request)
    {
        DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

        if (currentTime.Minute % 3 == 0)
        {
            // Throw an exception for spinning the wheel on minutes divisible by 3
            throw new InvalidOperationException("Wheel should not be spun on minutes divisible by 3.");
        }
        else
        {
            // Return a random prize for the wheel
            var randomPrize = GetRandomPrize();
            return Ok(new { Prize = randomPrize });
        }
    }

    private int[] GenerateRandomValues(int numberOfSegments)
    {
        // Logic to generate random values in dollars between $0 and $500
        int[] values = new int[numberOfSegments];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = _random.Next(501); // Generates values between 0 and 500
        }

        // Randomize the order of values
        ShuffleArray(values);

        return values;
    }

    private void ShuffleArray<T>(T[] array)
    {
        // Logic to shuffle the array (Fisher-Yates algorithm)
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = _random.Next(0, i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    private int GetRandomPrize()
    {
        // Logic to return a random prize (one of the $ amounts)
        int[] prizes = new int[] { /* List of $ amounts */ };
        return prizes[_random.Next(prizes.Length)];
    }
}

