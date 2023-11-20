
public class ItemFactory : AbstractFactory
{
    public ItemFactory(IProduct productToProduce) : base(productToProduce)
    {

    }
    public override IProduct CreateProduct()
    {
        return product.Clone();
    }
}
