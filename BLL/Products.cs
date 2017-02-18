using System;
using System.Collections.Generic;
using System.Linq;
using SimpleInvoices;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.BLL{
    public class Products {
        private readonly InvoiceContext _db ;
        public Products (InvoiceContext context){
            _db=context;
        }
        public List<CustomFieldRes> getCustomFields()
        {
            List<CustomFieldRes> toReturn =new List<CustomFieldRes>();
            var db=_db;
            var fields=db.customFields.Where(c=>c.tableName.Equals("Products")).ToList();
            if(fields.Count>0)
            {
                foreach(var entity in fields)
                {
                    toReturn.Add(new CustomFieldRes{
                        fieldName=entity.fieldName
                    });
                }
            }
            return toReturn;
        }
        public List<ProductViewRes> getProducts(int id)
        {
            var db=_db;
            List<ProductViewRes> toReturn =new List<ProductViewRes>();
            var usertype=db.userType.Where(c=>c.name.Equals("Product")).FirstOrDefault();
            List<SimpleInvoices.product> productList=new List<SimpleInvoices.product>();
            if(id==0)
            {
              productList=db.products.Where(c=> c.enable==true).ToList();
            }
            else
            {
             productList=db.products.Where(c=>c.Id.Equals(id)  && c.enable==true).ToList();
            }
            
            if(productList.Count>0)
            {
                 foreach(var entity in productList)
                 {
                     var customFields =new List<CustomFieldRes>();
                     for(int i=0;i<entity.customFields.Count;i++)
                     {
                        customFields[i].fieldName=entity.customFields[i].fieldName;
                        customFields[i].fieldValue=entity.customFields[i].FieldValues.Where(c=>c.product==entity).FirstOrDefault().value;
                     }
                     toReturn.Add(new ProductViewRes(){
                         name=entity.name,
                         id=entity.Id,
                         color=entity.color,
                         note=entity.note,
                         description=entity.description,
                         price=entity.price,
                         customField=customFields
                     });
                 }
            }
            else{
                return toReturn;
            }
            return toReturn;
        }
        public BaseResponse addProduct(ProductViewReq product)
        {
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            var Product=db.products.Where(c=>c.name.Equals(product.name)).FirstOrDefault();
            if(Product==null)
            {
                SimpleInvoices.product prod=new SimpleInvoices.product();
                
                prod.name=product.name;
                prod.color=product.color;
                prod.note=product.note;
                prod.description=product.description;
                prod.price=product.price;
                prod.enable=Constant.USER_ACTIVE;
                prod.createdOn=DateTime.Now;
                if(product.customField!=null)
                {
                    Console.WriteLine("in first If");
                    foreach(var entity in product.customField)
                    {
                        var field=db.customFields.Where(c=>c.tableName.Equals("Product") && c.fieldName.Equals(entity.fieldName)).FirstOrDefault();
                        field.FieldValues.Add(new FieldValue {
                        value=entity.fieldValue,
                        product=prod
                    });
                    
                   }        
            }
            else if(product.design.Count>0)
                   {
                       foreach (var entity in product.design)
                       {
                           var design=db.design.Where(c=>c.Id.Equals(entity.id)).FirstOrDefault();
                           prod.productDesign.Add(new ProductDesign {
                               product=prod,
                               design=design
                           });
                       }
                   }
             
                db.products.Add(prod);
                if(db.SaveChanges()==1)
                {
                    toReturn.status=1;
                    toReturn.developerMessage="Product has been created";
                }
                else
                {
                    toReturn.status=2;
                    toReturn.developerMessage="product can not been created";
                }
            }
            else
            {
                toReturn.status=-2;
                toReturn.developerMessage="Product is already Created";
            }
            return toReturn;
        }

        public BaseResponse editProduct(ProductViewReq product)
        {
            var db=_db;
            BaseResponse toReturn =new BaseResponse();
            var entity =db.products.Where(c=>c.Id.Equals(product.id)).FirstOrDefault();
            if(entity!=null)
            {
                entity.name=product.name;
                entity.note=product.note;
                entity.description=product.description;
                entity.price=product.price;
                entity.color=product.color;
                if(db.SaveChanges()==1)
                {
                    toReturn.status=1;
                    toReturn.developerMessage="Edit Product Successfully";

                }
                else
                {
                    toReturn.status=2;
                    toReturn.developerMessage="unable to Edit Product";
                }
            }
            else
            {
                toReturn.status=-1;
                toReturn.developerMessage="Cannot find product with that name";
            }
            return toReturn;

        }

        public BaseResponse deleteProduct(int id)
        {
            BaseResponse toReturn =new BaseResponse();
            var db=_db;
            var entity=db.products.Where(c=>c.Id.Equals(id)).FirstOrDefault();
            if(entity!=null)
            {
            entity.enable=false;
            if(db.SaveChanges()==1)
            {
                toReturn.status=1;
                toReturn.developerMessage="Delete product Successfull";
            }
            else
            {
                 toReturn.status=2;
                toReturn.developerMessage="Unable to delete product";
            }
            }
            else{
                toReturn.status=-1;
                toReturn.developerMessage="Unable to find product with id "+id;
            }
            return toReturn;
        }

    }
}