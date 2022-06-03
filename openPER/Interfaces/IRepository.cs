﻿using openPER.Models;
using System.Collections.Generic;

namespace openPER.Interfaces
{
    public interface IRepository
    {
        TableModel GetTable(string catalogueCode, int groupCode, int subGroupCode, int sgsCode, int drawingNumber, string languageCode);
        List<MakeModel> GetAllMakes();
        List<ModelModel> GetAllModelsForMake(string make);
        List<ModelModel> GetAllModels();
        List<CatalogueModel> GetAllCatalogues(string make, string model, string languageCode);
        List<GroupModel> GetGroupsForCatalogue(string catalogueCode, string languageCode);
        List<SubGroupModel> GetSubGroupsForCatalogueGroup(string catalogueCode, int groupCode, string languageCode);
        List<SubSubGroupModel> GetSubSubGroupsForCatalogueGroupSubGroup(string catalogueCode, int groupCode, int subGroupCode, string languageCode);
        PartModel GetPartDetails(string partNumberSearch, string languageCode);
        MvsModel GetMvsDetails(string mvsCode, string mvsVersion, string mvsSeries, string colourCode, string languageCode);
        List<LanguageModel> GetAllLanguages();
    }

}
