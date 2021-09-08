//-----------------------------------------------------------------------
// <copyright file="FilterJob.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WPF.MVVM.Model.Logic
{
    using Gießformkonfigurator.WPF.MVVM.Model.Db_products;
    class ProgramLogic
    {
        public FilterJob filterJob { get; set; }

        public CombinationJob combinationJob { get; set; }

        public CompareJob compareJob { get; set; }

        public RankingJob rankingJob { get; set; }

        public Product product { get; set; }


        public ProgramLogic(Product product)
        {
            this.product = product;

            filterJob = new FilterJob(this.product);

            combinationJob = new CombinationJob(this.product, this.filterJob);
        }
    }
}
