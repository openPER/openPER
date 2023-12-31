﻿using System.Collections.Generic;

namespace openPERModels
{
    public class ModificationModel
    {
        public string Type { get; set; }
        public int Code { get; set; }
        public string Sequence { get; set; }
        public string Description { get; set; }
        public int Progression { get; set; }

        public List<ActivationModel> Activations { get; set; }
        public string FullDescription
        {
            get
            {
                var rc = Description;
                foreach (var item in Activations)
                {
                    rc += $" {item.ActivationCode} {item.ActivationDescription} ";
                }
                return rc;
            }
        }

    }
}
