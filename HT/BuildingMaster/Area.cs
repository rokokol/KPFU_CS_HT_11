namespace BuildingMaster
{
    public class Area
    {
        private Building[] area = new Building[10];

        public Building this[int index]
        {
            set => area[index] = value;

            get => area[index];
        }
    }
}