using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking;

public class ParkingLot
{
    private List<ParkingSlot> _slots;

    public ParkingLot(int capacity)
    {
        _slots = new List<ParkingSlot>(capacity);
        for (int i = 1; i <= capacity; i++)
        {
            _slots.Add(new ParkingSlot(i));
        }
        Console.WriteLine($"Created a parking lot with {capacity} slots");
    }

    public void Park(string registrationNumber, string color, string type)
    {
        if (type != "Mobil" && type != "Motor")
        {
            Console.WriteLine("Sorry, we only accept Mobil and Motor.");
            return;
        }

        var availableSlot = _slots.FirstOrDefault(s => s.IsAvailable());
        if (availableSlot != null)
        {
            var vehicle = new Vehicle(registrationNumber, color, type);
            availableSlot.ParkVehicle(vehicle);
            Console.WriteLine($"Allocated slot number: {availableSlot.SlotNumber}");
        }
        else
        {
            Console.WriteLine("Sorry, parking lot is full");
        }
    }

    public void Leave(int slotNumber)
    {
        var slot = _slots.FirstOrDefault(s => s.SlotNumber == slotNumber);
        if (slot != null && !slot.IsAvailable())
        {
            slot.Vacate();
            Console.WriteLine($"Slot number {slotNumber} is free");
        }
        else
        {
            Console.WriteLine($"Slot number {slotNumber} is already empty or does not exist.");
        }
    }

    public void Status()
    {
        Console.WriteLine("Slot No. Type      Registration No Colour");
        foreach (var slot in _slots.Where(s => !s.IsAvailable()))
        {
            var vehicle = slot.ParkedVehicle;
            if (vehicle != null)
            {
                 Console.WriteLine($"{slot.SlotNumber,-8} {vehicle.Type,-9} {vehicle.RegistrationNumber,-15} {vehicle.Color}");
            }
        }
    }

    public void ReportSlotsFilled()
    {
        Console.WriteLine($"Filled slots: {_slots.Count(s => !s.IsAvailable())}");
    }

    public void ReportSlotsAvailable()
    {
        Console.WriteLine($"Available slots: {_slots.Count(s => s.IsAvailable())}");
    }

    public void ReportVehiclesByOddEvenPlate(bool isOdd)
    {
        var vehicles = _slots.Where(s => !s.IsAvailable() && s.ParkedVehicle != null)
                             .Select(s => s.ParkedVehicle!);

        var filteredVehicles = vehicles.Where(v => {
            var parts = v.RegistrationNumber.Split('-');
            if (parts.Length < 2 || string.IsNullOrEmpty(parts[1]))
            {
                return false; // Skip if format is not as expected
            }
            var lastChar = parts[1].LastOrDefault();
            if (!char.IsDigit(lastChar))
            {
                return false; // Skip if the last character is not a digit
            }
            var lastDigit = lastChar - '0';
            return isOdd ? lastDigit % 2 != 0 : lastDigit % 2 == 0;
        });

        Console.WriteLine(string.Join(", ", filteredVehicles.Select(v => v.RegistrationNumber)));
    }

     public void ReportVehicleCountByType(string type)
    {
        var count = _slots.Count(s => !s.IsAvailable() && s.ParkedVehicle?.Type == type);
        Console.WriteLine(count);
    }

    public void ReportRegistrationNumbersByColor(string color)
    {
        var registrationNumbers = _slots.Where(s => !s.IsAvailable() && s.ParkedVehicle?.Color.Equals(color, StringComparison.OrdinalIgnoreCase) == true)
                                        .Select(s => s.ParkedVehicle!.RegistrationNumber);
        Console.WriteLine(string.Join(", ", registrationNumbers));
    }

    public void ReportSlotNumbersByColor(string color)
    {
        var slotNumbers = _slots.Where(s => !s.IsAvailable() && s.ParkedVehicle?.Color.Equals(color, StringComparison.OrdinalIgnoreCase) == true)
                                .Select(s => s.SlotNumber.ToString());
        Console.WriteLine(string.Join(", ", slotNumbers));
    }

    public void FindSlotByRegistrationNumber(string registrationNumber)
    {
        var slot = _slots.FirstOrDefault(s => !s.IsAvailable() && s.ParkedVehicle?.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase) == true);
        if (slot != null)
        {
            Console.WriteLine(slot.SlotNumber);
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }
}
