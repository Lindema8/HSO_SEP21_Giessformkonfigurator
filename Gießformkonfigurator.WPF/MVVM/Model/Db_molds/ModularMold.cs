﻿//-----------------------------------------------------------------------
// <copyright file="MGießform.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WPF.MVVM.Model.Db_molds
{
    using Gießformkonfigurator.WPF.MVVM.Model.Db_components;
    using System.Collections.Generic;
    using System.ComponentModel;

    class ModularMold : Mold
    {
        private ModularMold mGießform;
        private string type;

        public Baseplate Grundplatte { get; set; }

        public Ring Fuehrungsring { get; set; }

        public InsertPlate Einlegeplatte { get; set; }

        public Core Innenkern { get; set; }

        public Cupform Cupform { get; set; }

        public List<Ring> ListInnerRings = new List<Ring>();

        public ModularMold(Baseplate gp, Ring fr, InsertPlate el, Core ik)
        {
            this.type = "MGießform Disk";
            this.Grundplatte = gp;
            this.Fuehrungsring = fr;
            this.Einlegeplatte = el;
            this.Innenkern = ik;
        }

        public ModularMold(Cupform cf, Core ik)
        {
            this.type = "MGießform Cup";
            this.Cupform = cf;
            this.Innenkern = ik;
        }

        /*public override string ToString()
        {
            return this.Grundplatte this.Fuehrungsring, this.Einlegeplatte, this.Innenkern, this.Cupform, this.ListInnerRings[0], this.ListInnerRings[1], this.ListInnerRings[2];
        }*/
    }
}
