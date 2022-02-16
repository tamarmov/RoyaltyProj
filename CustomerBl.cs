using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Converters;
using DAL;
using DTO;
using conv = BLL.Converters.CustomerConverters;

namespace BLL
{
    public class CustomerBl
    {
        
        public List<CustomerDTO> GetAll()
        {
            var list = new DAL.CustomerDal().GetAll();
            List<CustomerDTO> DTOlist = new List<CustomerDTO>();

            //foreach (var item in list)
            //{
            //    //yield return Converters.CustomerConverters.GetCustomerEntityFromDTO(item);

            //    list.Add(new conv().GetCustomerEntityFromDTO(item));
            //}
            return list.Select(x => new CustomerDTO()
            {
                CustomerId= x.CustomerId,
                CustomerAdress = x.CustomerAdress,
                CustomerEmail = x.CustomerEmail,
                CustomerName = x.CustomerName,
                CustomerStatus = x.CustomerStatus,
                CustomerTel = x.CustomerTel
            }).ToList();
            //return (IEnumerable <CustomerDTO > )list;
        }

        //public Customer GetCustomer(int id)
        //{
        //    Customer v = new DAL.CustomerDal().GetCustomer(id);
        //    return
        //        (new Converters.CustomerConverters()).GetCustomerEntityFromDTO(
        //     (new CustomerDal().GetCustomer(id)));
        //}

        public int AddCustomer(CustomerDTO model)
        {
            //Converters.AssistanceConverters.ConvertEntity<Assistance, AssistanceDTO>( );
            return new DAL.CustomerDal().AddCustomer(
                new Customer()
                {
                    CustomerAdress = model.CustomerAdress,
                    CustomerEmail = model.CustomerEmail,
                    CustomerName = model.CustomerName,
                    CustomerStatus = model.CustomerStatus,
                    CustomerTel = model.CustomerTel,
                });
        }

        //public CustomerDTO GetLogin(LoginData loginData)
        //{
        //    return (new Converters.CustomerConverters()).GetCustomerFromEntity(new DAL.CustomerDal()
        //        .GetCustomerByIdAndEmail(loginData.mail, loginData.password));
        //}‏
    }
}
