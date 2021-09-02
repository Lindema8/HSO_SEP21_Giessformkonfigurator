//-----------------------------------------------------------------------
// <copyright file="CompareObject.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WPF.MVVM.Model.Logic
{
    using Gießformkonfigurator.WPF.MVVM.Model.Db_molds;
    using Gießformkonfigurator.WPF.MVVM.Model.Db_products;

    public class CompareObject
    {
        public CompareObject(Mold gf, Product pr)
        {
            this.Gießform = gf;
            this.Product = pr;
        }

        public Mold Gießform { get; set; }

        public Product Product { get; set; }
    }
}
