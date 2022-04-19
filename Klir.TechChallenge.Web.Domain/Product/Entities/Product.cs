using Klir.TechChallenge.Web.Domain.Core.Entities;

namespace Klir.TechChallenge.Web.Domain.Product.Entities
{
    public class Product : Entity
    {
        protected Product() { }

        public Product(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
            Promotion = null;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public bool Deleted { get; set; }
        public ProductPromotion Promotion { get; protected set; }

        public void Delete() => Deleted = true;

        public void UpdateProduct(string name, decimal price, string description)
        {
            Name = name;
            Description = description;
            Price = price;
        }
        public void SetPromotion(string description, int minimumQuantity, decimal discount)
        {
            Promotion = new ProductPromotion(this.Id, description, minimumQuantity, discount);
        }

        public void RemovePromotion()
        {
            Promotion = null;
        }

    }
}
