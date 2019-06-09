using System;
namespace FastFood
{
    public class Combo
    {
        public Combo()
        {
                    private string _comboType;
        private Dictionary<string, dynamic> _items = new Dictionary<string, dynamic>();

        public Combo(string comboType)
        {
            this._comboType = comboType;
        }

        public dynamic this[string key]
        {
            get { return _items[key]; }
            set { _items[key] = value; }
        }

        public Dictionary<string, dynamic> GetCombo()
        {
            return _items;
        }
    }

    public abstract class ComboBuilder
    {
        public Combo combo { get; set; }

        public abstract void ComboTypeBuilder();
        public abstract void SandwitchBuilder();
        public abstract void SidesBuilder();
        public abstract void SodaBuilder();
        public abstract void PriceBuilder();
    }

    public class CheeseBurgerComboBuilder : ComboBuilder
    {


        public CheeseBurgerComboBuilder()
        {
            combo = new Combo("Cheese Burger Builder");
        }

        public override void ComboTypeBuilder()
        {
            combo["ComboType"] = "Cheese Burger Combo";
        }

        public override void SandwitchBuilder()
        {
            combo["Sandwitch"] = "Cheese Burger";
        }

        public override void SidesBuilder()
        {
            combo["Sides"] = "Fries";
        }

        public override void SodaBuilder()
        {
            combo["Soda"] = "A soda cup";
        }

        public override void PriceBuilder()
        {
            double price = 7;
            combo["Price"] = price;
        }
    }

    public class FishBurgerComboBuilder : ComboBuilder
    {

        public FishBurgerComboBuilder()
        {
            combo = new Combo("Fish Burger Builder");
        }

        public override void ComboTypeBuilder()
        {
            combo["ComboType"] = "Fish Burger Combo";
        }

        public override void SandwitchBuilder()
        {
            combo["Sandwitch"] = "Fish Burger";
        }

        public override void SidesBuilder()
        {
            combo["Sides"] = "Chicken Nugges";
        }

        public override void SodaBuilder()
        {
            combo["Soda"] = "A soda cup";
        }

        public override void PriceBuilder()
        {
            double price = 10;
            combo["Price"] = price;
        }
    }


    public class ComboMenu
    {
        public void Construct(ComboBuilder comboBuilder)
        {
            comboBuilder.ComboTypeBuilder();
            comboBuilder.SandwitchBuilder();
            comboBuilder.SidesBuilder();
            comboBuilder.SodaBuilder();
            comboBuilder.PriceBuilder();
        }
    }
    }
}
