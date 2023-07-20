using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyShoping.Model
{
    public class Toy
    {
        private string name;
        private string description;
        private string price;
        private string imagePath;
        public int id { get; set; }


        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public string Price
        {
            get => price;
            set => price = value;
        }


        public string ImagePath
        {
            get => imagePath;
            set => imagePath = value;
        }
        public string PriceFormat
        {
            get => price + " рублей";
        } 
        public Toy()
        {

        }
        public string ImagePathD { get { return Directory.GetCurrentDirectory() + imagePath; } }

        public Toy(string name, string price, string description, string imagePath)
        {
            Name = name;
            Description = description;
            Price = price;
            ImagePath = imagePath;


        }
    }
}


