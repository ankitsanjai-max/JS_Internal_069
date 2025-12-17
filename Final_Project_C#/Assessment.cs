using System;

namespace SmartCarePatientSystem
{
    // Delegates for flexible billing and notifications
    public delegate decimal BillCalculator(decimal amount);
    public delegate void Notify(string info);

    // Utility class for formatted console output
    public static class Display
    {
        private const int width = 55;
        private static string line = new string('=', width);

        public static void Title(string text)
        {
            Console.WriteLine(line);
            string centered = text.PadLeft((width + text.Length) / 2);
            Console.WriteLine(centered.ToUpper());
            Console.WriteLine(line);
        }

        public static void ShowInfo(string label, string value)
        {
            Console.WriteLine(label.PadRight(20) + ": " + value);
        }

        public static void Wait()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    // ================= ENTITY CLASSES =================

    public abstract class Person
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }

        protected Person(int id, string name)
        {
            Id = id;
            FullName = name;
        }

        public abstract decimal TreatmentCost();
    }

    public class IndoorPatient : Person
    {
        public int DaysStayed { get; private set; }
        public decimal DailyRoomRate { get; private set; }

        public IndoorPatient(int id, string name, int days, decimal rate)
            : base(id, name)
        {
            DaysStayed = days;
            DailyRoomRate = rate;
        }

        public override decimal TreatmentCost()
        {
            return DaysStayed * DailyRoomRate;
        }
    }

    public class OPDPatient : Person
    {
        public decimal ConsultationFee { get; private set; }

        public OPDPatient(int id, string name, decimal fee)
            : base(id, name)
        {
            ConsultationFee = fee;
        }

        public override decimal TreatmentCost()
        {
            return ConsultationFee;
        }
    }

    // ================= CORE SYSTEM =================

    public class CareCenter
    {
        // Event system for communication between hospital departments
        public event Notify BillReady;

        public void RegisterBill(Person p, BillCalculator billStrategy)
        {
            decimal baseCharge = p.TreatmentCost();
            decimal total = billStrategy(baseCharge);

            Display.Title("BILL DETAILS");
            Display.ShowInfo("Patient ID", p.Id.ToString());
            Display.ShowInfo("Name", p.FullName);
            Display.ShowInfo("Patient Type", p.GetType().Name);
            Display.ShowInfo("Base Charge", baseCharge.ToString("C"));
            Display.ShowInfo("Final Bill", total.ToString("C"));

            // Trigger event notification
            TriggerNotification("Bill of " + total.ToString("C") + " generated for " + p.FullName);
        }

        private void TriggerNotification(string details)
        {
            if (BillReady != null)
                BillReady(details);
        }
    }

    // ================= SUBSCRIBERS =================

    public static class DepartmentNotifier
    {
        public static void AccountsDept(string data)
        {
            Console.WriteLine("\n[Accounts Dept] " + data);
        }

        public static void ReceptionDesk(string data)
        {
            Console.WriteLine("[Reception Desk] " + data);
        }
    }

    // ================= MAIN PROGRAM =================

    class PatientApp
    {
        static int nextId = 5001;

        static decimal NormalBilling(decimal amt)
        {
            return amt;
        }

        static decimal CorporateInsurance(decimal amt)
        {
            return amt * 0.7m;
        }

        static decimal SeniorCitizenDiscount(decimal amt)
        {
            return amt * 0.85m;
        }

        static void Main()
        {
            CareCenter center = new CareCenter();
            center.BillReady += DepartmentNotifier.AccountsDept;
            center.BillReady += DepartmentNotifier.ReceptionDesk;

            while (true)
            {
                Console.Clear();
                Display.Title("SmartCare Patient Billing System");
                Console.WriteLine("1. Admit and Bill Patient");
                Console.WriteLine("2. Exit");
                Console.Write("\nChoose Option: ");
                string opt = Console.ReadLine();

                if (opt == "2")
                    break;

                AdmitAndProcess(center);
            }
        }

        static void AdmitAndProcess(CareCenter center)
        {
            Console.Clear();
            Display.Title("Patient Admission");

            Console.Write("Enter Patient Name: ");
            string pname = Console.ReadLine();

            Console.WriteLine("\nSelect Patient Type");
            Console.WriteLine("1. Indoor Patient");
            Console.WriteLine("2. Outpatient (OPD)");
            Console.Write("Option: ");
            string type = Console.ReadLine();

            Person person;

            if (type == "1")
            {
                Console.Write("Days Admitted: ");
                int days = Convert.ToInt32(Console.ReadLine());
                Console.Write("Room Rate per Day: ");
                decimal rate = Convert.ToDecimal(Console.ReadLine());
                person = new IndoorPatient(nextId++, pname, days, rate);
            }
            else
            {
                Console.Write("Consultation Fee: ");
                decimal fee = Convert.ToDecimal(Console.ReadLine());
                person = new OPDPatient(nextId++, pname, fee);
            }

            Console.WriteLine("\nSelect Billing Scheme");
            Console.WriteLine("1. Normal");
            Console.WriteLine("2. Corporate Insurance");
            Console.WriteLine("3. Senior Citizen Discount");
            Console.Write("Choice: ");
            string plan = Console.ReadLine();

            BillCalculator calculator;
            switch (plan)
            {
                case "2": calculator = CorporateInsurance; break;
                case "3": calculator = SeniorCitizenDiscount; break;
                default: calculator = NormalBilling; break;
            }

            Console.Clear();
            center.RegisterBill(person, calculator);
            Display.Wait();
        }
    }
}