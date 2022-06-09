﻿using openPERModels;

namespace openPERRepositories.Interfaces
{
    public interface IVersionedImageRepository
    {
        byte[] GetImageForModel(int releaseCode, string makeCode, string subMakeCode, string cmgCode);
        byte[] GetSmallImageForModel(int releaseCode, string makeCode, string subMakeCode, string cmgCode);
        byte[] GetImageForCatalogue(int releaseCode, string makeCode, string subMakeCode, string modelCode,
            string catalogueCode, MapImageModel mapDetails);
        byte[] GetImageForDrawing(int releaseCode, string makeCode, string modelCode, string catalogueCode, int groupCode, int subgroupCode, int subSubGroupCode, int drawingNumber);
        byte[] GetThumbnailForDrawing(int releaseCode, string makeCode, string modelCode, string catalogueCode, int groupCode, int subGroupCode, int subSubGroupCode, int drawingNumber);
    }
}