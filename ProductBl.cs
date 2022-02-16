using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ProductBl
    {
        public List<ProductDTO> GetAll()
        {
            var list = new DAL.ProductDal().GetAll();
            List<ProductDTO> DTOlist = new List<ProductDTO>();

            //foreach (var item in list)
            //{
            //    //yield return Converters.CustomerConverters.GetCustomerEntityFromDTO(item);

            //    list.Add(new conv().GetCustomerEntityFromDTO(item));
            //}
            DTOlist= list.Select(x => new ProductDTO()
            {
                ProductId = x.ProductId,
                ProductBusinessPrice = x.ProductBusinessPrice,
                ProductDescription = x.ProductDescription,
                ProductPrice = x.ProductPrice,
                ProductStatus = x.ProductStatus
            }).ToList();
            return DTOlist;
            //return (IEnumerable <CustomerDTO > )list;
        }

        public ProductDTO GetProduct(int id)
        {
            //Converters.AssistanceConverters.ConvertEntity<Assistance, AssistanceDTO>( );

            return (new Converters.PoductConverters()).GetProductEntityFromDTO(
             (new DAL.ProductDal().GetProductById(id)));
        }

        public int AddProduct(ProductDTO model)
        {
            //Converters.AssistanceConverters.ConvertEntity<Assistance, AssistanceDTO>( );
            return new ProductDal().AddProduct(
                new Product()
                {
                    ProductId = model.ProductId,
                    ProductBusinessPrice = model.ProductBusinessPrice,
                    ProductDescription = model.ProductDescription,
                    ProductPrice = model.ProductPrice,
                    ProductStatus = model.ProductStatus
                });
        }
    }
}
