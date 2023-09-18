using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRevisionWeekOne
{
    internal class MyAtmRevision
    {
        private String cardNumber;
        private String fullNames;
        private int pin;
        private String currency;
        private double balance;

        public MyAtmRevision(String cardNo,String fullNames,int pin,String currency,double balance)
        {
            this.cardNumber = cardNo;
            this.fullNames = fullNames;
            this.pin = pin;
            this.currency = currency;
            this.balance = balance;
        }

        //Getter Functions
        public String GetCardNimber()
        {
            return cardNumber;
        }

        public int GetPin()
        {
            return pin;
        }

        public String GetFullName()
        {
            return fullNames;
        }

        public double GetBalance()
        {
            return balance;
        }

        public String GetCurrency()
        {
            return currency;
        }

        //Setter Functions

        public void SetCardNumber(String newCardNo)
        {
            cardNumber = newCardNo;
        }

        public void SetFullName(String newFullName)
        {
            fullNames = newFullName; 
        }

        public void SetPin(int newPinNo)
        {
            pin = newPinNo;
        }

        public void SetCurrency(String NewCurrency)
        {
            currency = NewCurrency;
        }

        public void SetBalance(double newBalance)
        {
            balance = newBalance;
        }
        static void Main(String[] args)
        {
            List<MyAtmRevision> listOfClients = new List<MyAtmRevision>();
            listOfClients.Add(new MyAtmRevision("50021","Mugabo Andre",1234,"Frw",1500000));
            listOfClients.Add(new MyAtmRevision("50022","Munezero Ange",1235,"Frw",2500000));
            listOfClients.Add(new MyAtmRevision("50023","Tuyishime Elvis",1236,"Usd",180000));
            listOfClients.Add(new MyAtmRevision("50024","Tuyishime Isaac",1237,"Frw",100000));
            listOfClients.Add(new MyAtmRevision("50025","Munyandakwe Saad",1238,"Frw",500000));
            listOfClients.Add(new MyAtmRevision("50026","Hakizimana Dieudonne",1239,"Frw",1700000));

            // Prompt the user to execute the system 
            Console.WriteLine("Welcome DotNet ATM Class");
            Console.WriteLine("Please enter the Digit on your Card ");
            String enteredCardNo = "";
            int enteredPin = 0;
            String obFullName = "";
            int count = 0;
            bool log = false;
            MyAtmRevision currentCustomer = null ;




            //Check against the given cardNumber
            while (true)
            {
                try
                {
                    enteredCardNo =  Console.ReadLine();
                    foreach (var item in listOfClients)
                    {
                        //Console.WriteLine(item.cardNumber);
                        if (item.cardNumber == enteredCardNo)
                        {
                            currentCustomer = item;
                            break;
                        }
                        
                    }

                    if(currentCustomer != null)
                        {
                        break;
                    }
                    {
                        Console.WriteLine("Card not Registered try again");
                    }

                }
                catch 
                { 
                    Console.WriteLine("Card not Found !!!"); 
                }
            } 
            Console.WriteLine("Card for "+currentCustomer.GetFullName());
            Console.WriteLine("Please Enter your Pin");

            //Check against the given pin

            while (true)
            {
                enteredPin = Convert.ToInt32(Console.ReadLine());
                try
                {
                   if(currentCustomer.GetPin() == enteredPin)
                    {
                        log = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong pin Try Again !!!");
                       
                    }
                   if(count == 3)
                    {
                        break;
                    }
                    count += 3;
                }
                catch { Console.WriteLine("Wrong Pin"); }
            }

            if (log)
            {
                printOptions();
                int option;
                

                do
                {
                    Console.WriteLine("----Choose your  option---- ");
                   option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            CheckeBalance(currentCustomer);
                            break;
                        case 2:
                            Deposite(currentCustomer);
                            break;
                        case 3:
                            Withdraw(currentCustomer);
                            break;
                        case 4:
                            CheckCurrency(currentCustomer);
                            break;
                        default:
                            Console.WriteLine("Wrong Option");
                            break;
                    }
                } while (option != 5);
                
            }
            
           
            Console.ReadKey();
        }

        static void printOptions()
        {
            Console.WriteLine("Please choose an Operation from the option bellow");
            Console.WriteLine("1. For Checking Balance ");
            Console.WriteLine("2. For Deposite ");
            Console.WriteLine("3. For Withdraw ");
            Console.WriteLine("4. For Checking the Currency ");
            Console.WriteLine("5. For Exit ");
        }

        static void CheckeBalance(MyAtmRevision myAtmRevision)
        {
            Console.WriteLine("Your balance is :" + myAtmRevision.GetBalance());
        }
        
        static void Deposite(MyAtmRevision myAtmRevision)
        {
            Console.WriteLine("Specify your currency :\n");
            String specifiedCurrency = Console.ReadLine();
            if(myAtmRevision.GetCurrency() == specifiedCurrency)
            {
                Console.WriteLine("How Much would like to deposit ?");
                double newBalance = double.Parse(Console.ReadLine());
                myAtmRevision.SetBalance(myAtmRevision.GetBalance() + newBalance);
                Console.WriteLine("Your new Balance is :" + myAtmRevision.GetBalance());
                Console.WriteLine("Thank you for deposit operation successfully");
            }
            else
            {
                Console.WriteLine("Wrong currency !!! ");
            }

        }

        static void Withdraw(MyAtmRevision myAtmRevision)
        {
            Console.WriteLine("How Much you want to Withdraw ");
            double withdraw = double.Parse(Console.ReadLine());
            if ( withdraw > myAtmRevision.GetBalance() )
            {
                Console.WriteLine("Insouficiante amount");
            }
            else
            {
                myAtmRevision.SetBalance(myAtmRevision.GetBalance() - withdraw);
                Console.WriteLine("Operation Successfuly");
                Console.WriteLine("Withdraw :"+withdraw);
                CheckeBalance(myAtmRevision);

            }
        }

        static void CheckCurrency(MyAtmRevision myAtmRevision)
        {
            Console.WriteLine("Your currency is  :" + myAtmRevision.GetCurrency());
        }
            
                

        
    }
}
