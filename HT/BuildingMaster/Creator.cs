using System.Collections.Generic;

namespace BuildingMaster
{
    public class Creator
    {
        private static readonly Dictionary<uint, Building> buildings = new Dictionary<uint, Building>();

        public static uint Create(double height, uint apartmentCount, uint floorsCount, uint entrancesCount)
        {
            Building building = new Building(height, apartmentCount, floorsCount, entrancesCount);
            buildings.Add(building.Id, building);
            return building.Id;
        }

        public static Building GetBuilding(uint id)
        {
            return buildings[id];
        }

        public static void RemoveBuilding(uint id)
        {
            buildings.Remove(id);
        }
        
        private Creator(){ }
    }
}