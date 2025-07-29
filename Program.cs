using System;
using Parking;

public class Program
{
    private static ParkingLot? _parkingLot;

    public static void Main(string[] args)
    {
        while (true)
        {
            PrintMenu();
            var input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateParkingLot();
                    break;
                case 2:
                    ParkVehicle();
                    break;
                case 3:
                    Leave();
                    break;
                case 4:
                    _parkingLot?.Status();
                    break;
                case 5:
                    _parkingLot?.ReportSlotsFilled();
                    break;
                case 6:
                    _parkingLot?.ReportSlotsAvailable();
                    break;
                case 7:
                    _parkingLot?.ReportVehiclesByOddEvenPlate(true);
                    break;
                case 8:
                    _parkingLot?.ReportVehiclesByOddEvenPlate(false);
                    break;
                case 9:
                    ReportVehicleCountByType();
                    break;
                case 10:
                    ReportRegistrationNumbersByColor();
                    break;
                case 11:
                    ReportSlotNumbersByColor();
                    break;
                case 12:
                    FindSlotByRegistrationNumber();
                    break;
                case 13:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void PrintMenu()
    {
        Console.WriteLine();
        Console.WriteLine("--- Parking Lot Menu ---");
        Console.WriteLine("1. Create Parking Lot");
        Console.WriteLine("2. Park Vehicle");
        Console.WriteLine("3. Leave");
        Console.WriteLine("4. Status");
        Console.WriteLine("5. Report Filled Slots");
        Console.WriteLine("6. Report Available Slots");
        Console.WriteLine("7. Report Registration Numbers for Vehicles with Odd Plate");
        Console.WriteLine("8. Report Registration Numbers for Vehicles with Even Plate");
        Console.WriteLine("9. Report Vehicle Count by Type");
        Console.WriteLine("10. Report Registration Numbers by Color");
        Console.WriteLine("11. Report Slot Numbers by Color");
        Console.WriteLine("12. Find Slot by Registration Number");
        Console.WriteLine("13. Exit");
        Console.Write("Enter your choice: ");
    }

    private static void CreateParkingLot()
    {
        Console.Write("Enter capacity: ");
        if (int.TryParse(Console.ReadLine(), out int capacity))
        {
            _parkingLot = new ParkingLot(capacity);
        }
        else
        {
            Console.WriteLine("Invalid capacity.");
        }
    }

    private static void ParkVehicle()
    {
        if (_parkingLot == null)
        {
            Console.WriteLine("Please create a parking lot first.");
            return;
        }
        Console.Write("Enter registration number: ");
        var regNumber = Console.ReadLine();
        Console.Write("Enter color: ");
        var color = Console.ReadLine();
        Console.Write("Enter type (Mobil/Motor): ");
        var type = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(regNumber) && !string.IsNullOrWhiteSpace(color) && !string.IsNullOrWhiteSpace(type))
        {
            _parkingLot.Park(regNumber, color, type);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    private static void Leave()
    {
        if (_parkingLot == null)
        {
            Console.WriteLine("Please create a parking lot first.");
            return;
        }
        Console.Write("Enter slot number: ");
        if (int.TryParse(Console.ReadLine(), out int slotNumber))
        {
            _parkingLot.Leave(slotNumber);
        }
        else
        {
            Console.WriteLine("Invalid slot number.");
        }
    }

    private static void ReportVehicleCountByType()
    {
        if (_parkingLot == null)
        {
            Console.WriteLine("Please create a parking lot first.");
            return;
        }
        Console.Write("Enter vehicle type: ");
        var type = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(type))
        {
            _parkingLot.ReportVehicleCountByType(type);
        }
        else
        {
            Console.WriteLine("Invalid type.");
        }
    }

    private static void ReportRegistrationNumbersByColor()
    {
        if (_parkingLot == null)
        {
            Console.WriteLine("Please create a parking lot first.");
            return;
        }
        Console.Write("Enter color: ");
        var color = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(color))
        {
            _parkingLot.ReportRegistrationNumbersByColor(color);
        }
        else
        {
            Console.WriteLine("Invalid color.");
        }
    }

    private static void ReportSlotNumbersByColor()
    {
        if (_parkingLot == null)
        {
            Console.WriteLine("Please create a parking lot first.");
            return;
        }
        Console.Write("Enter color: ");
        var color = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(color))
        {
            _parkingLot.ReportSlotNumbersByColor(color);
        }
        else
        {
            Console.WriteLine("Invalid color.");
        }
    }

    private static void FindSlotByRegistrationNumber()
    {
        if (_parkingLot == null)
        {
            Console.WriteLine("Please create a parking lot first.");
            return;
        }
        Console.Write("Enter registration number: ");
        var regNumber = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(regNumber))
        {
            _parkingLot.FindSlotByRegistrationNumber(regNumber);
        }
        else
        {
            Console.WriteLine("Invalid registration number.");
        }
    }
}
