using Core.Entities;

namespace Entities.Concrete
{
    public class Bolum : IEntity
    {
        public int Id { get; set; }
        public string BolumAd { get; set; }
    }
}
