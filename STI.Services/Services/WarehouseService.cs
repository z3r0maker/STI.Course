using Microsoft.EntityFrameworkCore;
using STI.Course.DTO;
using STI.Data;
using STI.Data.Models;
using STI.DTOs;
using STI.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using STI.Common.Extensions;

namespace STI.Services.Services
{
    public class WarehouseService : IWarehouseService
    {
        IUserService _userService;
        STIContext _context;

        public WarehouseService(IUserService userService, STIContext context)
        {
            _userService = userService;
            _context = context;
        }
        public IEnumerable<Warehouse> GetWarehouses()
        {
            //TODO: arreglar este codigo porque regreso[]
            var warehouses = _context.Warehouse.Where(t => t.Id != 0).Include(t => t.WarehouseType);
            var x = warehouses.ToList();
            return warehouses;

        }

        //Agregar a la BD

        //Actualizar a la BD

        //Eliminar de la BD 

        public IEnumerable<WarehouseType> GetWarehousesTypes()
        {
            var warehouseTypes = _context.WarehouseType.Where(t => t.Id != 0);
            return warehouseTypes;
            //return warehouseTypes.AsEnumerable();
        }

        public void OtherMethod()
        {
            throw new NotImplementedException();
        }

        public ReportDto GetCompanyReport(int companyId)
        {
            try
            {
                var report = _context.Company
                    .Include(t=> t.Warehouse)
                        .ThenInclude(t=> t.WarehouseType)
                    //.Include(t=> t.Warehouse)
                    //  .ThenInclude(t=> t.Color)
                    .SingleOrDefault(t => t.Id == companyId);

                //Mapper
                ReportDto dto = new ReportDto()
                {
                    CompanyName = report.Name,
                    WarehouseName = report.Warehouse.Name,
                    WarehouseTypeName = report.Warehouse.WarehouseType.Description
                };
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Build a base for the schema/tables for the expression
        private IQueryable<Company> companySelector =>
            _context.Company
            .Include(t => t.Warehouse)
                .ThenInclude(t => t.WarehouseType);

        public ReportDto GetCompanyReportTree(int companyId)
        {
            try
            {
                int menuItem = 1;
                //Define an expression tree of the object to be queried
                Expression<Func<Company, bool>> companiespredicate = results => false;
                
                //Define a predicate / query / filter that we want to apply to our data set.
                companiespredicate = results => results.Name == "Company 1";


                switch (menuItem)
                {
                    case 1:
                        Expression<Func<Company, bool>> warehousetypepredicate = results2 => false;
                        warehousetypepredicate = results2 => results2.Warehouse.WarehouseTypeId == 1;
                        companiespredicate = companiespredicate.CombineAnd(warehousetypepredicate);
                        break;
                    default:
                        break;
                }

                //Frameowrk still not executing the Query
                var query = companySelector.Where(companiespredicate);



                IQueryable dynamicQuery = from company in query
                                          let number = 100
                                          let Calculo = company.WarehouseId + 100
                                          let MyOtherId = Guid.NewGuid()
                                          let MyWarehouse = $"{company.Warehouse.Name}-{Guid.NewGuid().ToString()}"
                                          select new ReportDto
                                          {
                                              CompanyName = company.Name,
                                              WarehouseName = company.Warehouse.Name,
                                              WarehouseTypeName = company.Warehouse.WarehouseType.Description,
                                              OtherID = MyOtherId.ToString(),
                                              WarehouseFixedName = MyWarehouse,
                                              Calculo = Calculo.ToString()
                                          };



                var results = dynamicQuery.Cast<ReportDto>();

                var report = results.FirstOrDefault();

                return report;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
