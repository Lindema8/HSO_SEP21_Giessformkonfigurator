//-----------------------------------------------------------------------
// <copyright file="MGießform.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.Db_molds
{
    using Gießformkonfigurator.WindowsForms.Main.Db_components;
    using System.Collections.Generic;

    public class MGießform : Gießform
    {
        private MGießform mGießform;
        private string type;

        public Grundplatte Grundplatte{ get; set; }

        public Ring Fuehrungsring { get; set; }

        public Einlegeplatte Einlegeplatte { get; set; }

        public Kern Innenkern { get; set; }

        public Cupform Cupform { get; set; }

        public List<Ring> ListInnerRings = new List<Ring>();

        public MGießform(Grundplatte gp, Ring fr, Einlegeplatte el, Kern ik)
        {
            this.type = "MGießform Disk";
            this.Grundplatte = gp;
            this.Fuehrungsring = fr;
            this.Einlegeplatte = el;
            this.Innenkern = ik;
        }

        public MGießform(Cupform cf, Kern ik, Bolzen bl)
        {
            this.type = "MGießform Cup";
            this.Cupform = cf;
            this.Innenkern = ik;
        }
    }
}
