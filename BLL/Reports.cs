using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.BLL
{
    public class Reports
    {
        private readonly InvoiceContext _db;
        public Reports(InvoiceContext context)
        {
            _db = context;
        }

        public ToSalesRes totalSales()
        {
            int quantity = 0;
            double total = 0;
            ToSalesRes toReturn = new ToSalesRes();
            var db = _db;
            var invoice = db.ledgers.ToList();
            quantity = invoice.Count;
            foreach (var item in invoice)
            {
                total += item.amount;
            }
            toReturn.invoiceName = "Invoice";
            toReturn.numberOfTimes = quantity;
            toReturn.totalSales = total;
            return toReturn;
        }


        public TotalSalesCustomerRes totalCustomerSales()
        {
            TotalSalesCustomerRes toReturn = new TotalSalesCustomerRes();

            var db = _db;
            var invoices = db.ledgers.Include(c => c.customer).GroupBy(c => c.customer).ToList();
            foreach (var item in invoices)
            {
                CustomerAmount customers = new CustomerAmount();
                foreach (var entity in item)
                {
                    customers.name = entity.customer.name;
                    customers.amount += entity.amount;
                }

                toReturn.customer.Add(customers);
                toReturn.total += customers.amount;
            }
            return toReturn;
        }

        public List<productSoldRes> productSold()
        {
            List<productSoldRes> toReturn = new List<productSoldRes>();
            var db = _db;
            var legderDetails = db.ledgerDetails.Include(p => p.product).GroupBy(p => p.product);
            foreach (var entity in legderDetails)
            {
                toReturn.Add(new productSoldRes
                {
                    quantity = entity.Count(),
                    productName = entity.FirstOrDefault().product.name

                });
            }
            return toReturn;
        }

        public List<productCustomerRes> productCustomer()
        {
            List<productCustomerRes> toReturn = new List<productCustomerRes>();
            var db = _db;

            var ledger = db.ledgers.Include(c => c.customer).Include(c => c.ledgerDetails).ThenInclude(c => c.product).GroupBy(c => c.customer);

            foreach (var items in ledger)
            {
                productCustomerRes res = new productCustomerRes();


                foreach (var entity in items)
                {
                    res.customerName = entity.customer.name;
                    res.quantity = entity.ledgerDetails.Count;
                    foreach (var iteration in entity.ledgerDetails)
                    {
                        res.productName = iteration.product.name;
                        toReturn.Add(res);
                    }
                }
            }
            return toReturn;
        }

        public double totalTaxesReport()
        {

            double totalAmount = 0;
            double totalTax = 0;
            double toReturn = 0;
            var db = _db;
            var invoices = db.ledgers.Include(c => c.ledgerDetails).ThenInclude(c => c.product).ToList();
            foreach (var item in invoices)
            {
                totalAmount = 0;
                totalTax = 0;
                foreach (var entity in item.ledgerDetails)
                {
                    totalAmount += entity.quantity * entity.product.price;
                }
                totalTax = (item.amount - totalAmount);
                toReturn += totalTax;
            }
            return toReturn;
        }
        public BillerSalesRes billerSales()
        {
            BillerSalesRes toReturn = new BillerSalesRes();
            var db = _db;
            var invoices = db.ledgers.Include(c => c.biller).GroupBy(c => c.biller);
            foreach (var item in invoices)
            {
                BillerNameAmount biller = new BillerNameAmount();
                foreach (var entity in item)
                {
                    biller.name = entity.biller.name;
                    biller.amount += entity.amount;
                }

                toReturn.billerAmount.Add(biller);
                toReturn.total += biller.amount;
            }

            return toReturn;
        }


        public List<BillerSalesCustomer> billerSalesCustomerWise()
        {
            List<BillerSalesCustomer> toReturn = new List<BillerSalesCustomer>();
            var db = _db;
            var biller = db.biller.Where(c => c.enable == true).ToList();
            foreach (var item in biller)
            {
                BillerSalesCustomer res = new BillerSalesCustomer();
                res.billerName = item.name;
                var invoices = db.ledgers.Where(c => c.biller == item).Include(c => c.customer).ToList();
                if (invoices.Count > 0)
                {
                    foreach (var entity in invoices)
                    {
                        res.customer.Add(new customerSales
                        {
                            customerName = entity.customer.name,
                            sales = entity.amount
                        });

                    }
                }
                toReturn.Add(res);
            }

            return toReturn;
        }

        public List<InvoiceRes> debatorByOwned()
        {
            List<InvoiceRes> toReturn = new List<InvoiceRes>();
            var db = _db;
            var invoices = db.ledgers.Where(c => c.balance > 0).Include(c => c.customer).Include(c => c.biller);
            foreach (var entity in invoices)
            {
                toReturn.Add(new InvoiceRes
                {
                    id = entity.Id,
                    billerName = entity.biller.name,
                    custName = entity.customer.name,
                    price = entity.amount,
                    balance = entity.balance
                });
            }
            return toReturn;
        }
        public List<InvoiceRes> debatorByOwnedCustomer()
        {
            List<InvoiceRes> toReturn = new List<InvoiceRes>();
            var db = _db;
            var invoices = db.ledgers.Where(c => c.balance > 0).Include(c => c.customer).GroupBy(c => c.customer);
            foreach (var entity in invoices)
            {



                toReturn.Add(new InvoiceRes
                {
                    custName = entity.Key.name,
                    price = entity.Sum(c => c.amount),
                    balance = entity.Sum(c => c.balance)
                });
                
            }
            return toReturn;
        }

        public List<InvoiceRes> getInvoicebyFilter(invoiceFilter filter){
            List<InvoiceRes> toReturn=new List<InvoiceRes>();
            var db=_db;
            var invoices=db.ledgers.Include(c=>c.customer).Include(c=>c.biller).Where(c=>c.createdDate>= filter.fromDate && c.createdDate<=filter.toDate || c.deliveryDate>=filter.fromDate && c.deliveryDate<=filter.toDate);
            foreach(var entity in invoices){
                toReturn.Add(new InvoiceRes{
                    id=entity.Id,
                    billerName=entity.biller.name,
                    custName=entity.customer.name,
                    balance=entity.balance,
                    price=entity.amount,
                    delivery=entity.deliveryDate,
                    date=entity.createdDate
                });

            }
            return toReturn;

        } 
    }
}