namespace Parking;

public class ParkingSlot
{
    public int SlotNumber { get; }
    public Vehicle? ParkedVehicle { get; private set; }

    public ParkingSlot(int slotNumber)
    {
        SlotNumber = slotNumber;
    }

    public bool IsAvailable()
    {
        return ParkedVehicle == null;
    }

    public void ParkVehicle(Vehicle vehicle)
    {
        ParkedVehicle = vehicle;
    }

    public void Vacate()
    {
        ParkedVehicle = null;
    }
}
