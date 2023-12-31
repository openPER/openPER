﻿using System.Collections.Generic;

namespace openPER.ViewModels
{
    public class TableViewModel
    {
        public string MakeCode { get; set; }
        public string SubMakeCode { get; set; }
        public string ModelCode { get; set; }
        public string CatalogueCode { get; set; }
        public int GroupCode { get; set; }
        public int SubGroupCode { get; set; }
        public int SubSubGroupCode { get; set; }
        public string ModelDesc { get; set; }
        public string MakeDesc { get; set; }
        public string CatalogueDesc { get; set; }
        public string GroupDesc { get; set; }
        public string SubGroupDesc { get; set; }
        public string SgsDesc { get; set; }
        public List<int> DrawingNumbers { get; set; }
        public List<PartViewModel> Parts { get; set; }
        public int Variant { get; set; }
        public int Revision { get; set; }
        public int CurrentDrawing { get; set; }
        public List<string> Narratives { get; set; }
        public string HighlightPart { get; set; }
        public string ImagePath { get; set; }
        public string Path => $"{MakeCode}/{ModelCode}/{CatalogueCode}/{GroupCode:00}/{SubGroupCode:000}/{SubSubGroupCode:00}";
        public Dictionary<string, PartHotspotViewModel> HotSpots { get; set; }
        public List<PartHotspotViewModel> Links { get; set; }
    }
}
