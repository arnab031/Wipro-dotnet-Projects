using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIExample
{
    interface IItem
    {
        void GetReceipe();
        void PrepareItem();
    }
    class VegItem : IItem
    {
        string dish;
        public VegItem(string dish)
        {
            this.dish = dish;
        }
        public void PrepareItem()
        {
            Console.WriteLine($"{dish} prepared using the receipe");
        }

        public void GetReceipe()
        {
            if (dish == "idly")
            {
                Console.WriteLine($"Receipe {dish} populated from source ");
            }
        }
    }
    class NonVegItem : IItem
    {
        string dish;
        public NonVegItem(string dish)
        {
            this.dish = dish;
        }
        public void PrepareItem()
        {
            Console.WriteLine($"{dish} prepared using the receipe");
        }

        public void GetReceipe()
        {
            if (dish == "idly")
            {
                Console.WriteLine($"Receipe {dish} populated from source ");
            }
        }
    }
    class ChineseItem : IItem
    {
        string dish;
        public ChineseItem(string dish)
        {
            this.dish = dish;
        }
        public void PrepareItem()
        {
            Console.WriteLine($"{dish} prepared using the receipe");
        }

        public void GetReceipe()
        {
            if (dish == "idly")
            {
                Console.WriteLine($"Receipe {dish} populated from source ");
            }
        }
    }
    class ExpertCook
    {
        IItem item;
        public ExpertCook(IItem item)
        {
            this.item = item;
        }
        public void CookItem()
        {
            item.GetReceipe();
            item.PrepareItem();
        }
    }
    class DIEx01
    {
        static void Main(string[] args)
        {
            ExpertCook order1 = new ExpertCook(new VegItem("Choclate dosa"));
            ExpertCook order2 = new ExpertCook(new NonVegItem("Mutton Haleem"));
            ExpertCook order3 = new ExpertCook(new ChineseItem("prawns noodles"));

            order1.CookItem();
            order2.CookItem();
            order3.CookItem();
        }
    }
}

