using System;
using System.Collections.Generic;

namespace Builder_Pizza
{
    public interface IBuilder
    {
        void Dough();
        void Sauce();
        void Cheese();
        void Meat();
        void Price();
    }
    public class MargBuilder : IBuilder
    {
        private Pizza m_pizza = new Pizza();
        public MargBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this.m_pizza = new Pizza();
        }
        public void Cheese()
        {
            this.m_pizza.Add("Margherita pizza contains cheese");
        }

        public void Dough()
        {
            this.m_pizza.Add("Margherita pizza contains dough");
        }
        public void Sauce()
        {
            this.m_pizza.Add("Margherita pizza contains sause");
        }
        public void Meat()
        {
            this.m_pizza.Add("Margherita pizza doesn't contain meat");
        }
        public void Price()
        {
            this.m_pizza.Add("The price is: 30 SAR");
        }

        public Pizza GetMPizza() 
        {
            Pizza result = this.m_pizza;
            this.Reset();
            return result;
        }
    }
    public class PepBuilder : IBuilder
    {
        private Pizza p_pizza = new Pizza();
        public PepBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this.p_pizza = new Pizza();
        }
        public void Cheese()
        {
            this.p_pizza.Add("Pepperoni pizza contains cheese");
        }

        public void Dough()
        {
            this.p_pizza.Add("Pepperoni pizza contains dough");
        }

        public void Sauce()
        {
            this.p_pizza.Add("Pepperoni pizza contains sause");
        }
        public void Meat()
        {
            this.p_pizza.Add("Pepperoni pizza contains meat");
        }
        public void Price()
        {
            this.p_pizza.Add("The price is: 40 SAR");
        }

        public Pizza GetPPizza()
        {
            Pizza result = this.p_pizza;
            this.Reset();
            return result;
        }
    }
    public class Pizza
    {
        private List<object> pizza = new List<object>();

        public void Add(string p)
        {
            this.pizza.Add(p);
        }
        public string listpizza()
        {
            string str = "";
            for (int i = 0; i < this.pizza.Count; i++)
            {
                str += this.pizza[i] + ", \n";
            }
            return "Pizza ingredients: \n" + str;
        }
    }
    public class Director
    {
        private IBuilder _builder;
        public IBuilder Builder
        {
            set { this._builder = value; }
        }
        public void BuildMPizza()
        {
            this._builder.Dough();
            this._builder.Sauce();
            this._builder.Cheese();
            this._builder.Meat();
            this._builder.Price();

        }
        public void BuildPPizza()
        {
            this._builder.Dough();
            this._builder.Sauce();
            this._builder.Cheese();
            this._builder.Meat();
            this._builder.Price();

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create director
            var director = new Director();
            // Create Builder
            var Mbuilder = new MargBuilder();
            var Pbuilder = new PepBuilder();


            director.Builder = Mbuilder;

            director.BuildMPizza();
            Console.WriteLine(Mbuilder.GetMPizza().listpizza());
            Console.WriteLine("------------------------------------------------------------------");
            director.Builder = Pbuilder;

            director.BuildPPizza();
            Console.WriteLine(Pbuilder.GetPPizza().listpizza());

            Console.ReadKey();

        }
    }
}
