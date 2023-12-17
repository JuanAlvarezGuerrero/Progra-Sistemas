using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFactory : AbstractFactory
{
    public ArrowFactory(IProduct productToProduce) : base(productToProduce)
    {

    }
    public override IProduct CreateProduct()
    {
        return product.Clone();
    }
}
