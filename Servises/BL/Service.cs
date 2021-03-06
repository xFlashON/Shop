﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servises.Interfaces;
using DAL.Interfaces;
using DAL.Model;
using Servises.Models;
using System.Collections;

namespace Servises.BL
{
    public class Service : IService
    {
        private IUnitOfWork databaseService;
        public Service(IUnitOfWork unitOfWork)
        {
            databaseService = unitOfWork;
        }

        public ValidationException CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public IUnitOfWork DatabaseService
        {
            get => databaseService;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return databaseService.ProductRepository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return databaseService.ProductRepository.Get(id);
        }

        public IEnumerable<Price> GetProductPrices()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            return databaseService.ProductRepository.GetAll();
        }

        public IEnumerable<Product> GetProducts(int? groupId, int? page)
        {
            if (page == null)
                page = 0;

            page = Math.Max(0, (int)page);

            int pageSize = 6;

            return databaseService.ProductRepository.Get(x => (groupId == null || x.ProductType == null) || x.ProductType.Id == groupId).Skip((int)page * pageSize).Take(pageSize);
        }

        public IEnumerable<ProductType> GetProductTypes()
        {
            return databaseService.ProductTypeRepository.GetAll();
        }

        PriceListDTO IService.GetProductPrices(int page, int pageSize)
        {
            page = Math.Max(page, 1);
            pageSize = Math.Max(pageSize, 1);

            var prices = DatabaseService.PriceRepository.GetAll().OrderBy(p=>p.Product.ProductType.Name).ThenBy(p => p.Product.Name).ThenBy(p=>p.PriceType.Name);

            int totalRecords = prices.Count();

            var priceList = new PriceListDTO(){records = totalRecords, total = (int) Math.Ceiling((double)totalRecords/pageSize),
                rows = prices.Skip((page-1)*pageSize).Take(pageSize).Select(p=>new PriceDTO(){
                    Id = p.Id,
                    Price = p.CurrentPrice,
                    PriceTypeId = p.PriceTypeId,
                    PriceTypeName = p.PriceType.Name,
                    ProductId = p.ProductId,
                    ProductName = p.Product.Name,
                    ProductTypeId = p.Product.ProductTypeId,
                    ProductTypeName = p.Product.ProductType?.Name??string.Empty
                })
            };

        
            return priceList;
        }

        public void SaveImage(int productId, byte[] imageData, string mimoType)
        {

            var product = databaseService.ProductRepository.Get(productId);

            if(product != null)
            {
                ProductImage image = product.ProductImage ?? new ProductImage();

                image.ImageData = imageData;
                image.ImageMimeType = mimoType;

                if (image.Id == 0)
                {
                    DatabaseService.ProductImageRepository.Create(image);
                    DatabaseService.Save();                    
                }
                else
                {
                    DatabaseService.ProductImageRepository.Update(image);
                }

                product.ProductImageId = image.Id;
                product.ProductImage = image;

                DatabaseService.ProductRepository.Update(product);

                DatabaseService.Save();

            }

        }

        public ProductImage GetImage(int imageId)
        {
            return DatabaseService.ProductImageRepository.Get(imageId);
        }

        public IEnumerable<News> GetNews(int? page)
        {
            int pageSize = 5;

            if (page == null)
                page = 0;

            return databaseService.NewsRepository.GetAll().OrderByDescending (x=>x.Date).Skip((int)page * pageSize).Take(pageSize);
        }

        public News GetNews(int newsId)
        {
            return databaseService.NewsRepository.Get(newsId);
        }

        public void SaveNews(News news)
        {
            if (news.Id == 0)
                databaseService.NewsRepository.Create(news);
            else
                databaseService.NewsRepository.Update(news);

            databaseService.Save();
        }

        public IEnumerable<PriceType> GetPriceTypes()
        {
            return DatabaseService.PriceTypeRepository.GetAll();
        }

        public Order GetOpenOrder(string userName)
        {


            var order = databaseService.OrderRepository.Get(o => o.User == userName && o.Payed == false).FirstOrDefault();
            if (order != null)
                return order;

            return new Order() { Date = DateTime.Now, User = userName };

        }

        public void SaveOrder(Order order)
        {

            if (order.Id == 0)
                DatabaseService.OrderRepository.Create(order);
            else
            {
                DatabaseService.OrderRepository.Update(order);
            }
                

            DatabaseService.Save();
        }

        public void AddToCart(Product product, decimal price, string userName)
        {

            var order = GetOpenOrder(userName);
            var row = order.OrderRows?.FirstOrDefault(r => r?.Product.Id == product.Id&&r?.Price==price);

            if (row != null)
            {
                row.Qty += 1; 
                row.Sum = row.Price * row.Qty;
                row.Product = null;//WTF??
            }
            else
            { 
            order.OrderRows.Add(new OrderRow() {OrderId = order.Id, ProductId = product.Id, Qty = 1, Price = price, Sum = price });
            }

            SaveOrder(order);

        }

        public void RemoveFromCart(Product product, string userName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> GetNewsList(int page)
        {

            int pageSize = 4;

            page = Math.Max(page, 1);

            return databaseService.NewsRepository.GetAll().OrderByDescending(n => n.Date).Skip((page - 1) * pageSize).Take(pageSize);


        }
    }
}
