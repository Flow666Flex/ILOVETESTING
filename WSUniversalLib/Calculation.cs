using Code;

namespace WSUniversalLib
{
    [TestClass]
    public class Calculation
    {
        [TestMethod]
        public void CalculateRequiredMaterials_ValidParameters_ReturnsRequiredMaterials()
        {
            // Arrange
            int count = 10;
            int width = 5;
            int length = 7;
            string productType = "1";
            string materialType = "1";
            int expected = 387;
            MaterialCalculator calculator = new MaterialCalculator();

            // Act
            int actual = calculator.CalculateRequiredMaterials(count, width, length, productType, materialType);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateRequiredMaterials_NegativeCount_ReturnsMinusOne()
        {
            // Arrange
            MaterialCalculator calculator = new MaterialCalculator();
            int count = -10;
            int width = 5;
            int length = 7;
            string productType = "1";
            string materialType = "1";

            // Act
            int result = calculator.CalculateRequiredMaterials(count, width, length, productType, materialType);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void CalculateRequiredMaterials_AllParametersAreValid_CalculatesRequiredMaterials()
        {
            // Arrange
            MaterialCalculator calculator = new MaterialCalculator();

            // Act
            int result = calculator.CalculateRequiredMaterials(10, 20, 30, "1", "1");

            // Assert
            Assert.AreEqual(6620, result);
        }

        [TestMethod]
        public void CalculateRequiredMaterials_InvalidInputs_ReturnsMinusOne()
        {
            // Arrange
            MaterialCalculator calculator = new MaterialCalculator();

            // Act & Assert
            Assert.AreEqual(-1, calculator.CalculateRequiredMaterials(0, 10, 20, "1", "1"));
            Assert.AreEqual(-1, calculator.CalculateRequiredMaterials(10, 0, 20, "1", "1"));
            Assert.AreEqual(-1, calculator.CalculateRequiredMaterials(10, 20, 0, "1", "1"));
            Assert.AreEqual(-1, calculator.CalculateRequiredMaterials(10, 20, 30, "", "1"));
            Assert.AreEqual(-1, calculator.CalculateRequiredMaterials(10, 20, 30, "1", ""));
        }

        [TestMethod]
        public void CalculateRequiredMaterials_WithNegativeCount_ReturnsNegativeOne()
        {
            MaterialCalculator calculator = new MaterialCalculator();
            int requiredMaterials = calculator.CalculateRequiredMaterials(-10, 20, 30, "1", "1");
            Assert.AreEqual(requiredMaterials, -1);
        }

        [TestMethod]
        public void CalculateRequiredMaterials_WithNegativeWidth_ReturnsNegativeOne()
        {
            MaterialCalculator calculator = new MaterialCalculator();
            int requiredMaterials = calculator.CalculateRequiredMaterials(10, -20, 30, "1", "1");
            Assert.AreEqual(requiredMaterials, -1);
        }

        [TestMethod]
        public void CalculateRequiredMaterials_WithZeroLength_ReturnsNegativeOne()
        {
            MaterialCalculator calculator = new MaterialCalculator();
            int requiredMaterials = calculator.CalculateRequiredMaterials(10, 20, 0, "1", "1");
            Assert.AreEqual(requiredMaterials, -1);
        }

        [TestMethod]
        public void CalculateRequiredMaterials_WithInvalidProductType_ReturnsNegativeOne()
        {
            MaterialCalculator calculator = new MaterialCalculator();
            int requiredMaterials = calculator.CalculateRequiredMaterials(10, 20, 30, "4", "1");
            Assert.AreEqual(requiredMaterials, -1);
        }

        [TestMethod]
        public void CalculateRequiredMaterials_WithInvalidMaterialType_ReturnsNegativeOne()
        {
            MaterialCalculator calculator = new MaterialCalculator();
            int requiredMaterials = calculator.CalculateRequiredMaterials(10, 20, 30, "1", "3");
            Assert.AreEqual(requiredMaterials, -1);
        }

        [TestMethod]
        public void CalculateRequiredMaterials_WithLargeProductCount_ReturnsPositiveNumber()
        {
            MaterialCalculator calculator = new MaterialCalculator();
            int requiredMaterials = calculator.CalculateRequiredMaterials(1000, 100, 100, "3", "1");
            Assert.IsTrue(requiredMaterials > 0);
        }
    }
}