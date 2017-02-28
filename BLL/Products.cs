using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            List<SimpleInvoices.product> productList=new List<SimpleInvoices.product>();
            if(id==0)
            {
              productList=db.products.Where(c=> c.enable==true).Include(c=>c.customFields ).Include(c=>c.productDesign).ThenInclude(c=>c.design).ToList();
            }
            else
            {
             productList=db.products.Where(c=>c.Id.Equals(id)  && c.enable==true).Include(c=>c.customFields).Include(c=>c.productDesign).ThenInclude(c=>c.design).ToList();
            }
            
            if(productList.Count>0)
            {
                 foreach(var entity in productList)
                 {
                     var customFields =new List<CustomFieldRes>();
                     var design=new List<DesignViewReq>();
                     for(int i=0;i<entity.customFields.Count;i++)
                     {
                        customFields.Add(new CustomFieldRes {
                            fieldName=entity.customFields[i].fieldName,
                            fieldValue=entity.customFields[i].FieldValues.Where(c=>c.product==entity).FirstOrDefault().value
                        });
                     }
                     for(int i=0;i<entity.productDesign.Count;i++)
                     {
                         Console.WriteLine("product Design"+entity.productDesign.Count);
                         Console.WriteLine(" Design"+entity.productDesign[i].design.color);
                        design.Add(new DesignViewReq{
                            name=entity.productDesign[i].design.name,
                            color=entity.productDesign[i].design.color,
                            fabric=entity.productDesign[i].design.fabric,
                            cut=entity.productDesign[i].design.cut,
                            note=entity.productDesign[i].design.note
                            
                        });
                     }
                     toReturn.Add(new ProductViewRes(){
                         name=entity.name,
                         id=entity.Id,
                         color=entity.color,
                         note=entity.note,
                         description=entity.description,
                         price=entity.price,
                         customField=customFields,
                         designs=design
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
            int productId=0;
            try{
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            SimpleInvoices.product dbProduct=new SimpleInvoices.product();
            List<Design> designLists=new List<Design>();
            string name=product.name;
            dbProduct=db.products.Where(c=>c.name.Equals(name)).FirstOrDefault();
            Console.WriteLine("get Product");
            if(dbProduct==null)
            {
                SimpleInvoices.product prod=new SimpleInvoices.product();
                prod.name=product.name;
                prod.color=product.color;
                prod.note=product.note;
                prod.description=product.description;
                prod.price=product.price;
                prod.enable=Constant.USER_ACTIVE;
                prod.createdOn=DateTime.Now;
                if(product.customField.Count>0)
                {
                    Console.WriteLine("in first If");
                    foreach(var entity in product.customField)
                    {
                        string fieldname=entity.fieldName;
                        var field=db.customFields.Where(c=>c.tableName.Equals("Product") && c.fieldName.Equals(entity.fieldName)).FirstOrDefault();
                        field.FieldValues.Add(new FieldValue {
                        value=entity.fieldValue,
                        product=prod
                    });
                    List<FieldValue> fieldValue=new List<FieldValue>();
                   fieldValue=field.FieldValues;
                   db.FieldValues.AddRange(fieldValue);
                   Console.WriteLine("Field added");
                   }        
            }
            
            else if(product.design.Count>0)
                   {
                       Console.WriteLine("product count");
                       foreach (var entity in product.design)
                       {
                           var design=new SimpleInvoices.Design{
                               name=entity.name,
                               color=entity.color,
                               fabric=entity.fabric,
                               cut=entity.cut,
                               note=entity.note,
                               enable=true
                           };
                           /*
                           prod.productDesign.Add(new ProductDesign {
                               product=prod,
                               design=design
                           }); */
                           Console.WriteLine("Design Values"+design.color+"fabric"+design.fabric);
                           db.design.Add(design);
                          db.products.Add(prod);
                            var productDesign=new ProductDesign{
                            product=prod,
                            design=design
                        };
                        db.productDesign.Add(productDesign);
                       }
                        
                   }
                   else
                    {
                           productId=db.products.Add(prod).Entity.Id;
                 }
                if(db.SaveChanges()>0)
                {
                    productId=prod.Id;
                    toReturn.status=productId;
                    toReturn.developerMessage="Product has been created";
                }
                else
                {
                    toReturn.status=productId;
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
            catch(Exception ex){
                Console.WriteLine("error "+ex);
                return new BaseResponse();
            }
        }
        public BaseResponse editProduct(ProductViewReq product)
        {
            var db=_db;
            BaseResponse toReturn =new BaseResponse();
            var entity =db.products.Where(c=>c.Id.Equals(product.id) && c.enable==true).FirstOrDefault();
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
            var entity=db.products.Where(c=>c.Id.Equals(id) && c.enable==true).FirstOrDefault();
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