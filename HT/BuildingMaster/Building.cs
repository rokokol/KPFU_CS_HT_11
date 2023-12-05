using System;

namespace BuildingMaster
{
    [Build("Anton", "OOOGovoStroi")]
    public class Building
    {
        private static uint lastId;
        public uint Id { get; private set; }
        public double Height { get; private set; }
        public uint ApartmentCount { get; private set; }
        public uint FloorsCount { get; private set; }
        public uint EntrancesCount { get; private set; }

        /// <summary>
        /// Averages the apartments count per floor.
        /// </summary>
        /// <returns>The apartments count per floor.</returns>
        public double AverageApartmentsCountPerFloor()
        {
            return (double)ApartmentCount / FloorsCount;
        }

        /// <summary>
        /// Averages the apartments count per entrance.
        /// </summary>
        /// <returns>The apartments count per entrance.</returns>
        public double AverageApartmentsCountPerEntrance()
        {
            return (double)ApartmentCount / EntrancesCount;
        }

        /// <summary>
        /// Averags the floors count per entrance.
        /// </summary>
        /// <returns>The floors count per entrance.</returns>
        public double AveragFloorsCountPerEntrance()
        {
            return (double)FloorsCount / EntrancesCount;
        }

        /// <summary>
        /// Heights the of the floor.
        /// </summary>
        /// <returns>The of the floor or -1 if parameter bigger then count of the floors</returns>
        /// <param name="number">Number.</param>
        public double HeightOfTheFloor(uint number)
        {
            if (number > FloorsCount)
            {
                return -1;
            }

            return Height * number / AveragFloorsCountPerEntrance();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tymakov.Building"/> class.
        /// </summary>
        /// <param name="height">Height.</param>
        /// <param name="apartmentCount">Apartment count.</param>
        /// <param name="entrancesCount">Entrances count.</param>
        /// <param name="floorsCount">Floors count.</param>
        public Building(double height, uint apartmentCount, uint floorsCount, uint entrancesCount)
        {
            if (entrancesCount > floorsCount || floorsCount > apartmentCount || entrancesCount > apartmentCount)
            {
                throw new ArgumentException("Incorrect count of enrances, floors or apartments");
            }

            if (apartmentCount / floorsCount < 2)
            {
                throw new ArgumentException("Impossible height");
            }

            this.Height = height;
            this.ApartmentCount = apartmentCount;
            this.EntrancesCount = entrancesCount;
            this.FloorsCount = floorsCount;
            Id = lastId++;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Tymakov.Building"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Tymakov.Building"/>.</returns>
        public override string ToString()
        {
            return $"Building №{Id}:\n\tHeight: {Height} meters\n\tApartments: {ApartmentCount}" +
            $"\n\tFloors:{FloorsCount}\n\tEntrances: {EntrancesCount}";
        }
    }
}
