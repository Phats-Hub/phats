namespace assignment1
{
    namespace asm
    {
        internal class Program
        {
            const double VAT = 0.1;
            const double ENV_FEE = 0.1;
            static void Main(string[] args)
            {
                string customerName, typeOfCustomer; // tên biến kiểu khách hàng và tên khách hàng 
                int numberOfPeople = 1;

                double lastMonthOfWater, thisMonthOfWater; // biến tháng trước và tháng này 
                double normalPrice; // giá bình thường
                double totalWaterBill = 0;

                // nhập thông tin khách hàng 
                Console.WriteLine("Please enter your customer name:"); // nhập tên khách hàng
                customerName = Console.ReadLine();

                Console.WriteLine("Please enter last month's water meter:"); // nhập số mét nước tháng trước 
                lastMonthOfWater = double.Parse(Console.ReadLine());

                Console.WriteLine("Please enter this month's water meter:"); // nhập số mét nước tháng này 
                thisMonthOfWater = double.Parse(Console.ReadLine());

                double consumption = thisMonthOfWater - lastMonthOfWater;

                // in các yêu cầu 
                Console.WriteLine("Please enter your type of customer:");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("1. Household customer");
                Console.WriteLine("2. Administrative agency, public services");
                Console.WriteLine("3. Production units");
                Console.WriteLine("4. Business services");

                typeOfCustomer = Console.ReadLine();
                switch (typeOfCustomer)
                {
                    case "1":
                        Console.WriteLine("Please enter your number of people:");
                        numberOfPeople = int.Parse(Console.ReadLine());
                        double totalPrice = CalculateForHouseholdCustomer(numberOfPeople, consumption);
                        totalWaterBill = GetTotalWaterBillWithFee(totalPrice);
                        break;

                    case "2":
                        normalPrice = 9955;
                        totalWaterBill = GetTotalWaterBillWithFee(consumption * normalPrice);
                        break;

                    case "3":
                        normalPrice = 11615;
                        totalWaterBill = GetTotalWaterBillWithFee(consumption * normalPrice);
                        break;

                    case "4":
                        normalPrice = 22068;
                        totalWaterBill = GetTotalWaterBillWithFee(consumption * normalPrice);
                        break;

                    default:
                        Console.WriteLine("Type of customer is invalid !!! Please enter again.");
                        Environment.Exit(0);
                        break;
                }
                ShowInvoice(customerName, typeOfCustomer, lastMonthOfWater, thisMonthOfWater, consumption, totalWaterBill);
            }

            public static double CalculateForHouseholdCustomer(int numberOfPeople, double consumption)
            {
                double avgPerPerson = consumption / numberOfPeople;
                double totalPrice = 0;

                if (avgPerPerson <= 10)
                {
                    totalPrice = numberOfPeople * 5973 * numberOfPeople;
                }
                else if (avgPerPerson <= 20)
                {
                    totalPrice = (10 * 5973 * numberOfPeople) + ((avgPerPerson - 20) * 7052 * numberOfPeople);
                }
                else if (avgPerPerson <= 30)
                {
                    totalPrice = (10 * 5973 * numberOfPeople) + (10 * 7052 * numberOfPeople) + ((avgPerPerson - 30) * 8699 * numberOfPeople);
                }
                else
                {
                    totalPrice = (10 * 5973 * numberOfPeople) + (10 * 7052 * numberOfPeople) + (10 * 8699 * numberOfPeople) + ((avgPerPerson - 30) * 15929 * numberOfPeople);
                }

                return totalPrice;
            }

            public static double GetTotalWaterBillWithFee(double totalWaterBill)
            {
                double totalPriceENV = totalWaterBill + (totalWaterBill * ENV_FEE);
                double totalPriceVAT = totalPriceENV + (totalPriceENV * VAT);
                return totalPriceVAT;
            }

            public static void ShowInvoice(string customerName, string typeOfCustomer, double lastMonth, double thisMonth, double consumption, double totalPrice)
            {
                Console.WriteLine("------INVOICE--------");
                Console.WriteLine("Customer name: " + customerName);
                Console.WriteLine("Type of customer: " + typeOfCustomer);
                Console.WriteLine("Last month's water meter: " + lastMonth + " m³");
                Console.WriteLine("This month's water meter: " + thisMonth + " m³");
                Console.WriteLine("Amount of consumption: " + consumption + " m³");
                Console.WriteLine("Total water bill: " + totalPrice + " VND");
            }
        }
    }
}