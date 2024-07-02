using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Functions
{
    public class TypeTripFuncBll: ITypeTripBll
    {
        ITypeTripDAL dal;
        IMapper mapper;

        public TypeTripFuncBll(ITypeTripDAL dal)
        {
            this.dal = dal;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.Classes.Mapper>();
            });

            mapper = config.CreateMapper();
        }

        public async Task<int> Add(TypeTripDTO typeTrip)
        {
            //שליפת כל הסוגים 
            List<TypeTripDTO> allTypes = await GetAll();
            //בדיקה אם כבר קיים סוג זה
            var newType=allTypes.FirstOrDefault(e=>e.TypeName==typeTrip.TypeName);
            //אם קיים אחד כזה
            if (newType != null)
            {
                return -1;
            }
            //אם לא קיים נוסיף אותו 
            int code = await dal.Add(mapper.Map<TypeTripDTO, TypeTrip>(typeTrip));
            return code;
        }

        public async Task<bool> Delete(int id)
        {
            bool x = await dal.Delete(id);
            return x;
        }

        public async Task<List<TypeTripDTO>> GetAll()
        {
            List<TypeTrip> u = await dal.GetAll();
            if (u != null)
            {
                return mapper.Map<List<TypeTrip>, List<TypeTripDTO>>(u);
            }
            return null;
        }

        public async Task<TypeTripDTO> GetById(int id)
        {
            TypeTrip u = await dal.GetById(id);
            if (u != null)
            {
                return mapper.Map<TypeTrip, TypeTripDTO>(u);
            }
            return null;
        }
    }
}
