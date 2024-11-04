using System;

namespace _09._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysToStay = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string assessment = Console.ReadLine();
            double singleRoomPrice = 18 * (daysToStay - 1);
            double apartmentPrice = 25 * (daysToStay - 1);
            double presidentApartmentPrace = 35 * (daysToStay-1);
            if (daysToStay < 10)
            {
                if (typeOfRoom == "apartment")
                {
                    apartmentPrice = apartmentPrice * 0.70;
                    if (assessment == "positive")
                    {
                        apartmentPrice = apartmentPrice + (apartmentPrice * 0.25);
                        Console.WriteLine($"{apartmentPrice:F2}");
                    }
                    else if (assessment == "negative")
                    {
                        apartmentPrice = apartmentPrice * 0.9;
                        Console.WriteLine($"{apartmentPrice:F2}");
                    }
                }
                else if (typeOfRoom == "president apartment")
                {
                    presidentApartmentPrace = presidentApartmentPrace * 0.90;
                    if (assessment == "positive")
                    {
                        presidentApartmentPrace = presidentApartmentPrace + (presidentApartmentPrace * 0.25);
                        Console.WriteLine($"{presidentApartmentPrace:F2}");
                    }
                    else if (assessment == "negative")
                    {
                        presidentApartmentPrace = presidentApartmentPrace * 0.9;
                        Console.WriteLine($"{presidentApartmentPrace:F2}");
                    }
                }
                else if (typeOfRoom == "room for one person")
                {
                    if (assessment == "positive")
                    {
                        singleRoomPrice = singleRoomPrice + (singleRoomPrice * 0.25);
                        Console.WriteLine($"{singleRoomPrice:F2}");
                    }
                    else if (assessment == "negative")
                    {
                        singleRoomPrice = singleRoomPrice * 0.90;
                        Console.WriteLine($"{singleRoomPrice:F2}");
                    }

                }
            }
            else if (daysToStay >= 10 && daysToStay <= 15)
            {
                if (typeOfRoom == "apartment")
                {
                    apartmentPrice = apartmentPrice * 0.65;
                    if (assessment=="positive")
                    {
                        apartmentPrice = apartmentPrice + (apartmentPrice * 0.25);
                        Console.WriteLine($"{apartmentPrice:F2}");
                    }
                    else if (assessment=="negative")
                    {
                        apartmentPrice = apartmentPrice * 0.90;
                        Console.WriteLine($"{apartmentPrice:F2}");
                    }
                }
                else if (typeOfRoom == "president apartment")
                {
                    presidentApartmentPrace = presidentApartmentPrace * 0.85;
                    if (assessment == "positive")
                    {
                        presidentApartmentPrace = presidentApartmentPrace + (presidentApartmentPrace * 0.25);
                        Console.WriteLine($"{presidentApartmentPrace:F2}");
                    }
                    else if (assessment=="negative")
                    {
                        presidentApartmentPrace = presidentApartmentPrace * 0.90;
                        Console.WriteLine($"{presidentApartmentPrace:F2}");
                    }
                }
                else if (typeOfRoom== "room for one person")
                {
                    if (assessment == "positive")
                    {
                        singleRoomPrice = singleRoomPrice + (singleRoomPrice * 0.25);
                        Console.WriteLine($"{singleRoomPrice:F2}");
                    }
                    else if (assessment == "negative")
                    {
                        singleRoomPrice = singleRoomPrice * 0.90;
                        Console.WriteLine($"{singleRoomPrice:F2}");
                    }
                }
            }
            else if (daysToStay > 15)
            {
                if (typeOfRoom == "apartment")
                {
                    apartmentPrice = apartmentPrice * 0.50;
                    if (assessment=="positive")
                    {
                        apartmentPrice = apartmentPrice + (apartmentPrice * 0.25);
                        Console.WriteLine($"{apartmentPrice:F2}");
                    }
                    else if (assessment=="negative")
                    {
                        apartmentPrice = apartmentPrice * 0.90;
                        Console.WriteLine($"{apartmentPrice:F2}");
                    }
                }
                else if (typeOfRoom == "president apartment")
                {
                    presidentApartmentPrace = presidentApartmentPrace * 0.80;
                    if(assessment == "positive")
                    {
                        presidentApartmentPrace = presidentApartmentPrace + (presidentApartmentPrace * 0.25);
                        Console.WriteLine($"{presidentApartmentPrace:F2}");
                    }
                    else if (assessment == "negative")
                    {
                        presidentApartmentPrace = presidentApartmentPrace * 0.90;
                        Console.WriteLine($"{presidentApartmentPrace:F2}");
                    }
                }
                else if (typeOfRoom == "room for one person")
                {
                    if (assessment == "positive")
                    {
                        singleRoomPrice = singleRoomPrice + (singleRoomPrice * 0.25);
                        Console.WriteLine($"{singleRoomPrice:F2}");
                    }
                    else if (assessment == "negative")
                    {
                        singleRoomPrice = singleRoomPrice * 0.90;
                        Console.WriteLine($"{singleRoomPrice:F2}");
                    }
                }
            }
        }
    }
}
