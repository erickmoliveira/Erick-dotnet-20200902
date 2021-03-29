using System.Collections.Generic;

namespace FitnessFoods.Core.Services
{
    public interface IImportProductsService
    {
        string GetFileProduct(string nameFile);
        void GetListFileNames();
        void ImportProducts();
    }
}