using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public class MaterialCalculator
    {
        // Рассчитать количество необходимого сырья
        public int CalculateRequiredMaterials(int count, int width, int length, string productType, string materialType)
        {
            // Проверка корректности переданных параметров
            if (count <= 0 || width <= 0 || length <= 0 || string.IsNullOrEmpty(productType) || string.IsNullOrEmpty(materialType))
            {
                return -1;
            }

            // Расчет коэффициента типа продукции
            double productTypeCoefficient = 0;
            switch (productType)
            {
                case "1":
                    productTypeCoefficient = 1.1;
                    break;
                case "2":
                    productTypeCoefficient = 2.5;
                    break;
                case "3":
                    productTypeCoefficient = 8.43;
                    break;
                default:
                    return -1;
            }

            // Расчет процента брака материала в зависимости от типа материала
            double materialTypePercentage = 0;
            switch (materialType)
            {
                case "1":
                    materialTypePercentage = 0.003;
                    break;
                case "2":
                    materialTypePercentage = 0.0012;
                    break;
                default:
                    return -1;
            }

            // Расчет количества необходимого качественного сырья на одну единицу продукции
            double rawMaterialsPerUnit = (width * length) * productTypeCoefficient;

            // Расчет общего количества необходимого сырья с учетом брака
            double totalRawMaterials = rawMaterialsPerUnit * count / (1 - materialTypePercentage);

            // Округление результата до ближайшего большего целого
            int requiredMaterials = (int)Math.Ceiling(totalRawMaterials);

            return requiredMaterials;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            MaterialCalculator calculator = new MaterialCalculator();
            int requiredMaterials = calculator.CalculateRequiredMaterials(10, 20, 30, "1", "1");
            Console.WriteLine("Required materials: " + requiredMaterials);
        }
    }
}
