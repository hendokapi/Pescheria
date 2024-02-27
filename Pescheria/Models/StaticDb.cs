namespace Pescheria.Models
{
    public static class StaticDb
    {
        private static int _maxId = 3;
        private static List<Fish> _fishes = [
            new Fish(){FishId = 1, Name = "Trota", IsSeaFish = false, Price = 1500},
            new Fish(){FishId = 2, Name = "Salmone", IsSeaFish = false, Price = 3000},
            new Fish(){FishId = 3, Name = "Sgombro", IsSeaFish = true, Price = 800},
        ];

        public static List<Fish> GetAll()
        {
            return _fishes;
        }

        public static Fish? GetById(int? id)
        {
            if (id is null) return null;

            for(int i = 0; i < _fishes.Count; i++)
            {
                Fish fish = _fishes[i];
                if (fish.FishId == id)
                {
                    return fish;
                }
            }

            return null;
        }

        public static Fish Add(string name, bool isSeaFish, int price)
        {
            _maxId++;
            var fish = new Fish() { FishId = _maxId, Name = name, IsSeaFish = isSeaFish, Price = price };
            _fishes.Add(fish);
            return fish;
        }
    }
}
