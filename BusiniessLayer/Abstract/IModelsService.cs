using EntityLayer.Models;
using System.Collections.Generic;

namespace BusiniessLayer.Abstract
{
    public interface IModelsService
    {
        List<Models> GetAllModels();
        List<Models> GetModelBrandId(int id);
        Models GetModelById(int id);
        void AddModel(Models model);
        void UpdateModel(Models model);
        void DeleteModel(Models model);
    }
} 