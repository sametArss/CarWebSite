using BusiniessLayer.Abstract;
using DataAcsessLayer.Abstract;
using EntityLayer.Models;
using System.Collections.Generic;

namespace BusiniessLayer.Concrete
{
    public class ModelsManager : IModelsService
    {
        private readonly IModelsDal _modelsDal;

        public ModelsManager(IModelsDal modelsDal)
        {
            _modelsDal = modelsDal;
        }

        public void AddModel(Models model)
        {
            _modelsDal.Insert(model);
        }

        public void DeleteModel(Models model)
        {
            _modelsDal.Delete(model);
        }

        public List<Models> GetAllModels()
        {
            return _modelsDal.GetAll();
        }

        public List<Models> GetModelBrandId(int id)
        {
           return _modelsDal.GetAllFilter(x=>x.BrandId == id);
        }

        public Models GetModelById(int id)
        {
            return _modelsDal.GetById(id);
        }

        public void UpdateModel(Models model)
        {
            _modelsDal.Update(model);
        }
    }
} 