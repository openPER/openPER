﻿using AutoMapper;
using openPER.ViewModels;
using openPERModels;

namespace openPER.AutoMapper
{
    public class OpenPerMapperProfile:Profile
    {
        public OpenPerMapperProfile()
        {
            CreateMap<MakeModel, MakeViewModel>();
            CreateMap<ModelModel, ModelViewModel>();
            CreateMap<CatalogueModel, CatalogueViewModel>();
            CreateMap<GroupModel, GroupViewModel>();
            CreateMap<SubGroupModel, SubGroupViewModel>();
            CreateMap<SubSubGroupModel, SubSubGroupViewModel>();
            CreateMap<DrawingKeyModel, DrawingKeyViewModel>();
            CreateMap<TablePartModel, PartViewModel>();
            CreateMap<TableModel, TableViewModel>();
            CreateMap<BreadcrumbModel, BreadcrumbViewModel>();
            CreateMap<GroupImageMapEntryModel, GroupImageMapEntryViewModel>();
            CreateMap<SubGroupImageMapEntryModel, SubGroupImageMapEntryViewModel>();
            CreateMap<OptionModel, OptionViewModel>();
            CreateMap<ActivationModel, ActivationViewModel>();
            CreateMap<VariationModel, VariationViewModel>();
            CreateMap<ModificationModel, ModificationViewModel>();


        }
    }
}
