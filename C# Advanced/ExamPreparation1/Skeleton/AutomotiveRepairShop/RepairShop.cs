using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; }

        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public string AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count <= Capacity)
            {
                Vehicles.Add(vehicle);
            }
            return Vehicles.Count.ToString();
        }
        public bool RemoveVehicle(string vin)
        {
            Vehicle vehicleToRemove = Vehicles.FirstOrDefault(v => v.VIN == vin);
            if (vehicleToRemove != null)
            {
                Vehicles.Remove(vehicleToRemove);
                return true;
            }
            return false;
        }
        public int GetCount()
        {
            return Vehicles.Count;
        }

        public Vehicle GetLowestMileage()
        {
            if (Vehicles.Count == 0)
            {
                return null;
            }

            Vehicle vehicleWithLowestMileage = Vehicles[0];
            foreach (var vehicle in Vehicles)
            {
                if (vehicle.Mileage < vehicleWithLowestMileage.Mileage)
                {
                    vehicleWithLowestMileage = vehicle;
                }
            }
            return vehicleWithLowestMileage;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the repair shop:");

            foreach (var vehicle in Vehicles)
            {
                sb.AppendLine($"{vehicle}");
            }
            return sb.ToString().Trim();
        }
    }
}
