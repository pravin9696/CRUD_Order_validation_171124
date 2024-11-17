using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Order_validation_171124.Models;
using CRUD_Order_validation_171124.Models.ValidationData;
namespace CRUD_Order_validation_171124.Controllers
{
    public class OrdersController : Controller
    {
        private StudDBEntities dbo = new StudDBEntities();

        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PlaceOrder() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult PlaceOrder(OrderValidationClass ovc)
        {
            if (ModelState.IsValid)
            {
                tblOrder ord = new tblOrder();
                ord.ProductName = ovc.ProductName;
                ord.Price = ovc.Price;
                ord.Quantity = ovc.Quantity;
                dbo.tblOrders.Add(ord);
                int n = dbo.SaveChanges();
                if (n>0)
                {
                    ViewBag.msg = "Order Placed Successfully...";
                    return View("SuccessMessage");
                }
                else
                {
                    ViewBag.msg = "Order NOT Placed!!!!";
                    return View("SuccessMessage");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditSearch()
        {
            List<tblOrder> orders = dbo.tblOrders.ToList();
            ViewBag.orders= orders;
            return View();
        }
        [HttpPost]
        public ActionResult EditSearch(tblOrder ord)
        {
            if (ModelState.IsValid)
            {
                tblOrder order = dbo.tblOrders.Find(ord.Id);
                if (order != null)
                {
                    OrderValidationClass ovc = new OrderValidationClass();
                    ovc.Id = order.Id;
                    ovc.ProductName = order.ProductName;
                    ovc.Quantity = order.Quantity;
                    ovc.Price = order.Price;
                    return View("Edit", ovc);
                }
            }
            List<tblOrder> orders = dbo.tblOrders.ToList();
            ViewBag.orders = orders;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(OrderValidationClass ovc)
        {
            if (ModelState.IsValid)
            {
                tblOrder ord = dbo.tblOrders.FirstOrDefault(x=>x.Id==ovc.Id);
                ord.ProductName = ovc.ProductName;
                ord.Price = ovc.Price;
                ord.Quantity = ovc.Quantity;               
                int n = dbo.SaveChanges();
                if (n > 0)
                {
                    ViewBag.msg = "Order updated Successfully...";
                    return View("SuccessMessage");
                }
                else
                {
                    ViewBag.msg = "Order NOT updated!!!!";
                    return View("SuccessMessage");
                }
            }
            return View();
        }
    }
}