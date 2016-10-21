using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;

namespace TycoopolisContracts
{
    public class Contract
    {
        private String name;
        private String partner;
        private DateTime start;
        private DateTime end;
        private int period;
        private String product;
        private int quantity;
        private String unit;
        private double price;
        private int direction;
        private String destination;
        private String description;

        private List<DateTime> deliveryDays;
        private List<bool> deliveryDaysCheck;

        private Contract()//Only for loading a contract
        {
            
        }
        public Contract(String name)
        {
            this.name = name;
            partner = "";
            start = DateTime.Today;
            end = DateTime.Today;
            period = 0;
            product = "";
            quantity = 0;
            unit = "";
            price = 0;
            direction = -1;
            destination = "";
            description = "";

            deliveryDays = new List<DateTime>();
        }

        //Accessors
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public String Partner
        {
            get
            {
                return partner;
            }
            set
            {
                partner = value;
            }
        }
        public void addDuration(DateTime start, DateTime end)
        {
            if(end < start)
            {
                throw new Exception("End-date can't be before the start-date!");
            }
            this.start = start;
            this.end = end;
        }
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {

            }
        }
        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {

            }
        }
        public int Period
        {
            get
            {
                return period;
            }
            set
            {
                if(value <= 0)
                {
                    throw new Exception("Period can't be 0 or lower");
                }
                period = value;
            }
        }
        public String Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
            }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if(value <= 0)
                {
                    throw new Exception("Quantity can't be 0 or lower");
                }
                quantity = value;
            }
        }
        public String Unit
        {
            get
            {
                return unit;
            }
            set
            {
                unit = value;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if(value < 0)
                {
                    throw new Exception("Quantity can't be lower than 0");
                }
                price = value;
            }
        }
        public int Direction
        {
            get
            {
                return direction;
            }
            set
            {
                if(value != 0 && value != 1)
                {
                    throw new Exception("Please select a direction!");
                }
                direction = value;
            }
        }
        public String Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }
        public String Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public List<DateTime> getDeliveryDays()
        {
            return deliveryDays;
        }
        public bool getDeliveryDayCheck(int index)
        {
            return deliveryDaysCheck[index];
        }
        public void setDeliveryDayCheck(int index, bool value)
        {
            deliveryDaysCheck[index] = value;
        }
        
        //Functions
        public void save(String name, String partner, DateTime start, DateTime end, int period, String product, int quantitiy, 
            String unit, double price, int direction, String destination, String description)//Save a contract
        {
            Contract oldContract = this.Copy();

            try
            {
                Name = name;
                Partner = partner;
                addDuration(start, end);
                Period = period;
                Product = product;
                Quantity = quantitiy;
                Unit = unit;
                Price = price;
                Direction = direction;
                Destination = destination;
                Description = description;
            }
            catch (Exception e)
            {
                //reset contract
                name = oldContract.Name;
                partner = oldContract.Partner;
                this.start = oldContract.Start;
                this.end = oldContract.End;
                period = oldContract.Period;
                product = oldContract.Product;
                quantitiy = oldContract.Quantity;
                unit = oldContract.Unit;
                price = oldContract.Price;
                direction = oldContract.Direction;
                destination = oldContract.Destination;
                description = oldContract.Description;

                throw e;//hand over the exception
            }

            if (start != oldContract.Start || end != oldContract.End)//if the duration have changed, recalculate the delivery days
            {
                calcDeliveryDays();
            }
        }
        private void calcDeliveryDays()//calculate the specific delivery days(can have a long term)
        {
            deliveryDays = new List<DateTime>();
            deliveryDaysCheck = new List<bool>();

            DateTime curDate = Start;
            while(curDate <= End)
            {
                deliveryDays.Add(curDate);
                if(curDate >= DateTime.Today)//if the deliveryDay is before today, mark that as supplied, else as not supplied
                {
                    deliveryDaysCheck.Add(false);
                }
                else
                {
                    deliveryDaysCheck.Add(true);
                }

                curDate = curDate.AddDays(period);
            }
        }
        private Contract Copy()
        {
            Contract copy = new Contract(this.Name);
            copy.partner = Partner;
            copy.start = Start;
            copy.end = End;
            copy.period = Period;
            copy.product = Product;
            copy.quantity = Quantity;
            copy.unit = Unit;
            copy.price = Price;
            copy.direction = Direction;
            copy.destination = Destination;
            copy.description = Description;

            return copy;
        }
        public static Contract load(XmlNode contract)
        {
            Contract newContract = new Contract();

            foreach(XmlNode node in contract.ChildNodes)
            {
                switch(node.Name)//XML->start and end must be previous to period and period previous to deliveryChecks
                {
                    case "name":
                        newContract.Name = node.InnerText;
                        break;
                    case "partner":
                        newContract.Partner = node.InnerText;
                        break;
                    case "start":
                        newContract.start = Convert.ToDateTime(node.InnerText);
                        break;
                    case "end":
                        newContract.end = Convert.ToDateTime(node.InnerText);            
                        break;
                    case "period":
                        newContract.Period = Convert.ToInt32(node.InnerText);
                        newContract.calcDeliveryDays();
                        break;
                    case "product":
                        newContract.Product = node.InnerText;
                        break;
                    case "quantity":
                        newContract.Quantity = Convert.ToInt32(node.InnerText);
                        break;
                    case "unit":
                        newContract.Unit = node.InnerText;
                        break;
                    case "price":
                        //give this informations, so that every computer on the world do the same
                        NumberFormatInfo provider = new NumberFormatInfo();
                        provider.NumberDecimalSeparator = ".";
                        newContract.Price = Convert.ToDouble(node.InnerText, provider);
                        break;
                    case "direction":
                        newContract.Direction = Convert.ToInt32(node.InnerText);
                        break;
                    case "destination":
                        newContract.Destination = node.InnerText;
                        break;
                    case "description":
                        newContract.Description = node.InnerText;
                        break;
                    case "deliveryChecks":
                        String rawChecks = node.InnerText;
                        for (int i = 0; i < rawChecks.Length; i++)//insert each check-state
                        {
                            //read the check-state
                            bool check;
                            if(node.InnerText[i] == '1')
                            {
                                check = true;
                            }
                            else
                            {
                                check = false;
                            }

                            //insert the check-state
                            newContract.setDeliveryDayCheck(i, check);
                        }
                        break;
                    default://Ignore each other part
                        break;
                }
            }

            return newContract;
           //return new Contract("DUMMY");//ONLY A DUMMY!!!
        }
        public XmlNode saveToXml(XmlDocument refDoc)
        {
            XmlElement root = refDoc.CreateElement("contract");//root for every contract


            //Add datas
            XmlElement name = refDoc.CreateElement("name");
            name.InnerText = this.name;
            root.AppendChild(name);

            XmlElement partner = refDoc.CreateElement("partner");
            partner.InnerText = this.partner;
            root.AppendChild(partner);

            XmlElement start = refDoc.CreateElement("start");
            start.InnerText = this.start.ToString();
            root.AppendChild(start);

            XmlElement end = refDoc.CreateElement("end");
            end.InnerText = this.end.ToString();
            root.AppendChild(end);

            XmlElement period = refDoc.CreateElement("period");
            period.InnerText = this.period.ToString();
            root.AppendChild(period);

            XmlElement product = refDoc.CreateElement("product");
            product.InnerText = this.product;
            root.AppendChild(product);

            XmlElement quantity = refDoc.CreateElement("quantity");
            quantity.InnerText = this.quantity.ToString();
            root.AppendChild(quantity);

            XmlElement unit = refDoc.CreateElement("unit");
            unit.InnerText = this.unit;
            root.AppendChild(unit);

            XmlElement price = refDoc.CreateElement("price");
            NumberFormatInfo provider = new NumberFormatInfo();//give this informations, so that every computer on the world do the same
            provider.NumberDecimalSeparator = ".";
            price.InnerText = Convert.ToString(this.price, provider);
            root.AppendChild(price);

            XmlElement direction = refDoc.CreateElement("direction");
            direction.InnerText = this.direction.ToString();
            root.AppendChild(direction);

            XmlElement destination = refDoc.CreateElement("destination");
            destination.InnerText = this.destination;
            root.AppendChild(destination);

            XmlElement description = refDoc.CreateElement("description");
            description.InnerText = this.description;
            root.AppendChild(description);

            XmlElement deliveryChecks = refDoc.CreateElement("deliveryChecks");
            String delChecksString = "";
            foreach(bool check in deliveryDaysCheck)
            {
                if(check)
                {
                    delChecksString += '1';
                }
                else
                {
                    delChecksString += '0';
                }
            }
            deliveryChecks.InnerText = delChecksString;
            root.AppendChild(deliveryChecks);


            return root;
        }
    }
}
