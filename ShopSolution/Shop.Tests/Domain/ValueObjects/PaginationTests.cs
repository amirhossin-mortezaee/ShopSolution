using Shop.Domain.Commons.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests.Domain.ValueObjects
{
    public class PaginationTests
    {
        [Fact]
        public void TotalPages_ShouldBeCalculatedCorrectly()
        {
            //تنظیم مقدار اولیه 
            var pagination = new Pagination(pageNumber: 2, pageSize: 10, totalCount: 25);

            //گرفتن تعداد کل صفحات
            var totalPages = pagination.TotalPages;

            //بررسی نتیجه
            Assert.Equal(3, totalPages);//ایتم / 10 ایتم در هر صفحه <-3 صفحه 25 ایتم
        }

        [Fact]
        public void HasPreviousPage_ShouldReturnTrue_WhenPageNumberGreaterThan1() 
        {
            //ایجاد pagination با شماره صفحه 2
            var pagination = new Pagination(pageNumber : 2,pageSize: 10);

            //بررسی اینکه صفحه قبلی وجود دارد
            Assert.True(pagination.HasPreviousPage);
        }

        [Fact]
        public void HasNextPage_ShouldReturnTrue_WhenPageNumberLessThanTotalPages()
        {
            // ایجاد Pagination با شماره صفحه 1 و تعداد کل آیتم 25
            var pagination = new Pagination(pageNumber: 1, pageSize: 10, totalCount: 25);

            // بررسی اینکه صفحه بعدی وجود دارد
            Assert.True(pagination.HasNextPage);
        }

        [Fact]
        public void Skip_ShouldReturnCorrectValue()
        {
            // ایجاد Pagination با شماره صفحه 3 و تعداد آیتم در هر صفحه 10
            var pagination = new Pagination(pageNumber: 3, pageSize: 10);

            // بررسی مقدار آیتم‌هایی که باید رد شوند
            Assert.Equal(20, pagination.Skip); // (3-1)*10 = 20
        }

        [Fact]
        public void Take_ShouldReturnPageSize()
        {
            // ایجاد Pagination با تعداد آیتم در هر صفحه 15
            var pagination = new Pagination(pageNumber: 1, pageSize: 15);

            // بررسی مقدار آیتم‌هایی که باید گرفته شوند
            Assert.Equal(15, pagination.Take);
        }

    }
}
