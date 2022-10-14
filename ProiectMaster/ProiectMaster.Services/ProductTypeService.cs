﻿using AutoMapper;
using ProiectMaster.DataAccess.Interfaces;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Entites;
using ProiectMaster.Models.Interfaces;
using System.Collections.Generic;

namespace ProiectMaster.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IRepository<ProductType, int> productTypeRep;
        private readonly IMapper mapper;

        //will use it to check if any dependency present
        //private readonly IRepository<Product, int> productRep;
        private readonly IProductService productRep;

        public ProductTypeService(IRepository<ProductType, int> productTypeRep, IMapper mapper)
        {
            this.productTypeRep = productTypeRep;
            this.mapper = mapper;
        }

        public void AddProductType(ProductTypeVM dto)
        {
            var entity = mapper.Map<ProductType>(dto);
            productTypeRep.Add(entity);
        }


        public void DeleteProductType(int id)
        {
            var entity = productTypeRep.GetInstance(id);
            if (entity == null)
                return;

            //var Produse = productRep.GetAllProducts();
            //List<ProductVM> listaProduse = new List<ProductVM>();
            //listaProduse = mapper.Map<List<ProductVM>>(Produse);


            //if (listaProduse.Contains(new ProductVM { ProductTypeId = id }))
                //("This product type has dependencies. It cannot be deleted");
               // return;
            //else
                productTypeRep.Delete(entity);

        }

        
        public IEnumerable<ProductTypeVM> GetAllProductType()
        {
            var products = productTypeRep.GetAll();
            return mapper.Map<List<ProductTypeVM>>(products);
        }

        public ProductTypeVM GetProductType(int id)
        {
            var entity = productTypeRep.GetInstance(id);
            return mapper.Map<ProductTypeVM>(entity);
        }

        public void UpdateProductType(int id, ProductTypeVM dto)
        {
            var entity = productTypeRep.GetInstance(id);
            if (entity == null)
                return;

            mapper.Map(dto, entity);
            productTypeRep.Update(entity);
        }
    }
}
