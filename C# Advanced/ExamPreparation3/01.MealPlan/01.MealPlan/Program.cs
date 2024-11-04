
Queue<string> meal = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries));
int mealCount = 0;

Stack<int> dailyCalories = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

while (true)
{
    string currentMial = meal.Dequeue();
    int currentMealCalories = 0;
    int currentDayCalorie = dailyCalories.Pop();


    if (currentDayCalorie == 0)
    {
        currentDayCalorie = dailyCalories.Pop();
    }

    if (currentMial == "salad")
    {
        currentMealCalories = 350;
        if (currentDayCalorie >= currentMealCalories)
        {
            currentDayCalorie -= currentMealCalories;
            mealCount++;
        }
        else if (currentDayCalorie < currentMealCalories)
        {
            currentMealCalories -= currentDayCalorie;
            if (dailyCalories.Count != 0)
            {
                currentDayCalorie = dailyCalories.Pop();
            }
            else
            {
                mealCount++;
                break;
            }
            currentDayCalorie -= currentMealCalories;
            mealCount++;
        }
    }
    if (currentMial == "soup")
    {
        currentMealCalories = 490;
        if (currentDayCalorie >= currentMealCalories)
        {
            currentDayCalorie -= currentMealCalories;
            mealCount++;
        }
        else if (currentDayCalorie < currentMealCalories)
        {
            currentMealCalories -= currentDayCalorie;
            if (dailyCalories.Count != 0)
            {
                currentDayCalorie = dailyCalories.Pop();
            }
            else
            {
                mealCount++;
                break;
            }
            currentDayCalorie -= currentMealCalories;
            mealCount++;
        }
    }
    if (currentMial == "pasta")
    {
        currentMealCalories = 680;
        if (currentDayCalorie >= currentMealCalories)
        {
            currentDayCalorie -= currentMealCalories;
            mealCount++;
        }
        else if (currentDayCalorie < currentMealCalories)
        {
            currentMealCalories -= currentDayCalorie;
            if (dailyCalories.Count != 0)
            {
                currentDayCalorie = dailyCalories.Pop();
            }
            else
            {
                mealCount++;
                break;
            }
            currentDayCalorie -= currentMealCalories;
            mealCount++;
        }
    }
    if (currentMial == "steak")
    {
        currentMealCalories = 790;
        if (currentDayCalorie >= currentMealCalories)
        {
            currentDayCalorie -= currentMealCalories;
            mealCount++;
        }
        else if (currentDayCalorie < currentMealCalories)
        {
            currentMealCalories -= currentDayCalorie;
            if (dailyCalories.Count != 0)
            {
                currentDayCalorie = dailyCalories.Pop();
            }
            else
            {
                mealCount++;
                break;
            }
            currentDayCalorie -= currentMealCalories;
            mealCount++;
        }
    }
    if (currentDayCalorie > 0)
    {
        dailyCalories.Push(currentDayCalorie);
    }
    if (meal.Count == 0 || dailyCalories.Count == 0)
    {
        break;
    }
}
if (meal.Count == 0 && dailyCalories.Count != 0)
{
    Console.WriteLine($"John had {mealCount} meals.");
    Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCalories)} calories.");
}
else if (meal.Count > 0)
{
    Console.WriteLine($"John ate enough, he had {mealCount} meals.");
    Console.WriteLine($"Meals left: {string.Join(", ", meal)}");
}

